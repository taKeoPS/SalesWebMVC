using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerSevice)
        {
            _sellerService = sellerSevice;
        }

        public IActionResult Index() // chamou o controlador
        {
            var list = _sellerService.FindAll(); // controlador acessou o model, coletou os dados
            return View(list); // encaminhou os dados para a view
        }
    }
}
