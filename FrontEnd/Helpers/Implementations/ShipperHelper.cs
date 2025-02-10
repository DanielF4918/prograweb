using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace FrontEnd.Helpers.Implementations
{
    public class ShipperHelper : IShipperHelper
    {
        private readonly IServiceRepository _ServiceRepository;

        public ShipperHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
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

        public ShipperViewModel Add(ShipperViewModel shipper)
        {
            HttpResponseMessage response = _ServiceRepository.PostResponse("api/Shipper", shipper);
            return shipper;
        }

        public void Delete(int id)
        {
            _ServiceRepository.DeleteResponse("api/Shipper/" + id);
        }

        public List<ShipperViewModel> GetShippers()
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Shipper");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            List<ShipperAPI> shippers = JsonConvert.DeserializeObject<List<ShipperAPI>>(content) ?? new List<ShipperAPI>();

            return shippers.Select(Convertir).ToList();
        }

        public ShipperViewModel GetShipper(int? id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Shipper/" + id);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ShipperAPI shipper = JsonConvert.DeserializeObject<ShipperAPI>(content);
            return Convertir(shipper);
        }

        public ShipperViewModel Update(ShipperViewModel shipper)
        {
            HttpResponseMessage response = _ServiceRepository.PutResponse("api/Shipper", shipper);
            return shipper;
        }
    }
}
