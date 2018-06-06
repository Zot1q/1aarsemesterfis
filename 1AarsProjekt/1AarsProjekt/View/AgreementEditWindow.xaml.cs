﻿using _1AarsProjekt.Viewmodel;
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
    /// <Author>
    /// Nicolai and Newjan
    /// </Author>
    /// <summary>
    /// Interaction logic for AgreementEditWindow.xaml
    /// </summary>
    public partial class AgreementEditWindow : Window
    {
        public AgreementEditWindow(object selectedAgreement)
        {
            InitializeComponent();
            DataContext = new AgreementEditVM(selectedAgreement);
        }
    }
}
