// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer
{
    public partial class frmMapLayout : Form
    {
        public frmMapLayout(UnrealMap map)
        {
            InitializeComponent();
            this.map = map;
            Text = map.Title + " - Layout Top View";

            drawer = new MapDrawer(map);
            drawLayout();

            // Set warning label visibility
            lblWarning.Visible = (map.Brushes.Any(b => b.IsRotated || b.IsScaled));
        }

        private UnrealMap map;
        private MapDrawer drawer;

        private void drawLayout()
        {
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
    }
}
