using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ProductHelper : IProductHelper
    {
        IServiceRepository _repository;

        public ProductHelper(IServiceRepository serviceRepository)
        {
            this._repository = serviceRepository;
        }

        ProductViewModel Convertir(ProductAPI product)
        {
            return new ProductViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = (int)product.CategoryId,
                Discontinued = product.Discontinued,
                SupplierName = product.SupplierName
            };
        }

        ProductAPI Convertir(ProductViewModel product)
        {
            return new ProductAPI
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued
            };
        }



        public ProductViewModel AddProduct(ProductViewModel ProductViewModel)
        {
            HttpResponseMessage responseMessage = _repository.PostResponse("api/product", Convertir(ProductViewModel));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }


            return ProductViewModel;

        }

        public void DeleteProduct(int id)
        {
            HttpResponseMessage responseMessage = _repository.DeleteResponse("api/product/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }



        }

        public ProductViewModel EdiProduct(ProductViewModel ProductViewModel)
        {
            HttpResponseMessage responseMessage = _repository.PutResponse("api/product", Convertir(ProductViewModel));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }


            return ProductViewModel;
        }

        public List<ProductViewModel> GetAll()
        {
            List<ProductAPI> products = new List<ProductAPI>();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/product");


            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductAPI>>(content);


            }

            List<ProductViewModel> list = new List<ProductViewModel>();


            foreach (var item in products)
            {
                list.Add(Convertir(item));
            }
            return list;


        }

        public ProductViewModel GetById(int id)
        {
            ProductAPI ProductAPI = new ProductAPI();
            HttpResponseMessage responseMessage = _repository.GetResponse("api/product/" + id.ToString());


            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                ProductAPI = JsonConvert.DeserializeObject<ProductAPI>(content);


            }

            return Convertir(ProductAPI);
        }
    }
}