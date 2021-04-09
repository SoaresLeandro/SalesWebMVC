using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProvaPraticaUCDB.Services;

namespace ProvaPraticaUCDB.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderService _OrderService;

        public OrdersController(OrderService orderService)
        {
            _OrderService = orderService;
        }
        public IActionResult Index()
        {
            var orders = _OrderService.FindAll();
            
            return View(orders);
        }
    }
}
