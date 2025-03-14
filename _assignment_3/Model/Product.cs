namespace Assignment3.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }  // Ensure you have a 'Price' property
        public decimal ShippingCost { get; set; }
    }
}
