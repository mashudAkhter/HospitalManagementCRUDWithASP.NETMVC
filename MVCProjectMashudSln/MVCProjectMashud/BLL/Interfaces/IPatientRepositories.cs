using MVCProjectMashud.Models;
using MVCProjectMashud.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProjectMashud.BLL.Interfaces
{
    public interface IPatientRepositories
    {
        List<PatientListViewModel> GetPatient();
        tblPatient GetPatientById(int id);
        void SavePatient(tblPatient obj);
        void UpdatePatient(tblPatient obj);
        void DeletePatient(int id);
        List<tblDoctor> GetDoctor();


    }
}
