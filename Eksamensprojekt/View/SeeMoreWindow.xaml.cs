using Eksamensprojekt.Model;
using Eksamensprojekt.ViewModel;
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

namespace Eksamensprojekt.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SeeMoreWindow : Window
    {
        public SeeMoreWindow(Facility facility)
        {
            SummaryVM vm = new SummaryVM(facility);
            DataContext = vm;
            InitializeComponent();
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
