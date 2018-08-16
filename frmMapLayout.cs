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
using UnrealMapMixer.MyMath;
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

            // Update controls
            Text = map.Title + " - Layout Top View";
            pnlMixOnly.Visible = false;

            FinalInit();
        }

        public frmMapLayout(MapMixer mixer, MapMixParams mixParams)
        {
            // We are mixing into a new map
            InitializeComponent();
            sourceMaps = mixer.Maps.ToArray();
            this.mixer = mixer;
            this.mixParams = mixParams;

            // Perform mix
            Mix();

            // Update controls
            Text = "Mixed Map - Layout Top View";
            cmbSourceMap.Items.AddRange(sourceMaps.Select(m => Path.GetFileName(m.FilePath)).ToArray());
            cmbSourceMap.SelectedIndex = 0;
            UpdateSourceMapControls();

            FinalInit();
        }

        private void FinalInit()
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

            DrawLayout();
        }

        private UnrealMap[] sourceMaps; // mixing mode only
        private UnrealMap map;
        private MapMixer mixer;
        private MapMixParams mixParams;
        private MapDrawer drawer;
        private Bitmap bitmap;
        private UnrealMap importantMap = null, draggedMap = null;
        private SaveFileDialog outputSaveDialog;

        private void Mix()
        {
            if (mixer == null)
                return;

            // Perform mix
            map = mixer.Mix(mixParams);

            DrawLayout();
        }

        private void DrawLayout()
        {
            if (map == null || picLayout.Width <= 0 || picLayout.Height <= 0)
                return;

            // Recreate bitmap if needed
            if (bitmap == null || bitmap.Width != picLayout.Width || bitmap.Height != picLayout.Height)
                bitmap = new Bitmap(picLayout.Width, picLayout.Height);

            // Get correct view
            MapDrawer.View view;
            if (radTop.Checked)
                view = MapDrawer.View.Top;
            else if (radFront.Checked)
                view = MapDrawer.View.Front;
            else
                view = MapDrawer.View.Side;

            // Draw layout
            if (drawer == null)
                drawer = new MapDrawer(map);
            drawer.DrawLayout(Graphics.FromImage(bitmap), bitmap.Width, bitmap.Height,
                view, importantMap, draggedMap);
            picLayout.Image = bitmap;
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            Mix();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (outputSaveDialog.ShowDialog() == DialogResult.OK)
                File.WriteAllText(outputSaveDialog.FileName, map.Text);
        }

        #region Layout drawing details

        private void frmMapLayout_ResizeEnd(object sender, EventArgs e)
        {
            DrawLayout();
        }

        private void frmMapLayout_SizeChanged(object sender, EventArgs e)
        {
            tmrUpdate.Start();
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            tmrUpdate.Stop();
            DrawLayout();
        }

        private void radTop_CheckedChanged(object sender, EventArgs e)
        {
            DrawLayout();
        }

        private void radFront_CheckedChanged(object sender, EventArgs e)
        {
            DrawLayout();
        }

        private void radSide_CheckedChanged(object sender, EventArgs e)
        {
            DrawLayout();
        }

        #endregion

        #region Source map controls

        private void cmbSourceMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSourceMapControls();

            // Mark the selected source map by a short flash
            importantMap = sourceMaps[cmbSourceMap.SelectedIndex];
            DrawLayout();
            tmrFlash.Stop();
            tmrFlash.Start();
        }

        private void UpdateSourceMapControls()
        {
            if (mixer == null)
                return;

            string path = sourceMaps[cmbSourceMap.SelectedIndex].FilePath;
            var offset = mixParams.MapOffsets[path];
            numX.Value = (decimal)offset.X;
            numY.Value = (decimal)offset.Y;
            numZ.Value = (decimal)offset.Z;
        }

        private void tmrFlash_Tick(object sender, EventArgs e)
        {
            tmrFlash.Stop();
            importantMap = null;
            DrawLayout();
        }

        private void numX_ValueChanged(object sender, EventArgs e)
        {
            UpdateSourceMap();
        }

        private void numY_ValueChanged(object sender, EventArgs e)
        {
            UpdateSourceMap();
        }

        private void numZ_ValueChanged(object sender, EventArgs e)
        {
            UpdateSourceMap();
        }

        private void UpdateSourceMap()
        {
            if (mixer == null)
                return;

            string path = sourceMaps[cmbSourceMap.SelectedIndex].FilePath;
            var offset = new Vector3D((double)numX.Value, (double)numY.Value, (double)numZ.Value);
            mixParams.MapOffsets[path] = offset;

            // TODO: move brushes (marked with source tag) in destination only,
            // as this will mess up random generations
            Mix();
        }

        private bool dragging = false;
        private int startX, startY;

        private void picLayout_MouseMove(object sender, MouseEventArgs e)
        {
            if (mixer == null)
                return;

            if (e.Button == MouseButtons.Left && !dragging)
            {
                startX = e.X;
                startY = e.Y;
                dragging = true;
            }
            else if (dragging && e.Button != MouseButtons.Left)
            {
                dragging = false;
                if (drawer == null)
                    return;

                // Add the dragged offset to the selected source map, rounding to multiples of 64 units
                int deltaX = e.X - startX;
                int deltaY = e.Y - startY;
                double unitsX = deltaX / drawer.PixelsPerUnit;
                double unitsY = deltaY / drawer.PixelsPerUnit;
                decimal roundX = (decimal)(Math.Round(((double)numX.Value + unitsX) / 64.0) * 64.0);
                decimal roundY = (decimal)(Math.Round(((double)numY.Value + unitsY) / 64.0) * 64.0);
                numX.Value = Math.Min(Math.Max(roundX, numX.Minimum), numX.Maximum);
                numY.Value = Math.Min(Math.Max(roundY, numY.Minimum), numY.Maximum);
            }
        }

        #endregion
    }
}
