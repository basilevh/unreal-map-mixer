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
            loadState();
        }

        private OpenFileDialog inputOpenDialog;
        private SaveFileDialog outputSaveDialog;

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
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveState();
        }

        private void loadState()
        {
            txtInputFiles.Lines = Properties.Settings.Default.InputFiles?.Cast<string>().ToArray();
            txtExcludeActors.Lines = Properties.Settings.Default.ExcludedActors?.Cast<string>().ToArray();
        }

        private void saveState()
        {
            Properties.Settings.Default.InputFiles = new StringCollection();
            Properties.Settings.Default.InputFiles.AddRange(txtInputFiles.Lines);
            Properties.Settings.Default.ExcludedActors = new StringCollection();
            Properties.Settings.Default.ExcludedActors.AddRange(txtExcludeActors.Lines);
            Properties.Settings.Default.Save();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (txtInputFiles.Text.Length == 0)
            {
                MessageBox.Show("No source files are specified", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get input maps
            var maps = txtInputFiles.Lines
                .Where(s => s.Length != 0)
                .Select(s => File.ReadAllText(s))
                .Select(s => UnrealMap.FromText(s));

            // Create mixer
            MapMixer mixer;
            if (radOrdered.Checked)
                mixer = new OrderedMapMixer(maps);
            else if (radShuffled.Checked)
                mixer = new ShuffledMapMixer(maps);
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (inputOpenDialog.ShowDialog() == DialogResult.OK)
            {
                // Replace the list of files with those just selected
                txtInputFiles.Clear();
                foreach (string fileName in inputOpenDialog.FileNames)
                    txtInputFiles.AppendText(fileName + Environment.NewLine);
            }
        }
    }
}
