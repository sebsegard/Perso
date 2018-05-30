using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace DmxCreator.Dialog
{
    public partial class ImageBrowser : Form
    {
        private string mStartAddress = "";
        private List<string> mImageList;
        private Thread mLoadingThread = null;
        private string mCurrentPath = "";

        public static string LastPath = Application.StartupPath;

        private string mSelectedImage = null;
        
        public ImageBrowser()
        {
            InitializeComponent();
            mImageList = new List<string>();


            mStartAddress = Application.StartupPath;

            mCurrentPath = mStartAddress;

            this.folderExplorer1.LoadPath(mStartAddress);
            this.folderExplorer1.OnPathSelected += new DmxCreator.Control.OnPathSelectedEvent(folderExplorer1_OnPathSelected);
            mLoadingThread = new Thread(new ThreadStart(LoadImages));
            mLoadingThread.Start();
        }

        public ImageBrowser(string pPath)
        {
               

            
            InitializeComponent();

            if (pPath != null &&  pPath!="" && File.Exists(pPath))
            {
                FileInfo file = new FileInfo(pPath);
                mSelectedImage = file.FullName;
                mStartAddress = file.DirectoryName;
                
            }
            else
            {
                mStartAddress = ImageBrowser.LastPath;
            }
            mImageList = new List<string>();
            mCurrentPath = mStartAddress;

            this.folderExplorer1.LoadPath(mStartAddress);
            this.folderExplorer1.OnPathSelected += new DmxCreator.Control.OnPathSelectedEvent(folderExplorer1_OnPathSelected);
            mLoadingThread = new Thread(new ThreadStart(LoadImages));
            mLoadingThread.Start();
        }

        public void SelectImage(string pImagePath)
        {
            if (pImagePath == null || pImagePath == "")
                return;
       
            FileInfo file = new FileInfo(pImagePath);
            
            if (file.DirectoryName != mCurrentPath)
            {
                mStartAddress = file.DirectoryName;
                mCurrentPath = mStartAddress;

                this.folderExplorer1.LoadPath(mStartAddress);
                this.folderExplorer1.OnPathSelected += new DmxCreator.Control.OnPathSelectedEvent(folderExplorer1_OnPathSelected);
                mLoadingThread = new Thread(new ThreadStart(LoadImages));
                mLoadingThread.Start();
            }

        }


        public string SelectedImage
        {
            get { return mSelectedImage; }
        }

        void folderExplorer1_OnPathSelected(string Path)
        {
            if (mLoadingThread.IsAlive)
            {
                mLoadingThread.Abort();
                mLoadingThread.Join();
            }
            
            mCurrentPath = Path;
            
            mLoadingThread = new Thread(new ThreadStart(LoadImages));
            mLoadingThread.Start();
        }

        public void LoadImages()
        {
            if (!Directory.Exists(mCurrentPath))
            {
                return;
            }
            int i = 0;
            mImageList = new List<string>();
            listview1.Items.Clear();
            imageList1.Images.Clear();
            imageList1.ImageSize = new Size(32, 32);
            string[] files = GetFiles(mCurrentPath, "*.jpg;*.png;*.bmp;*.gif");
            int selectedIndex =-1;

            this.progressBar1.Value = 0;

            if (files.Length == 0)
                return;


            int step = 100/files.Length;
            if(files.Length>=100) 
                step = files.Length / 100;
           
            int NextStep = step;

            this.progressBar1.Value = 0;
            foreach (string fileName in files)
            {
                Image img = Image.FromFile(fileName);
                DirectoryInfo dinfo = new DirectoryInfo(fileName);
                imageList1.Images.Add(dinfo.Name, img);
                
                mImageList.Add(fileName);

                if (fileName == mSelectedImage)
                    selectedIndex = i;

                i++;
                if (i >= NextStep && this.progressBar1.Value<100)
                {
                    this.progressBar1.Value++;
                    
                    NextStep += step;
                }
            }
            this.progressBar1.Value = 0;
            NextStep = step;
            for (i = 0; i < imageList1.Images.Count && i < mImageList.Count; i++)
            { 
                DirectoryInfo dinfo = new DirectoryInfo(mImageList[i]);
                ListViewItem item = listview1.Items.Add(dinfo.Name, i);
                item.Tag = mImageList[i];
                if (i >= NextStep && this.progressBar1.Value<100)
                {
                    this.progressBar1.Value++;
                    
                    NextStep += step;
                }
            }
            if(selectedIndex!=-1)
                listview1.Items[selectedIndex].Selected = true;
            this.progressBar1.Value = 100;
        }


        private delegate void AddImageinListDelegate(string pName, int pIndex, string pFileName);

        private void AddImageinList(string pName, int pIndex, string pFileName)
        {
            if (this.listview1.InvokeRequired)
            {
                this.listview1.Invoke(new AddImageinListDelegate(this.AddImageinList), new object[] { pName, pIndex, pFileName });
            }
            else
            {
                ListViewItem item = listview1.Items.Add(pName, pIndex);
                item.Tag = pFileName;
            }
        }

        public string[] GetFiles(string imageFolder, string filter)
        {
            List<string> list = new List<string>();
            string[] tokens = filter.Split(new char[1] { ';' });
            foreach (string wildcard in tokens)
            {
                list.AddRange(Directory.GetFiles(imageFolder, wildcard));
            }
            string[] arr = new string[list.Count];
            list.CopyTo(arr);
            return arr;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (mLoadingThread.IsAlive)
            {
                mLoadingThread.Abort();
                mLoadingThread.Join();
                this.mSelectedImage = null;
            }
            if (this.listview1.SelectedItems != null && this.listview1.SelectedItems.Count != 0)
            {
                //this.listview1.SelectedItems[0];
                this.mSelectedImage = (string)(this.listview1.SelectedItems[0].Tag);
            }
            else
                this.mSelectedImage = null;
            this.DialogResult = DialogResult.OK;
            ImageBrowser.LastPath = mCurrentPath;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (mLoadingThread.IsAlive)
            {
                mLoadingThread.Abort();
                mLoadingThread.Join();
            }
            this.mSelectedImage = null;
            Close();
        }

        private void listview1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

       

       
    }
}