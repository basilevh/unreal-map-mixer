// BVH

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UnrealMapMixer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            initDialogs();
            sourceMaps = new Dictionary<string, UnrealMap>();
            loadState();
        }

        private OpenFileDialog inputOpenDialog;
        private SaveFileDialog outputSaveDialog;
        private Dictionary<string, UnrealMap> sourceMaps;

        private void initDialogs()
        {
            inputOpenDialog = new OpenFileDialog
            {
                Filter = "Unreal Text (T3D) File (*.t3d)|*.t3d",
                Title = "Select source file(s)",
                Multiselect = true
            };
            outputSaveDialog = new SaveFileDialog
            {
                Filter = "Unreal Text (T3D) File (*.t3d)|*.t3d",
                Title = "Specify destination file"
            };

            // Set game folder if found
            string utPath = FindUTPath();
            if (utPath != null)
            {
                inputOpenDialog.InitialDirectory = utPath;
                outputSaveDialog.InitialDirectory = utPath;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveState();
        }

        private void loadState()
        {
            lvwSourceFiles.Items.Clear();
            if (Properties.Settings.Default.InputFiles != null)
                foreach (string path in Properties.Settings.Default.InputFiles)
                    if (File.Exists(path))
                    {
                        string text = File.ReadAllText(path);
                        if (text.StartsWith("Begin Map"))
                        {
                            sourceMaps[path] = UnrealMap.FromText(text);
                            lvwSourceFiles.Items.Add(createItemFromFile(path));
                        }
                    }
            txtExcludeActors.Lines = Properties.Settings.Default.ExcludedActors?.Cast<string>().ToArray();
        }

        private void saveState()
        {
            Properties.Settings.Default.InputFiles = new StringCollection();
            Properties.Settings.Default.InputFiles.AddRange(lvwSourceFiles.Items.Cast<ListViewItem>().Select(i => i.Text).ToArray());
            Properties.Settings.Default.ExcludedActors = new StringCollection();
            Properties.Settings.Default.ExcludedActors.AddRange(txtExcludeActors.Lines);
            Properties.Settings.Default.Save();
        }

        private ListViewItem createItemFromFile(string path)
        {
            var map = UnrealMap.FromText(File.ReadAllText(path));
            string title = map.Title;
            string author = map.Author;
            string type = (map.Type.ToString() != "Unknown" ? map.Type.ToString() : "");
            var item = new ListViewItem(new string[] { path, title, author, type });
            return item;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (lvwSourceFiles.Items.Count == 0)
            {
                MessageBox.Show("No source files are specified", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create mixer
            MapMixer mixer;
            if (radOrdered.Checked)
                mixer = new OrderedMapMixer(sourceMaps.Values);
            else if (radShuffled.Checked)
                mixer = new ShuffledMapMixer(sourceMaps.Values);
            else
            {
                MessageBox.Show("Unknown map mixing mode", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get mixing parameters
            var mixParams = new MapMixParams()
            {
                RemoveTrappedPlayerStarts = chkRemTrapPlay.Checked,
                TranslateCommonCOG = chkTranslateCOG.Checked,
                KeepEventTagLinks = chkKeepEventTag.Checked,
                KeepWorldConnections = chkKeepWorldCons.Checked,
                ExpandPortals = chkExpandPortals.Checked,
                SolidProb = (double)numSolid.Value / 100.0,
                SemiSolidProb = (double)numSemiSolid.Value / 100.0,
                NonSolidProb = (double)numNonSolid.Value / 100.0,
                SubtractProb = (double)numSubtract.Value / 100.0,
                MoverProb = (double)numMover.Value / 100.0,
                LightProb = (double)numLight.Value / 100.0,
                OtherProb = (double)numOther.Value / 100.0,
                ExcludeInvisible = chkExInvis.Checked,
                ExcludePortal = chkExPortal.Checked,
                ExcludeZoneInfo = chkExZoneInfo.Checked,
                ExcludeMore = chkExMore.Checked,
                ExcludeMoreNames = txtExcludeActors.Lines.Where(s => s.Length != 0)
            };

            // Perform mix
            var result = mixer.Mix(mixParams);

            // Show layout
            var layoutForm = new frmMapLayout(result);
            layoutForm.Show();

            // Save
            if (outputSaveDialog.ShowDialog() == DialogResult.OK)
                File.WriteAllText(outputSaveDialog.FileName, result.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (inputOpenDialog.ShowDialog() == DialogResult.OK)
            {
                // Replace the list of files with those just selected
                foreach (string path in inputOpenDialog.FileNames)
                {
                    string text = File.ReadAllText(path);
                    if (text.StartsWith("Begin Map"))
                    {
                        sourceMaps[path] = UnrealMap.FromText(text);
                        lvwSourceFiles.Items.Add(createItemFromFile(path));
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var paths = lvwSourceFiles.SelectedItems?.Cast<ListViewItem>().Select(i => i.Text);
            foreach (string path in paths)
            {
                sourceMaps.Remove(path);
                foreach (var item in lvwSourceFiles.Items.Cast<ListViewItem>())
                    if (item.Text == path)
                        item.Remove();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var paths = lvwSourceFiles.SelectedItems?.Cast<ListViewItem>().Select(i => i.Text);
            foreach (string path in paths)
            {
                var layoutForm = new frmMapLayout(sourceMaps[path]);
                layoutForm.Show();
            }
        }

        private static string FindUTPath()
        {
            var drives = System.IO.DriveInfo.GetDrives();
            foreach (var drive in drives)
                if (drive.IsReady)
                {
                    // Inspect level 1
                    try
                    {
                        foreach (var dir in Directory.GetDirectories(drive.Name))
                        {
                            if (isUTPath(dir))
                                return dir + "\\Maps";

                            // Inspect level 2
                            try
                            {
                                foreach (var subDir in Directory.GetDirectories(dir))
                                {
                                    if (isUTPath(subDir))
                                        return subDir + "\\Maps";
                                }
                            }
                            catch (UnauthorizedAccessException)
                            { }
                        }
                    }
                    catch (UnauthorizedAccessException)
                    { }
                }

            // Not found
            return null;
        }

        private static bool isUTPath(string folder)
        {
            // Check if both a 'Maps' and 'System' directory exist, and there is at least one UNR file in 'Maps'
            return (folder.Contains("Tournament")
                && Directory.Exists(folder + "\\Maps")
                && Directory.Exists(folder + "\\System")
                && Directory.GetFiles(folder + "\\Maps").Any(s => s.EndsWith(".unr")));
        }
    }
}
