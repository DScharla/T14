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
using Eksamensprojekt.ViewModel;
using Eksamensprojekt.Model;

namespace Eksamensprojekt.View
{
    /// <summary>
    /// Interaction logic for CreatePermitWindow.xaml
    /// </summary>
    public partial class CreatePermitWindow : Window
    {
        public SummaryVM vm;
/*        public CreatePermitWindow()
        {
            vm = new SummaryVM();
            DataContext = vm;
            InitializeComponent();
        }*/
        public CreatePermitWindow(Facility facility)
        {
            vm = new SummaryVM(facility);
            DataContext = vm;
            InitializeComponent();
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }

        
    }
}
