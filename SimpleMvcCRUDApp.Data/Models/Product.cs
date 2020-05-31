namespace SimpleMvcCRUDApp.Data.Models
{
    public partial class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public long? CategoryId { get; set; }
        public long? ManufacturerId { get; set; }
        public long? SupplierId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
