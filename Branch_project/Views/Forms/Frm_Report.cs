using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Branch_project.Models;
using Branch_project.Logic.Services;
using Branch_project.Views.Reports;

namespace Branch_project.Views.Forms
{
    public partial class Frm_Report : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Report()
        {
            InitializeComponent();
        }


        

        private void Frm_Report_Load(object sender, EventArgs e)
        {
             List<File_Branch_view> ListItem;

        ListItem =   DbHelper.ExecuteSP<File_Branch_view>("vm_Branch", null);

            
            XtraReport1.Print(ListItem);
            


        }
    }
}