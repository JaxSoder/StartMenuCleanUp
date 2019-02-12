using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartMenuCleanUp1._0
{
    public partial class Form1 : Form
    {
        public static List<string> StartMenuList = new List<string>();
        public string SelectedItem;
        public string[] FileInfoPath2;

        int TotalInList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearBtn.Enabled  = false;
            InfoBtn.Enabled   = false;
            DeleteBtn.Enabled = false;

            Console.WriteLine(StartMenu.path);
        }
        
        public void SearchStartMenuBtn_Click(object sender, EventArgs e)
        {
            SearchStartMenuBtn.Enabled      = false;
            StartMenuListDisplay.DataSource = StartMenuList;
            StartMenu.GetStartMenu();
 

            UpdateTotalText();

            ClearBtn.Enabled  = true;
            InfoBtn.Enabled   = true;
            DeleteBtn.Enabled = true;
        }

        private void InfoBtn_Click(object sender, EventArgs e)
        {
            SetUpTest();
            UpdateInfoText();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            SetUpTest();

            foreach (string name in FileInfoPath2)
            {
                Console.WriteLine("Deleted = " + name);
                DeleteMessageBox(SelectedItem);
                File.Delete(name);
            }    
        }

        private void ClearBtn_Click_1(object sender, EventArgs e)
        {
            ClearListBox();
            ResetInfoText();
            ClearBtn.Enabled  = false;
            InfoBtn.Enabled   = false;
            DeleteBtn.Enabled = false;
        }

        void SetUpTest()
        {
            SelectedItem  = StartMenuListDisplay.GetItemText(StartMenuListDisplay.SelectedItem);
            FileInfoPath2 = Directory.GetFiles(@StartMenu.path, "*" + SelectedItem, SearchOption.AllDirectories);
        }

        void ClearListBox()
        {
            StartMenuListDisplay.DataSource = null;
            SearchStartMenuBtn.Enabled = true;
            StartMenuList.Clear();
            TotalText.Text = "0";
        }

        void ResetInfoText()
        {
            FileNameText.Text = "N/A";
            FilePathText.Text = "N/A";
        }

        void UpdateTotalText()
        {
            TotalInList    = StartMenuList.Count();
            TotalText.Text = TotalInList.ToString();
        }

        void UpdateInfoText()
        {
            foreach (string name in FileInfoPath2)
            {
                FileNameText.Text = SelectedItem;
                FilePathText.Text = name;
            }
        }

        void DeleteMessageBox(string item)
        {
            MessageBox.Show("Deleted " + item + " Restart the program when done deleting the programs you disire", "Deleted");
        }
    }
}
