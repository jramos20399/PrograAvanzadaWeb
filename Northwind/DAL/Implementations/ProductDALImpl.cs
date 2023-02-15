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
    public class ProductDALImpl : IProductDAL
    {
        private UnidadDeTrabajo<Product> unidad;
       
        
        NorthWindContext context;
        
        
        
        public ProductDALImpl(NorthWindContext context)
        {
            this.context = context;
        }

        public bool Add(Product entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Product>(context))
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

        public void AddRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            Product product = null;
            using (unidad= new UnidadDeTrabajo<Product>(context))
            {
                product = unidad.genericDAL.Get(id);
            }
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = null;
            using (unidad = new UnidadDeTrabajo<Product>(context))
            {
                products = unidad.genericDAL.GetAll();
            }
            return products;
        }

        public bool Remove(Product entity)
        {
            bool result = false;
            try
            {
                using ( unidad = new UnidadDeTrabajo<Product>(context))
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

        public void RemoveRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Product SingleOrDefault(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Product> unidad = new UnidadDeTrabajo<Product>(context))
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
