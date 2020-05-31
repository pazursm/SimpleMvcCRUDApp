using SimpleMvcCRUDApp.Data.Models;
using SimpleMvcCRUDApp.Repositories.Interfaces;

namespace SimpleMvcCRUDApp.Repositories.Classes
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerReposiroty
    {
        private readonly WarehouseContext _context;
        public ManufacturerRepository(WarehouseContext context) : base(context)
        {
        }
    }
}
