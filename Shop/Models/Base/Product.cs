namespace Shop.Models.Base
{
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }

        public int Quantity { get; set; }
        protected Product(string name, double price, string brand)
        {
            Name = name;
            Price = price;
            Brand = brand;
            Quantity = 1;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Price: {Price:C}, Brand: {Brand}");
        }

        public abstract double CalculatePrice();
    }
}
