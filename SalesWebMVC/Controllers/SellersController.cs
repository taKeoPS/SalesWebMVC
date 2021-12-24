using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
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

        public IActionResult Create()
        {
            return View();
        }


        // Ação CREATE tipo POST para que o formulário de cadastro de vendedores seja enviado...
        [HttpPost] // Anotation para informar que é POST
        [ValidateAntiForgeryToken] // Anotation prevenir que a aplicação sofra ataque CSRF, quando alguem aproveita a sessão para enviar dados maliciosos
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index)); //Redirecionar de volta para a página Index
        }



    }
}
