using Branch_project.Views.InterFaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branch_project.Logic.Presenter
{
    class BranchViewPresenter
    {




        #region Fields

        private readonly IBranchView BranchRepo;



        #endregion



        #region Constractors

        public BranchViewPresenter(IBranchView reop)
        {
            BranchRepo = reop;

           // RefreshData();


        }

        #endregion



        #region Functions
      
        #endregion





    }
}
