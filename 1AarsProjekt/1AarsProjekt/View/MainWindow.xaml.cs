using _1AarsProjekt.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1AarsProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomerManagementWindow custWin = new CustomerManagementWindow();
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void Btn_Agreement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Subscription_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Product_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Customer_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = custWin;
        }

        private void Btn_CustomerCreate_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = custWin;
        }
    }
}
