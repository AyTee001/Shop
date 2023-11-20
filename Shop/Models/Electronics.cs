using Shop.Models.Base;
using Shop.Models.Enums;

namespace Shop.Models
{
    public sealed class Electronics(double additionalServiceCost, string name, double price, string brand) : Product(name, price, brand)
    {
        public double AdditionalServiceCost { get; set; } = additionalServiceCost;

        public override double CalculatePrice()
        {
            return Price + AdditionalServiceCost;
        }

        public override string ToString()
        {
            return $"{Name} \n\t- Brand: {Brand} \n\t- Total for this item: {CalculatePrice():C}";
        }

    }
}
