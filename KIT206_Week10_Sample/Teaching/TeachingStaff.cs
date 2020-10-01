using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Teaching
{
    public enum Category { Academic, Technical, Admin, Casual };

    public class TeachingStaff
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Tittle { get; set; }
        public Campus Campus { get; set; }
        public int Room { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public Category Category { get; set; }
        public List<Consultation> ConsultationHours { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
