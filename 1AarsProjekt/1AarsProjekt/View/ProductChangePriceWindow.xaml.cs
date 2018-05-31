using _1AarsProjekt.Viewmodel;
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

namespace _1AarsProjekt.View
{
    /// <summary>
    /// Interaction logic for ProductChangePriceWindow.xaml
    /// </summary>
    public partial class ProductChangePriceWindow : Window
    {
        public ProductChangePriceWindow()
        {
            InitializeComponent();
            DataContext = new ProductChangePriceVM();

        }
    }
}
