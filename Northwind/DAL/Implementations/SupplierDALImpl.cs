using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class SupplierDALImpl : ISupplierDAL
    {
        private UnidadDeTrabajo<Supplier> unidad;
        private NorthWindContext context;

        public SupplierDALImpl(NorthWindContext _context)
        {
            this.context = _context;

        }




        public bool Add(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Supplier> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> Find(Expression<Func<Supplier, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Supplier Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> GetAll()
        {
            IEnumerable<Supplier> entities;
            using (unidad = new UnidadDeTrabajo<Supplier>(context))
            {
                entities = unidad.genericDAL.GetAll();
            }
            return entities;
        }

        public bool Remove(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Supplier> entities)
        {
            throw new NotImplementedException();
        }

        public Supplier SingleOrDefault(Expression<Func<Supplier, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Supplier entity)
        {
            throw new NotImplementedException();
        }
    }
}
