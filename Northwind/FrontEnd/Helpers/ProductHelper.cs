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
    }
}
