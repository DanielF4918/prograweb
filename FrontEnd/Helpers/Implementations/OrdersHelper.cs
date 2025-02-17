using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FrontEnd.Helpers.Implementations
{
    public class OrdersHelper : IOrdersHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public OrdersHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public List<OrderViewModel> GetAllOrders()
        {
            HttpResponseMessage response = _serviceRepository.GetResponse("api/Orders");
            List<OrderViewModel> orders = new List<OrderViewModel>();

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                orders = JsonConvert.DeserializeObject<List<OrderViewModel>>(content);
            }

            return orders;
        }

        public OrderViewModel GetOrder(int id)
        {
            HttpResponseMessage response = _serviceRepository.GetResponse($"api/Orders/{id}");
            OrderViewModel order = new OrderViewModel();

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<OrderViewModel>(content);
            }

            return order;
        }

        public OrderViewModel Add(OrderViewModel order)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("api/Orders", order);
            return order;
        }

        public OrderViewModel Update(OrderViewModel order)
        {
            HttpResponseMessage response = _serviceRepository.PutResponse("api/Orders", order);
            return order;
        }

        public void Delete(int id)
        {
            _serviceRepository.DeleteResponse($"api/Orders/{id}");
        }
    }
}
