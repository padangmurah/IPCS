﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;

namespace IPCS.Panels
{
    public partial class PnlTab : UserControl
    {
        #region Constructor

        public PnlTab()
        {
            InitializeComponent();
        }

        #endregion

        #region Threads

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblTab.ForeColor = SystemColors.ControlDarkDark;
            pictureBoxTab.Image = Image;
            lblTab.Text = TabText;
            WireAllControls(this);
            Application.DoEvents();
        }

        #endregion

        #region Properties

        [Category("Appearance"), Browsable(true)]
        [Description("Tab text")]
        public string TabText { get; set; }

        [Category("Appearance"), Browsable(true)]
        [Description("Default image")]
        public Image Image { get; set; }

        [Category("Appearance"), Browsable(true)]
        [Description("Image for dark theme")]
        public Image DarkThemeImage { get; set; }

        [Category("Appearance"), Browsable(true)]
        [Description("Image for light theme")]
        public Image LightThemeImage { get; set; }

        #endregion

        #region Extension

        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.Click += ctl_Click;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
        }

        private void ctl_Click(object sender, EventArgs e)
        {
            InvokeOnClick(this, EventArgs.Empty);
        }

        private void Tab_Enter(object sender, EventArgs e)
        {
            if (pnlMetroTab.Theme == MetroThemeStyle.Light) lblTab.ForeColor = Color.Black;
            else lblTab.ForeColor = Color.White;
            if (pnlMetroTab.Theme == MetroThemeStyle.Light) pictureBoxTab.Image = LightThemeImage;
            else pictureBoxTab.Image = DarkThemeImage;
        }

        private void Tab_Leave(object sender, EventArgs e)
        {
            lblTab.ForeColor = SystemColors.ControlDarkDark;
            pictureBoxTab.Image = Image;
        }

        #endregion
    }
}
