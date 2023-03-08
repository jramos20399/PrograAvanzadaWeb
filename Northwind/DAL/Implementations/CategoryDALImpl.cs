using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
                
                string sql = "exec [dbo].[sp_AddCategory] @CategoryName, @Description";
                var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@CategoryName",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            //Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.CategoryName
                        },
                        new SqlParameter() {
                            ParameterName = "@Description",
                            SqlDbType =  System.Data.SqlDbType.NText,
                            //Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.Description
                        }
                };

                int resultado = context.Database
                            .ExecuteSqlRaw( sql, param );



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
                List<Category> categories = new List<Category>();

                List<sp_GetAllCategories_Result> resultado;

                string sql = "[dbo].[sp_GetAllCategories]" ;


                resultado = context.sp_GetAllCategories_Results
                        .FromSqlRaw(sql)
                        .ToList();

                foreach (var item in resultado)
                {
                    categories.Add(
                        new Category
                        {
                            CategoryId = item.CategoryId,
                               CategoryName = item.CategoryName,
                               Description = item.Description,
                               Picture = item.Picture
                        }
                        );
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
