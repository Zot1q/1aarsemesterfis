using _1AarsProjekt.Model.CSV;
using _1AarsProjekt.View;
using _1AarsProjekt.Viewmodel;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //CSVHandler handler = new CSVHandler();
            //handler.Main();
            //Thread thread = new Thread(handler.Main);
            //thread.Start();


            InitializeComponent();
            DataContext = new MainWindowVM();
        }
    }
}
