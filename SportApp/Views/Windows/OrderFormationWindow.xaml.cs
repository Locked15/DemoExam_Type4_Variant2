using SportApp.Models.Entities;
using SportApp.Views.Dialogs;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SportApp.Views.Windows
{
    /// <summary>
    /// Interaction logic for OrderFormationWindow.xaml.
    /// </summary>
    public partial class OrderFormationWindow : Window
    {
        public Order CurrentOrder { get; init; }

        public OrderFormationWindow(Order order)
        {
            CurrentOrder = order;

            InitializeComponent();
            DataContext = CurrentOrder;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            pickupPointSelector.ItemsSource = DemoExamDataContext.Instance.PickupPoints.ToList();
            UpdateWindow();
        }

        private void UpdateWindow()
        {
            if (!CurrentOrder.OrderProducts.Any())
                Close();

            productsInOrderList.SelectedIndex = -1;
            productsInOrderList.ItemsSource = null;
            productsInOrderList.ItemsSource = CurrentOrder.OrderProducts;

            UpdateFields();
        }

        private void UpdateFields()
        {
            var finalDiscount = CurrentOrder.FinalDiscount;
            var finalCost = CurrentOrder.FinalCost;

            finalDiscountBox.Text = $"{finalDiscount:0,00}Р";
            finalCostBox.Text = $"{finalCost:0,00}Р";
        }

        private void OnAddToOrderMenuItemClick(object sender, RoutedEventArgs e)
        {
            if (productsInOrderList.SelectedItem is OrderProduct orderProduct)
            {
                CurrentOrder.TryToAddNewProduct(orderProduct.Product);
                UpdateFields();
            }
        }

        private void OnProductsInOrderListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productsInOrderList.SelectedItem is OrderProduct orderProduct)
            {
                productCountInputBox.Text = orderProduct.Count.ToString();

                productCountLabel.Visibility = Visibility.Visible;
                productCountInputBox.Visibility = Visibility.Visible;
                removeProductFromOrderButton.Visibility = Visibility.Visible;
            }
            else
            {
                productCountInputBox.Text = string.Empty;

                productCountLabel.Visibility = Visibility.Hidden;
                productCountInputBox.Visibility = Visibility.Hidden;
                removeProductFromOrderButton.Visibility = Visibility.Hidden;
            }
        }

        private void OnProductCountInputBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var text = productCountInputBox.Text;
            if (productsInOrderList.SelectedItem is OrderProduct orderProduct)
            {
                var originalCount = orderProduct.Count;
                if (int.TryParse(text, out int newCount))
                {
                    if (newCount <= 0)
                    {
                        var confirm = MessageBox.Show("Такое количество приведёт к удалению товара из заказа.\n\nПродолжить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (confirm == MessageBoxResult.Yes)
                        {
                            CurrentOrder.SetProductCount(orderProduct.Product, newCount);
                            UpdateWindow();
                        }
                        else
                        {
                            productCountInputBox.Text = originalCount.ToString();
                        }
                    }
                    else
                    {
                        CurrentOrder.SetProductCount(orderProduct.Product, newCount);
                        UpdateFields();
                    }
                }
                else
                {
                    MessageBox.Show("Введено некорректное значение.\nСброс...", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    productCountInputBox.Text = originalCount.ToString();
                }
            }
        }

        private void OnGetBulletinButtonClick(object sender, RoutedEventArgs e)
        {
            if (CurrentOrder.Id == default)
                MessageBox.Show("Заказ ещё не сохранён. Талон недоступен.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                new BulletinDialogWindow(CurrentOrder).ShowDialog();
        }

        private void OnSaveOrderButtonClick(object sender, RoutedEventArgs e)
        {
            if (CurrentOrder.Point != null)
            {
                PrepareOrder();
                try
                {
                    if (CurrentOrder.Id == default)
                    {
                        DemoExamDataContext.Instance.Orders.Add(CurrentOrder);
                        DemoExamDataContext.Instance.OrderProducts.AddRange(CurrentOrder.OrderProducts);

                        DemoExamDataContext.Instance.SaveChanges();
                        if (MessageBox.Show("Заказ создан. Просмотреть талон?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            OnGetBulletinButtonClick(default, default);
                    }
                    else
                    {
                        DemoExamDataContext.Instance.SaveChanges();
                        MessageBox.Show("Заказ обновлён.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка сохранения.\n\nДетали:\n{ex.Message}.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать точку доставки.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PrepareOrder()
        {
            var allProductsAreAvailable = CurrentOrder.OrderProducts.All(op => op.Product.Amount > 3);
            CurrentOrder.DeliveryDate = CurrentOrder.OrderDate.AddDays(allProductsAreAvailable ? 3 : 6);
        }

        private void OnRemoveProductFromOrderButtonClick(object sender, RoutedEventArgs e)
        {
            if (productsInOrderList.SelectedItem is OrderProduct orderProduct)
            {
                var result = MessageBox.Show("Вы точно хотите удалить товар из заказа?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    CurrentOrder.SetProductCount(orderProduct.Product, 0);
                    productsInOrderList.SelectedIndex = -1;

                    UpdateWindow();
                }
            }
        }

        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e) =>
                DialogResult = CurrentOrder.Id != default;
    }
}
