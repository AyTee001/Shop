using Shop.Commands;
using Shop.Models;
using Shop.Models.Base;
using Shop.Models.Enums;
using Shop.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Shop.ViewModels
{
    public class ShopViewModel : ViewModelBase
    {
        private string _address = string.Empty;

        private double _total = 0;

        private void Products_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Total = _products.Sum(x => x.Quantity * x.CalculatePrice());
        }

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public double Total
        {
            get => _total;
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        public List<Clothing> ClothingList { get; } = new List<Clothing>
    {
        new Clothing(10, Gender.Men, Size.M, "T-shirt", 200, "Adidas"),
        new Clothing(15, Gender.Women, Size.S, "Dress", 300, "Nike")
    };

        public List<Notebook> NotebooksList { get; } = new List<Notebook>
    {
        new Notebook(Format.A4, "School notebook", 50, "Mria"),
        new Notebook(Format.A4, "Office planner", 100, "Nota Bene"),
    };

        public List<Electronics> ElectronicsList { get; } = new List<Electronics>
    {
        new Electronics(50, "Laptop", 1000, "Lenovo"),
        new Electronics(30, "IPhone", 500, "Apple")
    };

        public ICommand AddToCart { get; }
        public ICommand MakeOrderOrDiscard { get; }

        public ShopViewModel()
        {
            _products = [];

            Products.CollectionChanged += Products_CollectionChanged;

            AddToCart = new RelayCommand(
                executeAction: (param) =>
                {
                    var prod = param as Product;
                    Products.Add(prod!);
                },
                canExecuteFunc => true);

            MakeOrderOrDiscard = new RelayCommand(
                executeAction =>
                {
                    Total = 0;
                    Address = "";
                    Products.Clear();
                },
                canExecuteFunc => true);
        }
    }
}
