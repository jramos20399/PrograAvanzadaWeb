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
    public class ProductController : ControllerBase
    {
        Product Convertir(ProductModel product)
        {
            return new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued

            };
        }

        ProductModel Convertir(Product product)
        {
            return new ProductModel
            {
                ProductId= product.ProductId,
                ProductName= product.ProductName,
                SupplierId= product.SupplierId,
                CategoryId= product.CategoryId,
                QuantityPerUnit= product.QuantityPerUnit,
                UnitPrice= product.UnitPrice,
                UnitsInStock= product.UnitsInStock,
                UnitsOnOrder= product.UnitsOnOrder,
                ReorderLevel= product.ReorderLevel,
                Discontinued= product.Discontinued

            };
        }

        IProductDAL productDAL;

        public ProductController()
        {
            productDAL = new ProductDALImpl(new NorthWindContext());
        }
        // GET: api/<ProductController>
        [HttpGet]
        public JsonResult Get()
        {
            List<Product> products = new List<Product>();
            products = productDAL.GetAll().ToList();

            List<ProductModel> resultado = new List<ProductModel>();

            foreach (Product product in products)
            {
                resultado.Add(Convertir(product));
            }

            return new JsonResult(resultado) ;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Product product = productDAL.Get(id);


            return new JsonResult(Convertir(product));
        }

        // POST api/<ProductController>
        [HttpPost]
        public JsonResult Post([FromBody] ProductModel product)
        {

            Product entity = Convertir(product);
            productDAL.Add(entity);

            return new JsonResult(Convertir(entity));


        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ProductModel product)
        {

            Product entity = Convertir(product);
            productDAL.Update(entity);

            return new JsonResult(Convertir(entity));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            Product product = new Product { ProductId= id };
            productDAL.Remove(product);

        }
    }
}
