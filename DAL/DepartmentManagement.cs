using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Web;

namespace DAL
{
    public class DepartmentManagement
    {
        #region Variable

        static dbDataContext db;
        public Department _objDepartment;

        #endregion
        #region Methods

        public DepartmentManagement()
        {
            db = new dbDataContext();
            _objDepartment = new Department();
        }

        public DataTable Load()
        {

            var query = (from F in db.Departments
                         select new { F.id, F.name }).Distinct();
            return query.ToDataTable();
        }

        #endregion
    }
}
