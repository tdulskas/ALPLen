﻿using System;
using System.Collections.Generic;
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

namespace ALPLen
{
    /// <summary>
    /// Interaction logic for AddDAC.xaml
    /// </summary>
    public partial class PrInfo : Window
    {
        public PrInfo()
        {
            InitializeComponent();
        }        

        private void PrInfo_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PrInfo_submit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
