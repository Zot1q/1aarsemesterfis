using _1AarsProjekt.Model.AgreementManagement;
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
    /// Interaction logic for AgreementWindow.xaml
    /// </summary>
    public partial class AgreementWindow : Page
    {
        AgreementMethods agreement = new AgreementMethods();
        public AgreementWindow()
        {
            InitializeComponent();
        }

        private void btn_CreateAgreement_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
