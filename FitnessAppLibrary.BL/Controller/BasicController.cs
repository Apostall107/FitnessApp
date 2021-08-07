using System.Collections.Generic;


namespace FitnessAppLibrary.BL.Controller
{
    public abstract class BasicController
    {
        private readonly IDataSaver manager = new SerializeSaver();
        //private readonly IDataSaver manager = new DbDataSaver();

        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }



    }
}
