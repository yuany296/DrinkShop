using System.ComponentModel;
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
            set { _quantity = value; OnPropertyChanged(); OnPropertyChanged(nameof(Subtotal)); OnPropertyChanged(nameof(DisplayText)); }
        }

        public decimal Subtotal => Price * Quantity;

        // 添加DisplayText属性用于显示
        public string DisplayText => $"{Name} × {Quantity} = ￥{Subtotal:F2}";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
