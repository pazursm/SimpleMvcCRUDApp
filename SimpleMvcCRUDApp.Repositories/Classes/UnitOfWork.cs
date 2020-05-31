using SimpleMvcCRUDApp.Data.Models;
using SimpleMvcCRUDApp.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace SimpleMvcCRUDApp.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WarehouseContext _context;
        private bool disposed = false;

        public ProductRepository ProductRepository { get; private set; }
        public CategoryRepository CategoryRepository { get; private set; }
        public ManufacturerRepository ManufacturerRepository { get; private set; }
        public SupplierRepository SupplierRepository { get; private set; }


        public UnitOfWork(WarehouseContext context)
        {
            _context = context;
            this.ProductRepository = new ProductRepository(_context);
            this.CategoryRepository = new CategoryRepository(_context);
            this.ManufacturerRepository = new ManufacturerRepository(_context);
            this.SupplierRepository = new SupplierRepository(_context);
        }

        public async Task Commit()
        {
            await this._context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
