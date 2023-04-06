namespace MyNotePad
{
    using System;
    using System.Windows.Forms;
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            Preparing();
        }
        private bool Preparing()
        {
            bool res = false;
            CenterToScreen();
            return res;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAboutBox fAbout = new FrmAboutBox();
            fAbout.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult r = ofd.ShowDialog();

            if(r == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                richTextBox1.Text =  new CFileDataReader(filePath, new EncodingDetecter(filePath)).ReadText();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult r = sfd.ShowDialog();

            if (r == DialogResult.OK)
            {
                string dstPath = sfd.FileName;
                if (!(new CFileDataWriter(dstPath, EncodingType.ASCII).WriteText(System.Text.Encoding.ASCII.GetBytes(richTextBox1.Text))))
                {
                    MessageBox.Show("OPPS, SOMETHING WENT WRONG :(");
                }
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            DialogResult r = fd.ShowDialog();

            if(r== DialogResult.OK)
            {
                richTextBox1.Font = fd.Font;
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                DialogResult r = MessageBox.Show("Do you want to save befor exit ? ", "MyNotePad", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(sender, new EventArgs());
                }
            }
        }
    }
}
