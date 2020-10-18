using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestAssig
{
    public partial class Vacancy : System.Web.UI.Page
    {
        #region Variables
        DAL.VacationManagement _VacationManagement;
        #endregion
        #region Property
        public string VacancyId
        {
            set { ViewState["VacancyId"] = value; }
            get { return ViewState["VacancyId"] == null ? string.Empty : ViewState["VacancyId"].ToString(); }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                VacancyId = Request.QueryString["ID"].ToString();
            }
            if (!IsPostBack)
            {
               
            }
        }

        #region Events
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
     
            Response.Redirect("Default.aspx");
        }



        #endregion
        #region Methods

        void Save()
        {
            _VacationManagement = new DAL.VacationManagement();

            #region Manage Item
            string FileName = string.Empty;
            _VacationManagement._objVacation.VacancyId= Guid.NewGuid();
            _VacationManagement._objVacation.SubmissionDate = DateTime.Now;
            _VacationManagement._objVacation.Title = txtTitle.Value;
            _VacationManagement._objVacation.EmployeeName = txtemp.Value;
            _VacationManagement._objVacation.Department = int.Parse(ddlDepartment.SelectedValue);
            _VacationManagement._objVacation.Notes = edContent.InnerText;
            _VacationManagement._objVacation.VacationDateFrom = DateTime.Parse(txtFrom.Value);
            _VacationManagement._objVacation.VacationDateTo = DateTime.Parse(txtTo.Text);

            if (string.IsNullOrEmpty(VacancyId))
            {
               
                VacancyId = _VacationManagement.Add();

                if (!string.IsNullOrEmpty(VacancyId))
                {
                   // BackendMessages(101);
                    alertSuccess.Visible = true;
                }
                else
                {
                   // BackendMessages(201);
                    alertFaild.Visible = true;
                }
            }

            #endregion
        }

        #endregion

        protected void txtTo_TextChanged(object sender, EventArgs e)
        {
            var datefrom = DateTime.Parse(txtFrom.Value);
            var dateto = DateTime.Parse(txtTo.Text);
            txtReturning.Value = dateto.AddDays(1).ToString("MM/dd/yyyy");
            var total = dateto - datefrom;
            txtTotalNumber.Value = total.ToString("dd");

        }
    }
}