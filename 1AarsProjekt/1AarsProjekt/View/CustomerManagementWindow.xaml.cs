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

namespace _1AarsProjekt.View
{
    /// <summary>
    /// Interaction logic for CustomerManagementWindow.xaml
    /// </summary>
    public partial class CustomerManagementWindow : Page
    {
        public CustomerManagementWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //CreateCustomer(txtName.Text);
        }

        public void CreateCustomer() { }
    }
}
