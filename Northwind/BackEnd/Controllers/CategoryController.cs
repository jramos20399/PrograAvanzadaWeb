using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private ICategoryDAL categoryDAL;

        #region Convertir
        private CategoryModel Convertir(Category entity)
        {
            return new CategoryModel
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Description = entity.Description


            };
        }


        private Category Convertir(CategoryModel model)
        {
            return new Category
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
                Description = model.Description


            };
        }
        #endregion

        #region Constructor
        public CategoryController()
        {
            categoryDAL = new CategoryDALImpl(new Entities.Entities.NorthWindContext());

        }
        #endregion

        #region Consultar
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Category> categories = categoryDAL.GetAll();

            List<CategoryModel> lista = new List<CategoryModel>();

            foreach (var category in categories) {
                lista.Add(Convertir(category)                       
                    
                    );
            }
            return new JsonResult(lista);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Category category;
            category = categoryDAL.Get(id);

           

            return new JsonResult(Convertir(category));

        }
        #endregion


        #region Agregar
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] CategoryModel category)
        {

            Category entity = Convertir(category);
            categoryDAL.Add(entity);
            return new JsonResult(Convertir(entity));

        }

        #endregion


        #region MOdificar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CategoryModel category)
        {

            categoryDAL.Update(Convertir(category));
            return new JsonResult(Convertir(category));

        }
        #endregion


        #region Eliminar
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Category category = new Category { CategoryId= id };
            categoryDAL.Remove(category);

            return new  JsonResult(Convertir(category));


        }


        #endregion
    }
}
