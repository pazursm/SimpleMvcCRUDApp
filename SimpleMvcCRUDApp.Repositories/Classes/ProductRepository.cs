using SimpleMvcCRUDApp.Data.Models;
using SimpleMvcCRUDApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SimpleMvcCRUDApp.Repositories.Classes
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly WarehouseContext _context;
        public ProductRepository(WarehouseContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            //vraca listu objekata klijentu
            return _context.Products.Include("Category").Include("Manufacturer").Include("Supplier");
        }

        public IEnumerable<Product> GetAllProducts(int pageIndex, int pageSize)
        {
            //pageIndex i pageSize mozda u neki layer iznad...
            return _context.Products.Include("Category").Include("Manufacturer").Include("Supplier")
                .OrderBy(p => p.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
