using System;
using System.Collections.Generic;
using System.Text;
using SimpleMvcCRUDApp.Data.Models;

namespace SimpleMvcCRUDApp.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetSuppliersByCountry(string country);
    }
}
