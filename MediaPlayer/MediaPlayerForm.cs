using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class frmMediaPlayer : Form
    {
        public frmMediaPlayer()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdVideoFile.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer.close();
                axWindowsMediaPlayer.URL = ofdVideoFile.FileName;
                axWindowsMediaPlayer.Ctlcontrols.play();
                addBookmarkToolStripMenuItem.Enabled = true;
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmiBookmark = new ToolStripMenuItem();
            tsmiBookmark.Tag = axWindowsMediaPlayer.Ctlcontrols.currentPosition;
            tsmiBookmark.Text = "Bookmark " + (gotoToBookmarkToolStripMenuItem.DropDownItems.Count + 1).ToString() + 
                " [" + axWindowsMediaPlayer.Ctlcontrols.currentPositionString + "]";
            tsmiBookmark.Click += BookmarkStripMenuItem_Click;
            gotoToBookmarkToolStripMenuItem.DropDownItems.Add(tsmiBookmark);
            gotoToBookmarkToolStripMenuItem.Enabled = true;
            clearAllToolStripMenuItem.Enabled = true;
        }

        private void BookmarkStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.Ctlcontrols.currentPosition = (double)(sender as ToolStripMenuItem).Tag;
        }

        private void FrmMediaPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            axWindowsMediaPlayer.close();
        }

        private void ClearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gotoToBookmarkToolStripMenuItem.DropDownItems.Clear();
            gotoToBookmarkToolStripMenuItem.Enabled = false;
            clearAllToolStripMenuItem.Enabled = false;
        }
    }
}
