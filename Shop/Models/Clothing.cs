using Shop.Models.Base;
using Shop.Models.Enums;

namespace Shop.Models
{
    public class Clothing(double packPrice, Gender gender, Size size, string name, double price, string brand) : Product(name, price, brand)
    {
        public Gender Gender { get; set; } = gender;
        public Size Size { get; set; } = size;
        public double PackPrice { get; set; } = packPrice;

        public override double CalculatePrice()
        {
            return PackPrice + Price;
        }

        public override string ToString()
        {
            return $"{Name} \n\t- Brand: {Brand} \n\t- Department: {Gender} \n\t- Size: {Size} \n\t- Total for this item: {CalculatePrice():C}";
        }

    }
}
