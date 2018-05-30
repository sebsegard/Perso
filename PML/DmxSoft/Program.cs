using System;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DmxSoft
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //MessageBox.Show("test");

            //DmxSoft.Forms.WaitForm W = new DmxSoft.Forms.WaitForm();
           // W.Show();
            Main Pml = new Main();
            /*System.Threading.Thread thr = new Thread(new ThreadStart(Pml.Init));
            thr.Start();
            thr.Join();*/
            Pml.Init();
            //W.Close();

            Application.Run(Pml);
        }
    }
}