using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsEightNoatpad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
            this.Text = "Untitled Notepad";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.TextLength == 0)
            {
                open();
            }

            else
                if (MessageBox.Show("Do you want to save this?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    richTextBox.Clear();
                    open();
                }
                else
                {
                    saveoption();
                    open();                
                }             
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveoption();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveoption();
        }

        void open()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open";
            open.FileName = "";
            open.Filter = "Text Files|*.txt|All Files|*.*";

            if (open.ShowDialog() != DialogResult.Cancel)
            {
                System.IO.StreamReader strread = new System.IO.StreamReader(open.FileName);
                richTextBox.Text = strread.ReadToEnd();
                strread.Close();
            }
        }


        public void saveoption()
        {
            SaveFileDialog save = new SaveFileDialog();
            String filename = save.FileName;
            String filter = "Text Files|*.txt|All Files|*.*";
            save.Filter = filter;
            save.Title = "Save";

            if (save.ShowDialog() != DialogResult.Cancel)
            {
                System.IO.StreamWriter strwri = new System.IO.StreamWriter(save.FileName);
                {
                    strwri.Write(richTextBox.Text);
                    strwri.Close();
                }
            }

        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.TextLength != 0)

                if (MessageBox.Show("Do you want to save this?", "Warning",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    Application.Exit();
                }
                else
                {
                    saveoption();

                }
            else
                Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText != "")
            {
                richTextBox.Cut();
            }
        }

        private void copyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }
        private void pasteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }     

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {           
                richTextBox.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();      
        }
      
        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text += Convert.ToString(DateTime.Now);
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.TextLength == 0)
            {
                undoToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                undoToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog word = new FontDialog();
            if (word.ShowDialog() == DialogResult.OK)
            {
                richTextBox.Font = new Font(word.Font.Name, word.Font.Size, word.Font.Style);
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutNotepad about = new aboutNotepad();
            about.ShowDialog();
        }

        private void d(object sender, EventArgs e)
        {

        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
      
    }
}