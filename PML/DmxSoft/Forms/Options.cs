using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DmxSoft.Forms
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            this.propertyGrid1.SelectedObject = Main.Options;
        }
    }
}