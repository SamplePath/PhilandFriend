using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDate;



namespace TestBed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdGetDate_Click(object sender, EventArgs e)
        {


            DateTime dt1 = DateTime.Now.DateAdd(Ext_Date.DataAddPart.Year, -1);
            DateTime dt2 = DateTime.Now.DateAdd(Ext_Date.DataAddPart.Month, -1);
            DateTime dt3 = DateTime.Now.DateAdd(Ext_Date.DataAddPart.Day, 51);
            DateTime dt4 = DateTime.Now.DateAdd(Ext_Date.DataAddPart.Day, -54);




        }
    }
}
