// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UnrealMapMixer
{
    public partial class frmMapLayout : Form
    {
        public frmMapLayout(UnrealMap map)
        {
            InitializeComponent();
            this.map = map;
            drawer = new MapDrawer(map);
            drawLayout();
        }

        private UnrealMap map;
        private MapDrawer drawer;

        private void frmMapLayout_ResizeEnd(object sender, EventArgs e)
        {
            drawLayout();
        }

        private void drawLayout()
        {
            var bmp = new Bitmap(picLayout.Width, picLayout.Height);
            drawer.DrawLayout(Graphics.FromImage(bmp), picLayout.Width, picLayout.Height);
            picLayout.Image = bmp;
        }
    }
}
