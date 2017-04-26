using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_OKM_2.Model;
using System.Collections.ObjectModel;
using SQLiteNetExtensions.Extensions;

namespace Testing_OKM_2.Controllers
{
    class CourseController : BaseController<Course>, IController<Course>
    {
        public CourseController() 
        {
            HeaderText = "Список курсів";
            GetAllEntity();
        }

        public void GetAllEntity()
        {
            lock (collisionLock)
            {
                Entity = new ObservableCollection<Course>(database.GetAllWithChildren<Course>());
            }
        }

        public Course GetEntityById(int id)
        {
            lock (collisionLock)
            {
                return database.GetAllWithChildren<Course>(c => c.Id == id).SingleOrDefault();
            }
        }

        public void InsertAllEntities(IEnumerable<Course> entities)
        {
            lock (this)
            {
                database.InsertAllWithChildren(entities, true);
                GetAllEntity();
            }
        }

        public void InsertEntity(Course entity)
        {
            lock (collisionLock)
            {
                database.Insert(entity);
                GetAllEntity();
            }
        }

        public void AddModule(Course course, Module module)
        {
            database.Insert(module);
            course.Modules.Add(module);
            database.UpdateWithChildren(course);
            GetAllEntity();
        }
    }
}
