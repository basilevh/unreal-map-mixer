// BVH

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnrealMapMixer.Mixers;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer
{
    public partial class frmMain : Form
    {
        public static string UTPath;

        public frmMain()
        {
            InitializeComponent();
            initDialogs();
            sourceMaps = new Dictionary<string, UnrealMap>();
            loadState();
        }

        private OpenFileDialog inputOpenDialog;
        private Dictionary<string, UnrealMap> sourceMaps;

        private void initDialogs()
        {
            inputOpenDialog = new OpenFileDialog
            {
                Filter = "Unreal Text (T3D) File (*.t3d)|*.t3d",
                Title = "Select source file(s)",
                Multiselect = true
            };

            // Set game folder if found
            UTPath = FindUTPath();
            if (UTPath != null)
                inputOpenDialog.InitialDirectory = UTPath;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveState();
        }

        private void loadState()
        {
            var settings = Properties.Settings.Default;

            // Source files
            lvwSourceFiles.Items.Clear();
            if (settings.InputFiles != null)
                foreach (string path in settings.InputFiles)
                    if (File.Exists(path))
                    {
                        string text = File.ReadAllText(path);
                        if (text.StartsWith("Begin Map"))
                        {
                            sourceMaps[path] = UnrealMap.FromText(text);
                            lvwSourceFiles.Items.Add(createItemFromFile(path));
                        }
                    }

            // Intelligence
            radOrdered.Checked = (settings.Mode == 0);
            radShuffled.Checked = (settings.Mode == 1);
            radSmartClosed.Checked = (settings.Mode == 2);
            radSmartOpen.Checked = (settings.Mode == 3);

            // Probabilities
            numSolid.Value = settings.SolidProb;
            numSemiSolid.Value = settings.SemiSolidProb;
            numNonSolid.Value = settings.NonSolidProb;
            numSubtract.Value = settings.SubtractProb;
            numMover.Value = settings.MoverProb;
            numLight.Value = settings.LightProb;
            numOther.Value = settings.OtherProb;

            // Excluded actors
            chkExInvis.Checked = settings.ExcludeInvisible;
            chkExPortal.Checked = settings.ExcludePortal;
            chkExZoneInfo.Checked = settings.ExcludeZone;
            chkExMore.Checked = settings.ExcludeMore;
            txtExcludeActors.Lines = settings.ExcludedActors?.Cast<string>().ToArray();
        }

        private void saveState()
        {
            var settings = Properties.Settings.Default;

            // Source files
            settings.InputFiles = new StringCollection();
            settings.InputFiles.AddRange(lvwSourceFiles.Items.Cast<ListViewItem>().Select(i => i.Text).ToArray());

            // Intelligence
            settings.Mode = (radOrdered.Checked ? 0 : radShuffled.Checked ? 1
                : radSmartClosed.Checked ? 2 : 3);

            // Probabilities
            settings.SolidProb = numSolid.Value;
            settings.SemiSolidProb = numSemiSolid.Value;
            settings.NonSolidProb = numNonSolid.Value;
            settings.SubtractProb = numSubtract.Value;
            settings.MoverProb = numMover.Value;
            settings.LightProb = numLight.Value;
            settings.OtherProb = numOther.Value;

            // Excluded actors
            settings.ExcludeInvisible = chkExInvis.Checked;
            settings.ExcludePortal = chkExPortal.Checked;
            settings.ExcludeZone = chkExZoneInfo.Checked;
            settings.ExcludeMore = chkExMore.Checked;
            settings.ExcludedActors = new StringCollection();
            settings.ExcludedActors.AddRange(txtExcludeActors.Lines);

            settings.Save();
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

            // Show layout form (responsible for starting and saving the mix)
            var layoutForm = new frmMapLayout(mixer, mixParams);
            layoutForm.Show();
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

        private void lvwSourceFiles_DoubleClick(object sender, EventArgs e)
        {
            btnView_Click(sender, e);
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
