using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleMvcCRUDApp.Data.Models;
using SimpleMvcCRUDApp.Repositories.Interfaces;

namespace SimpleMvcCRUDApp.Repositories.Classes
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        private readonly WarehouseContext _context;
        public SupplierRepository(WarehouseContext context) : base(context)
        {
        }

        public IEnumerable<Supplier> GetSuppliersByCountry(string country)
        {
            return _context.Suppliers.Where(s => s.Country == country);
        }
    }
}
