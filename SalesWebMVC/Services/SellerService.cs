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



        // Método para inserir o cadastro no banco de dados, referente a página de criar novo/vendedores
        public void Insert(Seller obj)
        {
            _context.Add(obj); // Só esta ação não confirma, apenas insere no bd
            _context.SaveChanges(); // Esta ação confirma a alteração acima
        }


        //Deletar Seller
        public Seller FindById(int id)
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges(); // Salvar remoção no banco
        }



    }
}
