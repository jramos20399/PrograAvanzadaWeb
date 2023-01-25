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


            return new JsonResult(categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Category category;
            category = categoryDAL.Get(id);


            return new JsonResult(category);

        }
        #endregion


        #region Agregar
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] Category category)
        {
            categoryDAL.Add(category);
            return new JsonResult(category);

        }

        #endregion


        #region MOdificar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] Category category)
        {

            categoryDAL.Update(category);
            return new JsonResult(category);    

        }
        #endregion


        #region Eliminar
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Category category = new Category { CategoryId= id };
            categoryDAL.Remove(category);

            return new  JsonResult(category);


        }


        #endregion
    }
}
