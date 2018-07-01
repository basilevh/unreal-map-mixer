// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnrealMapMixer.Mixers;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer
{
    public partial class frmMapLayout : Form
    {
        public frmMapLayout(UnrealMap map)
        {
            // We are viewing an existing map
            InitializeComponent();
            this.map = map;
            Text = map.Title + " - Layout Top View";

            btnRedo.Visible = false;
            btnSave.Visible = false;

            finalInit();
        }

        public frmMapLayout(MapMixer mixer, MapMixParams mixParams)
        {
            // We are mixing into a new map
            InitializeComponent();
            this.mixer = mixer;
            this.mixParams = mixParams;
            Text = "Mixed Map - Layout Top View";
            mix();
            
            finalInit();
        }

        private void finalInit()
        {
            // Set warning label visibility
            lblWarning.Visible = (map.Brushes.Any(b => b.IsRotated || b.IsScaled));

            outputSaveDialog = new SaveFileDialog
            {
                Filter = "Unreal Text (T3D) File (*.t3d)|*.t3d",
                Title = "Specify destination file"
            };

            // Set game folder if found
            if (frmMain.UTPath != null)
                outputSaveDialog.InitialDirectory = frmMain.UTPath;

            drawLayout();
        }
        
        private UnrealMap map;
        private MapMixer mixer;
        private MapMixParams mixParams;
        private MapDrawer drawer;
        private SaveFileDialog outputSaveDialog;

        private void mix()
        {
            if (mixer == null)
                return;

            // Perform mix
            map = mixer.Mix(mixParams);
        }

        private void drawLayout()
        {
            if (map == null)
                return;

            drawer = new MapDrawer(map);
            var bmp = new Bitmap(picLayout.Width, picLayout.Height);
            drawer.DrawLayout(Graphics.FromImage(bmp), picLayout.Width, picLayout.Height);
            picLayout.Image = bmp;
        }

        private void frmMapLayout_ResizeEnd(object sender, EventArgs e)
        {
            drawLayout();
        }

        private void frmMapLayout_SizeChanged(object sender, EventArgs e)
        {
            tmrUpdate.Start();
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            tmrUpdate.Stop();
            drawLayout();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            mix();
            drawLayout();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (outputSaveDialog.ShowDialog() == DialogResult.OK)
                File.WriteAllText(outputSaveDialog.FileName, map.Text);
        }
    }
}
