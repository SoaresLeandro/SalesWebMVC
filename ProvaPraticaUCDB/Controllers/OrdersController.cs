using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProvaPraticaUCDB.Data;
using ProvaPraticaUCDB.Models;
using ProvaPraticaUCDB.Services;
using ProvaPraticaUCDB.Services.Exceptions;

namespace ProvaPraticaUCDB.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Orders
        public IActionResult Index()
        {
            var list = _orderService.FindAll();
            
            return View(list);
        }

        // GET: Orders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var order = _orderService.FindById(id.Value);

            if (order == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Pedido não encontrado" });
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            _orderService.Insert(order);
            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var order = _orderService.FindById(id.Value);

            if (order == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Pedido não encontrado" });
            }

            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Order order)
        {
            if (id != order.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id informado não corresponde ao Id do Pedido" });
            }

            try
            {
                _orderService.Update(order);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        // GET: Orders/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var order = _orderService.FindById(id.Value);

            if (order == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Pedido não encontrado" });
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _orderService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            var ViewModel = new ErrorViewModel 
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(ViewModel);
        }

       /* private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }*/
    }
}
