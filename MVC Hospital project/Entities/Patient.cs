using System;
namespace MVC_Hospital_project.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IdentificationNumber { get; set; }

        public string Gender { get; set; }
      
        public DateTime DateOfBirth { get; set; }
    }
}
