using System;
using System.IO;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string myFolder = "Документация";

            string basePath = Application.StartupPath;

            string fullPath = Path.Combine(basePath, myFolder);

            if (!Directory.Exists(fullPath))
            {
                DialogResult result = MessageBox.Show("Директория не существует. Хотите создать её?", "Создание директории", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Directory.CreateDirectory(fullPath);
                }
                else
                {
                    return;
                }
            }
            DirectoryInfo dirInfo = new DirectoryInfo(fullPath);

            treeView1.Nodes.Clear();

            TreeNode rootNode = treeView1.Nodes.Add(myFolder);

            rootNode.Name = fullPath;

            AddTreeNode(rootNode, dirInfo);
        }

        private void AddTreeNode(TreeNode treeNode, DirectoryInfo dirInfo)
        {
            foreach (var directory in dirInfo.GetDirectories())
            {
                TreeNode myNode = treeNode.Nodes.Add(directory.Name);
                myNode.Name = directory.FullName;
                AddTreeNode(myNode, directory);
            }

            foreach (var file in dirInfo.GetFiles())
            {
                TreeNode myNode = treeNode.Nodes.Add(file.Name);
                myNode.Name = file.FullName;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string filePath = e.Node.Name;

            if (File.Exists(filePath))
            {
                axAcroPDF1.src = filePath;
                axAcroPDF1.setView("FitH");
                axAcroPDF1.setShowToolbar(false);
            }
        }
    }
}