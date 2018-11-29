using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryStandCommercials.Models
{
    public class StandCommercialRepository
    {


        //// Repository for commercials ////


        /// <summary>    
        /// To Get all commercials from database
        /// </summary>
        public IEnumerable<Commercial> GetAllCommercials()
        {
            using (var db = new StandCommercialContext())
            {

                return db.Commercials.ToList();

            }
        }

        /// <summary>
        /// To Get particular commercial from database
        /// </summary>
        /// <param name="commercialId"></param>
        /// <returns></returns>
        public Commercial GetCommercial(int commercialId)
        {
            using (var db = new StandCommercialContext())
            {
                return db.Commercials.Find(commercialId);
            }
        }
        /// <summary>
        /// Add commercial in database
        /// </summary>
        /// <param name="commercial"></param>
        /// <returns></returns>
        public int AddCommercial(Commercial commercial)
        {
            using (var db = new StandCommercialContext())
            {

                db.Commercials.Add(commercial);
                db.SaveChanges();
                db.Entry(commercial).GetDatabaseValues();  // потом попробывать без этого
                return commercial.Id;
            }
        }


        /// <summary>
        /// Add  record about commercial, and records abot mapping comercial and stands, in databases
        /// </summary>
        /// <param name="commercial"></param>
        /// <param name="standId"></param>
        /// <returns></returns>

        public int AddCommercial(Commercial commercial, List<int> standId)
        {
            using (var db = new StandCommercialContext())
            {

                db.Commercials.Add(commercial);
                db.SaveChanges();
                var stand = new Stand();

                foreach (var id in standId)
                {
                    stand = db.Stands.Find(id);

                    commercial.StandCommercials.Add(new StandCommercial { CommercialId = commercial.Id, StandId = stand.Id });
                    db.SaveChanges();

                }
                db.Entry(commercial).GetDatabaseValues();  // потом попробывать без этого
                return commercial.Id;
            }
        }


        /// <summary>
        /// To Update record about commercial in database
        /// </summary>
        /// <param name="commercial"></param>
        /// <returns></returns>


        public int UpdateCommercial(Commercial commercial)
        {
            using (var db = new StandCommercialContext())
            {
                db.Entry(commercial).State = EntityState.Modified;
                db.SaveChanges();
                return commercial.Id;

            }
        }

        /// <summary>
        /// To delete record about commercial in database
        /// </summary>
        /// <param name="commercialId"></param>



        public void DeleteCommercial(int commercialId)
        {
            using (var db = new StandCommercialContext())
            {
                var commercial = db.Commercials.Find(commercialId);
                db.Commercials.Remove(commercial);
                db.SaveChanges();
            }
        }



        //// Repository for stands ////

        /// <summary>
        /// To get all records about stands from database
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Stand> GetAllStands()
        {
            using (var db = new StandCommercialContext())
            {
                return db.Stands.ToList();
            }
        }

        /// <summary>
        /// To get record about particular stand from database
        /// </summary>
        /// <param name="standId"></param>
        /// <returns></returns>
        public Stand GetStand(int standId)
        {
            using (var db = new StandCommercialContext())
            {
                return db.Stands.Find(standId);

            }
        }



        /// <summary>
        /// To add record about stand in database
        /// </summary>
        /// <param name="stand"></param>
        /// <returns></returns>

        public int AddStand(Stand stand)
        {
            using (var db = new StandCommercialContext())
            {
                db.Stands.Add(stand);
                db.SaveChanges();
                db.Entry(stand).GetDatabaseValues();
                return stand.Id;

            }
        }

        /// <summary>
        /// To update record about stand in database
        /// </summary>
        /// <param name="stand"></param>
        /// <returns></returns>
        public int UpdateStand(Stand stand)
        {
            using (var db = new StandCommercialContext())
            {
                db.Entry(stand).State = EntityState.Modified;
                db.SaveChanges();
                return stand.Id;

            }

        }

        /// <summary>
        /// To delete record about stand from database
        /// </summary>
        /// <param name="standId"></param>
        /// <returns></returns>



        public int DeleteStand(int standId)
        {
            using (var db = new StandCommercialContext())
            {
                db.Stands.Remove(db.Stands.Find(standId));
                db.SaveChanges();
                return standId;
            }
        }










        //// Repository for mapping commercial and stands////



        /// <summary>
        /// To add record about mapping commercial and stand in database
        /// </summary>
        /// <param name="idCommercial"></param>
        /// <param name="standId"></param>
        public void AddStandCommercial(int idCommercial, int standId)
        {
            using (var db = new StandCommercialContext())
            {
                //  var stand = db.Stands.Find(standId);
                var commercial = db.Commercials.Find(idCommercial);

                commercial.StandCommercials.Add(new StandCommercial { CommercialId = commercial.Id, StandId = standId });
                db.SaveChanges();


            }
        }


        public void DeleteStandCommercial(int CommercialId, int StandId)
        {
            using (var db = new StandCommercialContext())
            {
                // var student = db.Commercials.Include(s => s.StudentCourses).FirstOrDefault(s => s.Name == "Alice");
                var commercial = db.Commercials.Include(c => c.StandCommercials).FirstOrDefault(c => c.Id == CommercialId);
                // Course course = db.Courses.FirstOrDefault(c => c.Name == "Алгоритмы");
                var stand = db.Stands.FirstOrDefault(s => s.Id == StandId);


                if (commercial != null && stand != null)
                {
                    var standCommercial = commercial.StandCommercials.FirstOrDefault(sc => sc.StandId == stand.Id);
                    //StudentCourses.FirstOrDefault(sc => sc.CourseId == course.Id);
                    // student.StudentCourses.Remove(studentCourse);
                    commercial.StandCommercials.Remove(standCommercial);
                    db.SaveChanges();
                }
            }
        }
    }
}
