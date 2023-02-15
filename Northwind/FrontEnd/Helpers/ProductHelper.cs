using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class ProductHelper
    {
        private ServiceRepository ServiceRepository;


        public ProductHelper() {
            ServiceRepository= new ServiceRepository();
        
        }  



        public List<ProductViewModel> GetAll()
        {
            List<ProductViewModel> lista = new List<ProductViewModel>();

            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/product");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ProductViewModel>>(content);
            }

            return lista;

        }




        public ProductViewModel Get(int id)
        {
            ProductViewModel ProductViewModel;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/product/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ProductViewModel = JsonConvert.DeserializeObject<ProductViewModel>(content);



            return ProductViewModel;
        }


        public ProductViewModel Create(ProductViewModel product)
        {


            ProductViewModel ProductViewModel;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/product/", product);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ProductViewModel = JsonConvert.DeserializeObject<ProductViewModel>(content);



            return ProductViewModel;
        }

    }
}
