using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CategoryDALImpl : ICategoryDAL
    {
        NorthWindContext context;


        public CategoryDALImpl()
        {
            context = new NorthWindContext();

        }

        public CategoryDALImpl(NorthWindContext _Context)
        {
            context = _Context;

        }

        public bool Add(Category entity)
        {
            try
            {
                using (UnidadDeTrabajo<Category> unidad = new UnidadDeTrabajo<Category>(context))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            Category category;
            using (UnidadDeTrabajo<Category> unidad = new UnidadDeTrabajo<Category>(context))
            {
               
                category= unidad.genericDAL.Get(id);
            }
            return category;

        }

        public IEnumerable<Category> GetAll()
        {
            try
            {
                IEnumerable<Category> categories;
                using (UnidadDeTrabajo<Category> unidad = new UnidadDeTrabajo<Category>(context))
                {
                    categories = unidad.genericDAL.GetAll();
                }
                return categories;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Category entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Category> unidad = new UnidadDeTrabajo<Category>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        public void RemoveRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Category SingleOrDefault(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Category> unidad = new UnidadDeTrabajo<Category>(context))
                {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }
    }
}
