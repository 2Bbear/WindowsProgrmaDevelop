﻿using System;
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
using Tutorial_0218.DataBindingOneWay;

namespace Tutorial_0218
{
    /// <summary>
    /// Databinding_OneWay.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Databinding_OneWay : Window
    {
        public Databinding_OneWay()
        {
            InitializeComponent();
            DataContext = Employee.GetEmployee();
        }
    }
}
