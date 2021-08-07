using FitnessAppLibrary.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public abstract class DbDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
            List<T> result = db.Set<T>().Where(t => true).ToList();
                return result;
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (FitnessContext db = new FitnessContext())
            {
            //Type pattern switcher is not possible till c# 9.0

                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }

