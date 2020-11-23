using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace MBKS2_7
{
    public partial class Form1 : Form
    {
        string SelectedUser = "";
        string Path = "";
        DirectorySecurity Dirsec;
        public List<string> AllFiles = new List<string>();
        //public List<string> AllDir = new List<string>() { {"D:\\Matrix" }, { "D:\\Matrix\\1" }, { "D:\\Matrix\\2" } , { "D:\\Matrix\\1\\1" } };
        public Label rules;
        int rule = 0;
        string pathFile = "";


        public Form1()
        {
            InitializeComponent();
        }

        public string SelectedUser1 { get => SelectedUser; set => SelectedUser = value; }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm(this);
            lf.ShowDialog();
            this.Text = "Welcome " + SelectedUser;
            if (SelectedUser != "admin")
            {
                button2.Enabled = false;
            }
            richTextBox1.Enabled = false;
            button4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            textBox1.Text = Path = dialog.SelectedPath;
            Dirsec = Directory.GetAccessControl(Path);
            //UnlockDir(Path);
            treeView1.Nodes.Clear();
            TreeNode dirNode = new TreeNode();
            treeView1.Nodes.Add(Path);
            FillTreeNode(treeView1.Nodes[0], Path);
            AllFiles.Add(Path + "\\Label.txt");
            rules = new Label(AllFiles);
            writeRules(rules);
            LockDir(Path);
        }

        public void writeRules(Label rules)
        {
            this.rules = rules;
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream(Path + "\\Label.txt", FileMode.Create))
            {
                formatter.Serialize(fs, rules);
                fs.Close();
            }
        }


        private void FillTreeNode(TreeNode driveNode, string path)
        {
            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            if (files.Length != 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    AllFiles.Add(files[i]);
                }
            }
            if (dirs.Length == 0) { return; }

            for (int i = 0; i < dirs.Length; i++)
            {
                //if (!dirs.Contains(dirs[i])) dirs.Add(dirs[i]);
                TreeNode dirNode = new TreeNode();
                dirNode.Text = dirs[i].Remove(0, dirs[i].LastIndexOf("\\") + 1);
                driveNode.Nodes.Add(dirNode);
                FillTreeNode(dirNode, dirs[i]);
            }
        }

        private string getFullPath(TreeNode node)
        {
            string str = "";
            if (node.Text != Path)
            {

                str = str.Insert(0, getFullPath(node.Parent));
                str += node.Text;
                str += "\\";
            }
            else
            {
                str = str.Insert(0, Path);
                str += "\\";
            }
            return str;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            listView1.Clear();
            string fullPath = getFullPath(e.Node);
            UnlockDir(Path);
            string[] files = Directory.GetFiles(fullPath);
            for (int i = 0; i < files.Length; i++)
            {
                if (!AllFiles.Contains(files[i])) AllFiles.Add(files[i]);
                ListViewItem lvi = new ListViewItem();
                lvi.Text = files[i].Remove(0, files[i].LastIndexOf('\\') + 1);
                lvi.ImageIndex = 0;
                listView1.Items.Add(lvi);
            }
            LockDir(Path);
        }

        private void LockDir(string Path)
        {
            FileSystemAccessRule fsa = new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny);
            //FileSystemAccessRule fsa = new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Deny);
            Dirsec.AddAccessRule(fsa);
            Directory.SetAccessControl(Path, Dirsec);

        }

        private void UnlockDir(string Path)
        {
            FileSystemAccessRule fsa = new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny);
            //FileSystemAccessRule fsa = new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.InheritOnly, AccessControlType.Deny);
            Dirsec.RemoveAccessRule(fsa);
            Directory.SetAccessControl(Path, Dirsec);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            UnlockDir(Path);
            string[] Files = Directory.GetFiles(Path, listView1.SelectedItems[0].SubItems[0].Text, SearchOption.AllDirectories);
            pathFile = Files[0];
            checkRule(pathFile);
            if (rule > 0)
            {
                FileInfo info = new FileInfo(pathFile);
                Process proc = new Process();
                info.Attributes = FileAttributes.ReadOnly;
                proc.StartInfo.FileName = info.FullName;
                proc.Start();
                LockDir(Path);
                while (!proc.HasExited)
                {
                    System.Threading.Thread.Sleep(2000);
                }
                info.Attributes = FileAttributes.Normal;
            }
            if (rule < 0)
            {
                MessageBox.Show("Чтение недоступно! Воспользуйтесь формой снизу для добавления в начало");
                richTextBox1.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                FileInfo info = new FileInfo(pathFile);
                Process proc = new Process();
                info.Attributes = FileAttributes.ReadOnly;
                proc.StartInfo.FileName = info.FullName;
                proc.Start();
                LockDir(Path);
                while (!proc.HasExited)
                {
                    System.Threading.Thread.Sleep(2000);
                }
                info.Attributes = FileAttributes.Normal;
                richTextBox1.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditLabel em = new EditLabel(this);
            em.ShowDialog();
        }

        private void checkRule(string path)
        {
            if (SelectedUser == "admin")
            {
                if (rules.users[0] > rules.files[AllFiles.IndexOf(path)])
                {
                    rule = 1;
                }
                else
                {
                    if (rules.users[0] < rules.files[AllFiles.IndexOf(path)])
                    {
                        rule = -1;
                    }
                    else rule = 0;
                }
            }
            if (SelectedUser == "user1")
            {
                if (rules.users[1] > rules.files[AllFiles.IndexOf(path)])
                {
                    rule = 1;
                }
                else
                {
                    if (rules.users[1] < rules.files[AllFiles.IndexOf(path)])
                    {
                        rule = -1;
                    }
                    else rule = 0;
                }
            }
            if (SelectedUser == "user2")
            {
                if (rules.users[2] > rules.files[AllFiles.IndexOf(path)])
                {
                    rule = 1;
                }
                else
                {
                    if (rules.users[2] < rules.files[AllFiles.IndexOf(path)])
                    {
                        rule = -1;
                    }
                    else rule = 0;
                }
            }
            if (SelectedUser == "user3")
            {
                if (rules.users[3] > rules.files[AllFiles.IndexOf(path)])
                {
                    rule = 1;
                }
                else
                {
                    if (rules.users[3] < rules.files[AllFiles.IndexOf(path)])
                    {
                        rule = -1;
                    }
                    else rule = 0;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm(this);
            lf.ShowDialog();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            UnlockDir(Path);
            string[] Files = Directory.GetFiles(Path, listView1.SelectedItems[0].SubItems[0].Text, SearchOption.AllDirectories);
            pathFile = Files[0];
            FileStream fs = new FileStream(pathFile, FileMode.Open);
            byte[] tmpb=new byte[1000];
            fs.Read(tmpb, 0,1000);
            fs.Close();
            File.Delete(pathFile);
            FileStream fs2 = new FileStream(pathFile, FileMode.CreateNew);
            byte[] bt = Encoding.Default.GetBytes(richTextBox1.Text + "\r\n");
            byte[] trb = new byte[tmpb.Length + bt.Length];
            bt.CopyTo(trb, 0);
            tmpb.CopyTo(trb, bt.Length);
            fs2.Write(trb, 0, trb.Length);
            fs2.Close();
            LockDir(Path);
            richTextBox1.Clear();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            UnlockDir(Path);
            string[] Files = Directory.GetFiles(Path, listView1.SelectedItems[0].SubItems[0].Text, SearchOption.AllDirectories);
            pathFile = Files[0];
            checkRule(pathFile);
            if (rule < 0 || rule == 0)
            {
                richTextBox1.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                richTextBox1.Clear();
                richTextBox1.Enabled = false;
                button4.Enabled = false;
            }
            LockDir(Path);
        }
    }
}
