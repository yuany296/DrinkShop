using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DrinkShop
{
    public class CartItem : INotifyPropertyChanged
    {
        private int _drinkId;
        private string _name;
        private decimal _price;
        private int _quantity;

        public int DrinkId
        {
            get => _drinkId;
            set { _drinkId = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public decimal Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(); }
        }

        public int Quantity
        {
            get => _quantity;
            set { _quantity = value; OnPropertyChanged(); OnPropertyChanged(nameof(Subtotal)); }
        }

        public decimal Subtotal => Price * Quantity;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"{Name} × {Quantity} = {Subtotal:C}";
        }
    }
}