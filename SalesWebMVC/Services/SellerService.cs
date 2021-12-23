using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context; // declarando dependencia

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }
        // Injeção de dependencia...

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        




    }
}
