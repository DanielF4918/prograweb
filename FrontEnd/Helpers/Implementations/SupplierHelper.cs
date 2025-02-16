using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class SupplierHelper : ISupplierHelper
    {
        IServiceRepository _ServiceRepository;

        public SupplierHelper(IServiceRepository serviceRepository)
        {
            this._ServiceRepository = serviceRepository;
        }


        SupplierViewModel Convertir(SupplierAPI supplier)
        {
            return new SupplierViewModel
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName,
            };
        }
        public List<SupplierViewModel> GetAll()
        {
            List<SupplierAPI> suppliers = new List<SupplierAPI>();

            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/supplier");

            if (responseMessage != null)
            {

                var content = responseMessage.Content.ReadAsStringAsync().Result;
                suppliers = JsonConvert.DeserializeObject<List<SupplierAPI>>(content);

            }
            List<SupplierViewModel> supplierViewModels = new List<SupplierViewModel>();

            foreach (var item in suppliers)
            {
                supplierViewModels.Add(Convertir(item));
            }
            return supplierViewModels;

        }
    }
}