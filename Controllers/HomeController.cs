using AdventureWorksInventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CrudOperations;

namespace AdventureWorksInventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private InventoryDBcontext _dbcontext;

        public HomeController(ILogger<HomeController> logger, InventoryDBcontext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            var context = new Crud<Address>(_dbcontext);
            var result = context.GetAll();

            //var result = _dbcontext.SalesOrderDetail.ToList();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //public IEnumerable<SalesOrder>  GetSaleOrders()
        //{
        //    var result  = _dbcontext.SalesOrderDetail.ToList();
        //    return result;
        //}
    }
}
