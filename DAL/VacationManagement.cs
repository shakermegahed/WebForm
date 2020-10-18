using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Web;

namespace DAL
{
    public class VacationManagement
    {
        #region Variable

        static dbDataContext db;
        public Vacaion _objVacation;

        #endregion
        #region Methods

        public VacationManagement()
        {
            db = new dbDataContext();
            _objVacation = new Vacaion();
        }

        public string Add()
        {

            db.Vacaions.InsertOnSubmit(_objVacation);
            db.SubmitChanges();

            return _objVacation.VacancyId.ToString();

        }


        public Vacaion LoadById(string VacancyId)
        {
            if (!string.IsNullOrEmpty(VacancyId))
            {
                _objVacation = db.Vacaions.FirstOrDefault(lb => lb.VacancyId == new Guid(VacancyId));
                return _objVacation;
            }
            return null;

        }


        public DataTable Load()
        {

            var Query = (from q in db.GetVacancies()
                         select q).Distinct().OrderBy(q => q.Title);
            if (Query != null)
                return Query.ToDataTable();
            return null;
        }

        #endregion
    }
}
