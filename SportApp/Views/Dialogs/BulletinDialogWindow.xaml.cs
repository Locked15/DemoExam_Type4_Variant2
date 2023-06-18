using SportApp.Models.Entities;
using System.Linq;
using System.Windows;

namespace SportApp.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for BulletinDialogWindow.xaml.
    /// </summary>
    public partial class BulletinDialogWindow : Window
    {
        private Order _order;

        public BulletinDialogWindow(Order order)
        {
            _order = order;
            InitializeComponent();
        }

        /// <summary>
        /// This executes after window fully loaded.
        /// Inits text fields with values.
        /// </summary>
        /// <param name="sender">Object, that invoked this event.</param>
        /// <param name="e">Event arguments.</param>
        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            orderDateBox.Text = _order.DeliveryDate.ToString("dd.MM.yyyy");
            orderIdBox.Text = _order.Id.ToString();
            orderProductsBox.Text = string.Join(", ", _order.OrderProducts.Select(op => op.Product.Title));
            orderFinalCostBox.Text = $"{_order.FinalCost:0,00}Р.";
            orderFinalDiscountBox.Text = $"{_order.FinalDiscount:0,00}Р.";
            orderPickupPointBox.Text = _order.Point.ToString();
            orderTakeCodeBox.Text = _order.TakeCode.ToString();
            orderStatusBox.Text = DemoExamDataContext.Instance.OrderStatuses.FirstOrDefault(status => status.Id == _order.StatusId)?.Name ?? "Недоступен";
        }
    }
}
