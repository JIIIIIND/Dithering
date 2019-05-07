using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ConsoleApp2
{
    class Program : Form
    {
        private PictureBox pictureBox;
        private GroupBox groupBox;
        private Button button1;
        private Button button4;
        private Button button3;
        private Button button2;
        private TreeView treeView1;
        private TreeNode root;
        private static ArrayList imagePath;
        private Button ImageSetting;
        private static string[] all_dir;
        public static string[] All_dir
        {
            get { return all_dir; }
            set { all_dir = value; }
        }
        private static int count;
        private string imageName;
        private Label label1;
        private Bitmap TransImage;

        static void Main(string[] args)
        {
            count = 0;
            imagePath = new ArrayList();
            Program p = new Program();
            p.InitializeComponent();
            p.tree();
            Application.Run(p);

        }
        private void tree()
        {
            All_dir = Directory.GetLogicalDrives();
            foreach (string file in all_dir)
            {
                try
                {
                    root = new TreeNode(file);
                    root.Name = file.ToString();
                    treeView1.Nodes.Add(root);
                    Directory_Searching(file, all_dir, root);
                }
                catch (UnauthorizedAccessException e)
                { }
            }
        }
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.ImageSetting = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.HotTracking = true;
            this.treeView1.Location = new System.Drawing.Point(66, 125);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(274, 646);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeSelect);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.ImageSetting);
            this.groupBox.Controls.Add(this.button4);
            this.groupBox.Controls.Add(this.button3);
            this.groupBox.Controls.Add(this.button2);
            this.groupBox.Controls.Add(this.button1);
            this.groupBox.Location = new System.Drawing.Point(66, 777);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(274, 178);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "디더링 종류 선택";
            // 
            // ImageSetting
            // 
            this.ImageSetting.Cursor = System.Windows.Forms.Cursors.Default;
            this.ImageSetting.Location = new System.Drawing.Point(86, 141);
            this.ImageSetting.Name = "ImageSetting";
            this.ImageSetting.Size = new System.Drawing.Size(94, 31);
            this.ImageSetting.TabIndex = 5;
            this.ImageSetting.Text = "Image Set";
            this.ImageSetting.UseVisualStyleBackColor = true;
            this.ImageSetting.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(155, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 51);
            this.button4.TabIndex = 6;
            this.button4.Text = "Error-Diffusion";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(155, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 31);
            this.button3.TabIndex = 5;
            this.button3.Text = "Random";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 51);
            this.button2.TabIndex = 4;
            this.button2.Text = "Pattern";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Conventional";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.ImageLocation = "C:\\Users\\user\\Pictures\\sample";
            this.pictureBox.Location = new System.Drawing.Point(400, 125);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1477, 830);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F);
            this.label1.ForeColor = System.Drawing.SystemColors.Menu;
            this.label1.Location = new System.Drawing.Point(958, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "이미지 변환 중입니다";
            // 
            // Program
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pictureBox);
            this.Name = "Program";
            this.Text = "Dithering";
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Directory_Searching(string path, string[] dir, TreeNode root)
        {
            if (Directory.GetDirectories(path) != null)
            {
                dir = null;
                dir = Directory.GetDirectories(path);
                string[] dir2 = null;

                foreach (string file in dir)
                {
                    try
                    {
                        DirectoryInfo di = new DirectoryInfo(file);

                        TreeNode child = new TreeNode(di.Name);
                        child.Name = di.Name;
                        if (root.Nodes.Find(child.Name, false).Length == 0)
                            root.Nodes.Add(child);
                        dir2 = Directory.GetDirectories(file);
                        foreach (string child_dir in dir2)
                        {
                            DirectoryInfo di2 = new DirectoryInfo(child_dir);
                            TreeNode grandchild = new TreeNode(di2.Name);
                            grandchild.Name = di2.Name;

                            TreeNode[] Tarray = root.Nodes.Find(child.Name, false);
                            if (Tarray[0].Nodes.Find(grandchild.Name, false).Length == 0)
                                Tarray[0].Nodes.Add(grandchild);
                            else
                                child.Nodes.Add(grandchild);
                        }
                    }
                    catch (UnauthorizedAccessException e)
                    { }
                }
            }
        }
        private void TreeSelect(object sender, TreeViewEventArgs e)
        {
            imagePath.Clear();
            try
            {
                string nodeKey = e.Node.FullPath;

                Directory_Searching(nodeKey, All_dir, e.Node);
                imagePath.AddRange(Directory.GetFiles(nodeKey, "*.jpg", SearchOption.AllDirectories));
                imagePath.AddRange(Directory.GetFiles(nodeKey, "*.png", SearchOption.AllDirectories));
                imagePath.AddRange(Directory.GetFiles(nodeKey, "*.bmp", SearchOption.AllDirectories));
            }
            catch (UnauthorizedAccessException error)
            { }
            catch (FormatException error)
            { }
        }

        private void button6_Click(object sender, EventArgs e)  //ImageSetting
        {
            Random rand = new Random();
            imageName = imagePath[rand.Next(imagePath.Count)].ToString();
            
            pictureBox.Image = Image.FromFile(imageName);
            Console.WriteLine(imageName);
        }

        private void button1_Click(object sender, EventArgs e)  //Conventional
        {
            Random rand = new Random();
            if (imageName != null)
            {
                this.label1.ForeColor = SystemColors.ControlDark;
                TransImage = (Bitmap)Image.FromFile(imageName);
                Convention conv = new Convention(TransImage);
                pictureBox.Image = conv.Dithering(80);
                
                this.label1.ForeColor = SystemColors.Menu;
            }
            else
                MessageBox.Show("이미지 파일이 선택되지 않았습니다");
        }

        private void button2_Click(object sender, EventArgs e)  //Pattern
        {
            if (imageName != null)
            {
                this.label1.ForeColor = SystemColors.ControlDark;
                TransImage = (Bitmap)Image.FromFile(imageName);
                Pattern pattern = new Pattern(TransImage);
                pictureBox.Image = pattern.Dithering();
                this.label1.ForeColor = SystemColors.Menu;
            }
            else
                MessageBox.Show("이미지 파일이 선택되지 않았습니다.");
        }

        private void button4_Click(object sender, EventArgs e)  //Erro_Diffusion
        {
            if (imageName != null)
            {
                this.label1.ForeColor = SystemColors.ControlDark;
                TransImage = (Bitmap)Image.FromFile(imageName);
                ErrorDiffusion ed = new ErrorDiffusion(TransImage);
                pictureBox.Image = ed.Dithering();
                this.label1.ForeColor = SystemColors.Menu;
            }
            else
                MessageBox.Show("이미지 파일이 선택되지 않았습니다.");

        }

        private void button3_Click(object sender, EventArgs e)  //Random
        {
            if (imageName != null)
            {
                this.label1.ForeColor = SystemColors.Desktop;
                TransImage = (Bitmap)Image.FromFile(imageName);
                RandomDither rd = new RandomDither(TransImage);
                pictureBox.Image = rd.Dithering();
                this.label1.ForeColor = SystemColors.Menu;
            }
            else
                MessageBox.Show("이미지 파일이 선택되지 않았습니다.");

        }

    }
}
