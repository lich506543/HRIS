using HRIS.Database;
using HRIS.Teaching;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Controller
{
    class StaffController
    {
        private List<TeachingStaff> staff;
        public List<TeachingStaff> Workers { get { return staff; } set { } }
       
        private ObservableCollection<TeachingStaff> viewableStaff;
        public ObservableCollection<TeachingStaff> VisibleWorkers { get { return viewableStaff; } set { } }

        public StaffController()
        {
            staff = Agency.LoadAll();
            viewableStaff = new ObservableCollection<TeachingStaff>(staff); 

            foreach (TeachingStaff e in staff)
            {
                e.ConsultationHours = Agency.LoadConsultation(e.ID);
            }
        }
        public ObservableCollection<TeachingStaff> GetViewableList()
        {
            return VisibleWorkers;
        }

     /*   public void Filter(Gender gender)
        {
            var selected = from TeachingStaff e in staff
                           where gender == Gender.Any || e.Gender == gender
                           select e;
            viewableStaff.Clear();            
            //Converts the result of the LINQ expression to a List and then calls viewableStaff.Add with each element of that list in turn
            selected.ToList().ForEach( viewableStaff.Add );
        } */
   
    }
}
