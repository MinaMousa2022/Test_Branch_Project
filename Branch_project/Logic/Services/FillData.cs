using Branch_project.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branch_project.Logic.Services
{
    public static class FillData
    {

        public static void AdbptLookupEdit(this LookUpEdit lkp_Currency,object Data , string DiplayMember , string ValueMember)
        {
            //lkp_Currency.Properties.BeginInit();
            lkp_Currency.Properties.DataSource = Data;
            lkp_Currency.Properties.ValueMember = ValueMember;
            lkp_Currency.Properties.DisplayMember = DiplayMember;
            lkp_Currency.EditValue = null;
            lkp_Currency.Properties.NullText = "[اختر العملة]";

            lkp_Currency.Properties.PopulateColumns();
            lkp_Currency.Properties.Columns[ValueMember].Visible = false;
           // lkp_Currency.Properties.EndInit();


        }


    }
}
