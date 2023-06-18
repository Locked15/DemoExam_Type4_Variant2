using SportApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SportApp.Views.Windows
{
    /// <summary>
    /// Interaction logic for ProductsWindow.xaml.
    /// </summary>
    public partial class ProductsWindow : Window
    {
        private List<Product> _selectedProducts = null!;

        public Order CurrentOrder { get; private set; }

        public ProductsWindow(Order order)
        {
            CurrentOrder = order;
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            UpdateControlsVisibility();

            searchBox.TextChanged += OnSearchBoxTextChanged;
            searchBox.Text = string.Empty;
        }

        private void UpdateControlsVisibility()
        {
            if (!CurrentOrder.OrderProducts.Any())
                orderButton.Visibility = Visibility.Hidden;
            else
                orderButton.Visibility = Visibility.Visible;
        }

        private void OnSearchBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            _selectedProducts = DemoExamDataContext.Instance.Products.ToList();
            if (searchBox.Text is string search && !string.IsNullOrWhiteSpace(search))
            {
                _selectedProducts = _selectedProducts.Where(product => product.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                                                       product.Description?.Contains(search, StringComparison.OrdinalIgnoreCase) == true).ToList();
            }

            productsList.ItemsSource = _selectedProducts;
            if (!_selectedProducts.Any())
                MessageBox.Show("По запросу ничего не найдено.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnProductsListItemDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (productsList.SelectedItem is Product product)
            {
                CurrentOrder.TryToAddNewProduct(product);
                MessageBox.Show($"К заказу добавлено: {product.Title}.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                UpdateControlsVisibility();
                productsList.SelectedIndex = -1;
            }
        }

        private void OnProductItemContextMenuClick(object sender, RoutedEventArgs e)
        {
            if (productsList.SelectedItem is Product product)
            {
                CurrentOrder.TryToAddNewProduct(product);

                productsList.SelectedIndex = -1;
                UpdateControlsVisibility();
            }
        }

        private void OnOrderButtonClick(object sender, RoutedEventArgs e)
        {
            // DialogResult is a Nullable-Variable, so we must check explicitly.
            var newWindow = new OrderFormationWindow(CurrentOrder);
            if (newWindow.ShowDialog() == true)
            {
                CurrentOrder = Order.GenerateNewOrderByUser(CurrentOrder.User);
                MessageBox.Show("Начато формирование нового заказа.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                CurrentOrder = newWindow.CurrentOrder;
            }

            UpdateControlsVisibility();
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e) => Close();

        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e) => new AuthWindow().Show();
    }
}
