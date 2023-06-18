using SportApp.Models.Entities;
using System.Linq;
using System.Windows;

namespace SportApp.Views.Windows
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml.
    /// This is the first window, that sees user.
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Executes, when user leaves any key.
        /// Used for make auth possible via Enter key.
        /// </summary>
        /// <param name="sender">Object, that invokes this event.</param>
        /// <param name="e">Event arguments.</param>
        private void OnWindowKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
                OnTryToLogInButtonClick(default, default);
        }

        private void OnTryToLogInButtonClick(object sender, RoutedEventArgs e)
        {
            var login = loginInputBox.Text;
            var password = passwordInputBox.Password;

            /* Here we try to found target user. If user is found, it will be written to variable 'user'. 
               Otherwise result will be NULL and can't be casted to 'User' type. */
            if (DemoExamDataContext.Instance.Users.FirstOrDefault(user => user.Login == login &&
                                                                          user.Password == password) is User user)
            {
                GoToProductsListWindow(user);
            }
            else
            {
                MessageBox.Show("Аккаунт с указанными данными не найден.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void OnContinueAsGuestButtonClick(object sender, RoutedEventArgs e) =>
                GoToProductsListWindow(null);

        private void GoToProductsListWindow(User? user)
        {
            var newOrder = Order.GenerateNewOrderByUser(user);
            var newWindow = new ProductsWindow(newOrder);

            newWindow.Show();
            Close();
        }
    }
}
