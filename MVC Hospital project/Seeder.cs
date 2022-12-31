using Hospital.DbContextAndBuilders.ApiDbContext;

using MVC_Hospital_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public static class Seeder
    {
       
       



        public static void seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var _dbContext = serviceScope.ServiceProvider.GetService<HospitalDbContext>();
             

                if (_dbContext.Database.CanConnect())
                {
                    if (!_dbContext.Doctors.Any())
                    {
                        var doctors = new List<Doctor>()
                {
                    new Doctor()
                    {
                        Name = "Tomek Tomczak",
                        Specialization = "podiatrist",
                        ContactNumber = "111222333",
                        IdentificationNumber = "3423",
                        Gender = "Male",
                        DateOfBirth = new DateTime(1934,02,28)

                    },

                    new Doctor()
                    {
                         Name = "Jakub Jakubowski",
                        Specialization = "podiatrist",
                        ContactNumber = "121232334",
                        IdentificationNumber = "3125",
                        Gender = "Male",
                        DateOfBirth = new DateTime(1956,03,01)
                    }
                };
                        _dbContext.Doctors.AddRange(doctors);
                        _dbContext.SaveChanges();
                    }
                    if (!_dbContext.Patients.Any())
                    {
                        var patients = new List<Patient>()
            {
                new Patient()
                {
                    Name="Zosia Kowalewska",
                    IdentificationNumber = "1111",
                    Gender= "Female",
                    DateOfBirth = new DateTime(2001,02,01)
                },

                new Patient()
                {
                    Name="Maga Perła",
                    IdentificationNumber = "1112",
                    Gender= "Female",
                    DateOfBirth = new DateTime(1999,02,01)
                }

            };
                        _dbContext.Patients.AddRange(patients);
                        _dbContext.SaveChanges();

                    }
                    if (!_dbContext.Visits.Any())
                    {
                        var visits = new List<Visit>()
            {
                new Visit()
                {
                    DateOfVisit = new DateTime(2022,06,16),
                    DoctorId = 1,
                    PatientId = 2,

                },
                new Visit()
                {
                    DateOfVisit = new DateTime(2022,07,01),
                    DoctorId =1,
                    PatientId = 1
                }

            };
                        _dbContext.Visits.AddRange(visits);
                        _dbContext.SaveChanges();
                    }
                }
            }
        }

        
    

    }
}