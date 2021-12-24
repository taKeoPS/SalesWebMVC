using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

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


        //Buscar por ID Seller, usado no Deletar e Alterar
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);  //o INCLUDE é como se fizesse um JOIN na consulta no banco. namespace entityframework
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges(); // Salvar remoção no banco
        }


        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges(); // quando chama essa ação no DB, pode retornar uma exceção de conflito de concorrencia, retornando a exceção "DbConcurrencyException"
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}
