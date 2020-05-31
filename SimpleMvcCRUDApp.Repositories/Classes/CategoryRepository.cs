using SimpleMvcCRUDApp.Data.Models;
using SimpleMvcCRUDApp.Repositories.Interfaces;

namespace SimpleMvcCRUDApp.Repositories.Classes
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly WarehouseContext _context;

        public CategoryRepository(WarehouseContext context) : base(context)
        {
            this._context = context;
        }
    }
}
