using System.Collections.ObjectModel;
using System.Windows;

namespace PR_20
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> Cart { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Хлеб", Quantity = 3 },
                new Product { Name = "Молоко", Quantity = 5 },
                new Product { Name = "Яблоки", Quantity = 2 },
                new Product { Name = "Сыр", Quantity = 1 }
            };

            Cart = new ObservableCollection<Product>();

            DataContext = this;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ShopList.SelectedItem is Product selectProduct)
            {
                if (selectProduct.Quantity > 0)
                {
                    selectProduct.Quantity--;
                    foreach (var item in Cart)
                    {
                        if (item.Name == selectProduct.Name)
                        {
                            item.Quantity++;
                            DataContext = null;
                            DataContext = this;
                            return;
                        }
                    }
                    Cart.Add(new Product { Name = selectProduct.Name, Quantity = 1 });
                }
                else
                {

                    MessageBox.Show("Товар закончился!");
                    Products.Remove(selectProduct);

                }

            }
            DataContext = null;
            DataContext = this;
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            var purchaseList = string.Join("\n", Cart.Select(item => item.cartfinal));
            MessageBox.Show($"Спасибо за покупку!\n\n Ваши покупки:\n{purchaseList}");
        }
    }
}