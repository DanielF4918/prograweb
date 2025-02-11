using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace FrontEnd.Helpers.Implementations
{
    public class ShipperHelper : IShipperHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public ShipperHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        private ShipperViewModel Convertir(ShipperAPI shipper)
        {
            return new ShipperViewModel
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
        }

        public List<ShipperViewModel> GetAll()
        {
            HttpResponseMessage response = _serviceRepository.GetResponse("api/Shippers");
            List<ShipperAPI> shippers = new List<ShipperAPI>();
            if (response != null && response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                shippers = JsonConvert.DeserializeObject<List<ShipperAPI>>(content);
            }

            List<ShipperViewModel> lista = new List<ShipperViewModel>();
            foreach (var shipper in shippers)
            {
                lista.Add(Convertir(shipper));
            }
            return lista;
        }

        public ShipperViewModel GetById(int id)
        {
            HttpResponseMessage response = _serviceRepository.GetResponse("api/Shippers/" + id);
            ShipperAPI shipper = new ShipperAPI();
            if (response != null && response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                shipper = JsonConvert.DeserializeObject<ShipperAPI>(content);
            }
            return Convertir(shipper);
        }

        public ShipperViewModel Create(ShipperViewModel model)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("api/Shippers", model);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return model;
        }

        public void Update(ShipperViewModel model)
        {
            _serviceRepository.PutResponse("api/Shippers", model);
        }

        public void Delete(int id)
        {
            _serviceRepository.DeleteResponse("api/Shippers/" + id);
        }
    }
}
