using SimpleMvcCRUDApp.Data.Models;
using System.Collections.Generic;

namespace SimpleMvcCRUDApp.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetAllProducts(int pageIndex, int pageSize);
    }
}
