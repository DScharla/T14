using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Eksamensprojekt.Model;
using Eksamensprojekt.ViewModel;

namespace Eksamensprojekt.View
{
    /// <summary>
    /// Interaction logic for SummaryWindow.xaml
    /// </summary>
    public partial class SummaryWindow : Window
    {
        public SummaryWindow()
        {

            SummaryVM svm = new SummaryVM();
            DataContext = svm;
            InitializeComponent();
            if (svm.CloseAction == null)
                svm.CloseAction = new Action(this.Close);
        }

    }
}
