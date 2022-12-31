namespace MVC_Hospital_project.Entities
{
    public class Visit
    {
        public int Id { get; set; }

        public DateTime DateOfVisit { get; set; }

        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }


        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
