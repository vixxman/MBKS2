namespace MBKS2_7
{
    partial class EditLabel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxUsersRank = new System.Windows.Forms.TextBox();
            this.comboBoxUsersList = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxFileRank = new System.Windows.Forms.TextBox();
            this.comboBoxFileList = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxUsersRank);
            this.groupBox1.Controls.Add(this.comboBoxUsersList);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users";
            // 
            // textBoxUsersRank
            // 
            this.textBoxUsersRank.Location = new System.Drawing.Point(147, 39);
            this.textBoxUsersRank.Name = "textBoxUsersRank";
            this.textBoxUsersRank.Size = new System.Drawing.Size(81, 20);
            this.textBoxUsersRank.TabIndex = 1;
            this.textBoxUsersRank.TextChanged += new System.EventHandler(this.textBoxUsersRank_TextChanged);
            // 
            // comboBoxUsersList
            // 
            this.comboBoxUsersList.FormattingEnabled = true;
            this.comboBoxUsersList.Items.AddRange(new object[] {
            "admin",
            "user1",
            "user2",
            "user3"});
            this.comboBoxUsersList.Location = new System.Drawing.Point(6, 39);
            this.comboBoxUsersList.Name = "comboBoxUsersList";
            this.comboBoxUsersList.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUsersList.TabIndex = 0;
            this.comboBoxUsersList.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsersList_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxFileRank);
            this.groupBox2.Controls.Add(this.comboBoxFileList);
            this.groupBox2.Location = new System.Drawing.Point(253, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 105);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Files";
            // 
            // textBoxFileRank
            // 
            this.textBoxFileRank.Location = new System.Drawing.Point(154, 39);
            this.textBoxFileRank.Name = "textBoxFileRank";
            this.textBoxFileRank.Size = new System.Drawing.Size(81, 20);
            this.textBoxFileRank.TabIndex = 2;
            this.textBoxFileRank.TextChanged += new System.EventHandler(this.textBoxFileRank_TextChanged);
            // 
            // comboBoxFileList
            // 
            this.comboBoxFileList.FormattingEnabled = true;
            this.comboBoxFileList.Location = new System.Drawing.Point(7, 38);
            this.comboBoxFileList.Name = "comboBoxFileList";
            this.comboBoxFileList.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFileList.TabIndex = 0;
            this.comboBoxFileList.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileList_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 156);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditLabel";
            this.Text = "EditLabel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxUsersList;
        private System.Windows.Forms.ComboBox comboBoxFileList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxUsersRank;
        private System.Windows.Forms.TextBox textBoxFileRank;
    }
}