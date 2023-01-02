using System.Collections.Generic;
namespace MVC_Hospital_project.Entities

{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Specialization { get; set; }
        
        public string ContactNumber { get; set; }

        public string IdentificationNumber { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual List<Visit> Visits { get; set; }
    }
}
