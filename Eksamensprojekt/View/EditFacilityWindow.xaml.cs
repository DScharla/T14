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
using Eksamensprojekt.Model;
using Eksamensprojekt.ViewModel;

namespace Eksamensprojekt.View
{
    /// <summary>
    /// Interaction logic for CreateFacilityWindow.xaml
    /// </summary>
    public partial class EditFacilityWindow : Window
    {
        public EditFacilityWindow(Facility facility)
        {
            SummaryVM vm = new SummaryVM(facility);
            DataContext = vm;
            InitializeComponent();
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
