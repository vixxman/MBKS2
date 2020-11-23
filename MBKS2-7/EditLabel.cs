using System;
using System.Windows.Forms;

namespace MBKS2_7
{
    public partial class EditLabel : Form
    {
        Form1 f;
        Label m;
        public EditLabel(Form1 f)
        {
            InitializeComponent();
            this.f = f;
            m = f.rules;
            for (int i = 0; i < f.AllFiles.Count; i++)
            {
                comboBoxFileList.Items.Add(f.AllFiles[i]);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            f.rules = m;
            f.writeRules(m);
            Dispose();
        }

        private void comboBoxUsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxUsersRank.Text = m.users[comboBoxUsersList.SelectedIndex].ToString();
        }

        private void comboBoxFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFileRank.Text = m.files[comboBoxFileList.SelectedIndex].ToString();
        }

        private void textBoxUsersRank_TextChanged(object sender, EventArgs e)
        {
            m.users[comboBoxUsersList.SelectedIndex] = Int32.Parse(textBoxUsersRank.Text);
        }

        private void textBoxFileRank_TextChanged(object sender, EventArgs e)
        {
            m.files[comboBoxFileList.SelectedIndex] = Int32.Parse(textBoxFileRank.Text);
        }
    }
}
