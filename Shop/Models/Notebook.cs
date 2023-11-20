using Shop.Models.Base;
using Shop.Models.Enums;

namespace Shop.Models
{
    public class Notebook(Format format, string name, double price, string brand) : Product(name, price, brand)
    {
        public Format Format { get; set; } = format;

        public override double CalculatePrice()
        {
            return Price;
        }

        public override string ToString()
        {
            return $"{Name} \n\t- Brand: {Brand} \n\t- Format: {Format} \n\t -Total for this item: {CalculatePrice():C}";
        }

    }
}
