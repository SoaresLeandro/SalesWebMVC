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
using ProvaPraticaUCDB.Models.Enums;

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
        public async Task<IActionResult> Index()
        {
            var list = await _orderService.FindAllAsync();

            return View(list);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var order = await _orderService.FindByIdAsync(id.Value);

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
        public async Task<IActionResult> Create(Order order)
        {
            await _orderService.InsertAsync(order);
            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var order = await _orderService.FindByIdAsync(id.Value);

            if (order == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Pedido não encontrado" });
            }

            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id informado não corresponde ao Id do Pedido" });
            }

            try
            {
                await _orderService.UpdateAsyn(order);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var order = await _orderService.FindByIdAsync(id.Value);

            if (order == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Pedido não encontrado" });
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Discount(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var order = await _orderService.FindByIdAsync(id.Value);

            if (order == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Pedido não encontrado" });
            }

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Discount(int id, Order order)
        {
            if (id != order.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id informado não corresponde ao Id do Pedido." });
            }

            try
            {
                int applyDiscount = await _orderService.ApplyDiscountAsync(order);

                if (applyDiscount == 0)
                {
                    return RedirectToAction(nameof(Error), new { message = "Pedidos vencidos não podem receber desconto."});
                }
                if (applyDiscount == 1)
                {
                    return RedirectToAction(nameof(Error), new { message = "O valor de desconto não pode ser maior que 30%." });
                }

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

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

    }
}
