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
    public class SupplierController : ControllerBase
    {
        private ISupplierDAL supplierDAL;


        SupplierModel Convertir(Supplier supplier)
        {
            return new SupplierModel
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName
            };
        }

        List<SupplierModel> Convertir(List<Supplier> suppliers)
        {
            List<SupplierModel> lista= new List<SupplierModel>();

            foreach (Supplier supplier in suppliers)
            {
                lista.Add(Convertir(supplier));
            }


            return lista;
        }



        Supplier Convertir(SupplierModel supplier)
        {
            return new Supplier
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName
            };
        }



        public SupplierController()
        {
            supplierDAL = new SupplierDALImpl(new NorthWindContext());
        }


        // GET: api/<SupplierController>
        [HttpGet]
        public JsonResult Get()
        {
            List<Supplier> suppliers;    
            suppliers=supplierDAL.GetAll().ToList();




            return new JsonResult(Convertir(suppliers));
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Supplier supplier;
            supplier = supplierDAL.Get(id);
            return new JsonResult(Convertir(supplier));

        }

        // POST api/<SupplierController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
