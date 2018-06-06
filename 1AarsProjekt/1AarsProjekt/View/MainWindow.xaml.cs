using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.Model.CSV;
using _1AarsProjekt.View;
using _1AarsProjekt.Viewmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// <Author>
    /// Nicolai and Newjan
    /// </Author>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            CSVHandler handler = new CSVHandler();
            //AgreementMethods agreementMethods = new AgreementMethods();
            //handler.CreateCSV();

            //handler.CreateCSV();
            //Thread csvthread = new Thread(handler.CreateProductListToDB);
            //Thread csvthread = new Thread(handler.CreateCSV);
            //Thread agreeThread = new Thread(agreementMethods.ExpiredAgreements);


            //csvthread.Start();
            //agreeThread.Start();

            InitializeComponent();
            DataContext = new MainWindowVM();
        }
    }
}
