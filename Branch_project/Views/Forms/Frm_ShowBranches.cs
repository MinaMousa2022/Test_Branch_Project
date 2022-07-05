using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Branch_project.Logic.Services;
using Branch_project.Models;
using System.Data.SqlClient;
using Branch_project.Logic.Presenter;
using Branch_project.Views.InterFaces;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

namespace Branch_project.Views.Forms
{
    public partial class Frm_ShowBranches : DevExpress.XtraEditors.XtraForm, IBranchCrud
    {
        BranchViewPresenter BranchViewPresenter;

        public string BranchID { get => gridView1.GetRowCellValue(gridView1.GetFocusedDataSourceRowIndex(), "branchid").ToString(); set => throw new NotImplementedException(); }
        public string branchName_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string branchEName_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object currid_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string manager_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string emanager_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string address_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string eaddress_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string tel1_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string tel2_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string fax_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string email_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object GridDataSource { get => gridControl1.DataSource; set => gridControl1.DataSource = value; }
        public int GridCounts { get => gridView1.RowCount; }

        public Frm_ShowBranches()
        {
            InitializeComponent();
            BranchViewPresenter = new BranchViewPresenter(this);
            BranchViewPresenter.RefreshData();
            gridView1.Columns["branchid"].Visible = false;
            barHeaderItem2.Caption = gridView1.RowCount.ToString();
        }


        #region Functions




        void DeleteBranch()
        {




            SqlConnection Connection = BranchViewPresenter.SQlConnection();

            var Execute = BranchViewPresenter.DeleteBranch(Connection);
            if (Execute == "Success")
            {
                MessageBox.Show("تم حذف الفرع بنجاح");
            }
            else { MessageBox.Show(Execute); }


            BranchViewPresenter.RefreshData();
            gridView1.Columns["branchid"].Visible = false;
            barHeaderItem2.Caption = gridView1.RowCount.ToString();

        }

        void EditBranch()
        {
            Frm_EditBranch Frm_EditBranch = new Frm_EditBranch(Convert.ToInt32(BranchID));

            Frm_EditBranch.ShowDialog();
            BranchViewPresenter.RefreshData();
            gridView1.Columns["branchid"].Visible = false;
            barHeaderItem2.Caption = gridView1.RowCount.ToString();

        }
            
        void AddRepoButtonToGridView()
        {

            RepositoryItemButtonEdit EditRepo = new RepositoryItemButtonEdit();
            EditRepo.Buttons[0].Kind = ButtonPredefines.Plus;
            RepositoryItemButtonEdit DeleteRepo = new RepositoryItemButtonEdit();
            DeleteRepo.Buttons[0].Kind = ButtonPredefines.Delete;
            EditRepo.Appearance.Options.UseBackColor = true;
     



            gridControl1.RepositoryItems.Add(EditRepo);
            gridControl1.RepositoryItems.Add(DeleteRepo);
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Width=44, FieldName = "Delete", Caption = "", ColumnEdit = DeleteRepo, ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways, VisibleIndex = 100 }) ;
            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Width = 44, FieldName = "Edit", Caption = "", ColumnEdit = EditRepo, ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways, VisibleIndex = 101 }) ;



            gridView1.Columns["Delete"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["Edit"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["Delete"].OptionsColumn.ShowCaption = false;
            gridView1.Columns["Edit"].OptionsColumn.ShowCaption = false;
            gridView1.Columns["Delete"].Width = 30;
            gridView1.Columns["Delete"].OptionsColumn.ReadOnly=false;
            gridView1.Columns["Edit"].Width = 30;
            
            // gridView1.Columns["MyFieldName"].ColumnEdit = Edit;
            files_Branch class1 = new files_Branch();
            foreach (var item in class1.GetType().GetProperties())
            {
                gridView1.Columns[item.Name].OptionsColumn.AllowEdit = false;
            }
            //Edit.Buttons[1].Kind = ButtonPredefines.Delete;
            EditRepo.ButtonClick += Edit_ButtonClick;
            DeleteRepo.ButtonClick += DeleteRepo_ButtonClick;
            

        }

        private void DeleteRepo_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DeleteBranch();
        }

        private void Edit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            EditBranch();
        }

     

     

        void GridControlSettings()
        {

            RepositoryItemLookUpEdit lkp = new RepositoryItemLookUpEdit();
            var ss = DbHelper.ExecuteSP<files_Curr>("spSelectCur", null);
            lkp.DataSource = ss;

            lkp.ValueMember = nameof(files_Curr.currid);
            lkp.DisplayMember = nameof(files_Curr.currname);

            gridControl1.RepositoryItems.Add(lkp);
            gridView1.Columns["currid"].ColumnEdit = lkp;

           // gridView1.OptionsBehavior.Editable = false;
        }
        #endregion

        private void Frm_ShowBranches_Load(object sender, EventArgs e)
        {
            BranchViewPresenter.RefreshData();
            gridView1.Columns["branchid"].Visible = false;
            barHeaderItem2.Caption = gridView1.RowCount.ToString();




            GridControlSettings();
            AddRepoButtonToGridView();
          
        }

        private void barHeaderItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btn_AddBranch_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_AddBranch Frm_AddBranch = new Frm_AddBranch();

            Frm_AddBranch.ShowDialog();
            BranchViewPresenter.RefreshData();
            gridView1.Columns["branchid"].Visible = false;
            barHeaderItem2.Caption = gridView1.RowCount.ToString();


        }
      



        private void btn_RemoveBranch_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteBranch();


        }

        private void btn_EditBranch_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditBranch();
        }
    }
}