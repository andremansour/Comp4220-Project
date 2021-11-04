/* **********************************************************************************
 * For use by students taking 60-422 (Fall, 2014) to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using BookStoreLIB;
using System.Collections.ObjectModel;

namespace BookStoreGUI
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        DataSet dsBookCat;
        public static UserData userData;
        BookOrder bookOrder;
        LoginDialog dlg;
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            dlg = new LoginDialog();
            dlg.Owner = this;
            dlg.ShowDialog();
            // Process data entered by user if dialog box is accepted
            if (dlg.DialogResult == true)
            {
                if (userData.LogIn(dlg.nameTextBox.Text, dlg.passwordTextBox.Password) == true)
                    this.statusTextBlock.Text = "You are logged in as User #" +
                    userData.UserId;
                else
                    this.statusTextBlock.Text = "Your login failed. Please try again.";
            }
        }

        public int getUserId() {
            return userData.UserId;
        }

        private void accountButton_Click(object sender, RoutedEventArgs e)
        {
            if (userData.UserId != 0)
            {
                AccountDialog accDlg = new AccountDialog();
                accDlg.Owner = this;
                accDlg.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please login ");
                LoginDialog dlg = new LoginDialog();
                dlg.Owner = this;
                dlg.ShowDialog();
                if (dlg.DialogResult == true)
                {
                    if (userData.LogIn(dlg.nameTextBox.Text, dlg.passwordTextBox.Password) == true)
                        this.statusTextBlock.Text = "You are logged in as User #" +
                        userData.UserId;
                    else
                        this.statusTextBlock.Text = "Your login failed. Please try again.";
                }
            }
            
        }

        private void exitButton_Click(object sender, RoutedEventArgs e) { this.Close(); }
        public MainWindow() { InitializeComponent(); }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BookCatalog bookCat = new BookCatalog();
            dsBookCat = bookCat.GetBookInfo();
            this.DataContext = dsBookCat.Tables["Category"];
            bookOrder = new BookOrder();
            userData = new UserData();
            this.orderListView.ItemsSource = bookOrder.OrderItemList;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            OrderItemDialog orderItemDialog = new OrderItemDialog();
            DataRowView selectedRow;
            try
            {
                selectedRow = (DataRowView)this.ProductsDataGrid.SelectedItems[0];
                orderItemDialog.isbnTextBox.Text = selectedRow.Row.ItemArray[0].ToString();
                orderItemDialog.titleTextBox.Text = selectedRow.Row.ItemArray[2].ToString();
                orderItemDialog.priceTextBox.Text = selectedRow.Row.ItemArray[4].ToString();
                orderItemDialog.Owner = this;
                orderItemDialog.ShowDialog();
                if (orderItemDialog.DialogResult == true)
                {
                    string isbn = orderItemDialog.isbnTextBox.Text;
                    string title = orderItemDialog.titleTextBox.Text;
                    double unitPrice = double.Parse(orderItemDialog.priceTextBox.Text);
                    int quantity = int.Parse(orderItemDialog.quantityTextBox.Text);
                    bookOrder.AddItem(new OrderItem(isbn, title, unitPrice, quantity));
                }
            }
            catch (Exception ex)
            {
                string message = "Please select an item.";
                MessageBox.Show(message);

            }
        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.orderListView.SelectedItem != null)
            {
                var selectedOrderItem = this.orderListView.SelectedItem as OrderItem;
                bookOrder.RemoveItem(selectedOrderItem.BookID);
            }
        }
        private void chechoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (bookOrder.GetOrderTotal() != 0 && userData.UserId != 0) //user is logged in and order cart is not empty
            {
                int orderId;
                orderId = bookOrder.PlaceOrder(userData.UserId);
                MessageBox.Show("Your order has been placed. Your order id is " +
                orderId.ToString());

            }
            else if (userData.UserId == 0) //user is not logged in
            {
                MessageBox.Show("Please login ");
                LoginDialog dlg = new LoginDialog();
                dlg.Owner = this;
                dlg.ShowDialog();
                if (dlg.DialogResult == true)
                {
                    if (userData.LogIn(dlg.nameTextBox.Text, dlg.passwordTextBox.Password) == true)
                        this.statusTextBlock.Text = "You are logged in as User #" +
                        userData.UserId;
                    else
                        this.statusTextBlock.Text = "Your login failed. Please try again.";
                }
            }
            else {
                MessageBox.Show("Order is empty");
            }
        }

        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            this.txtTotal.Text = bookOrder.GetOrderTotal().ToString();
        }
    }
}
