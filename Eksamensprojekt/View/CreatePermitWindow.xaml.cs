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
using Eksamensprojekt.ViewModel;

namespace Eksamensprojekt.View
{
    /// <summary>
    /// Interaction logic for CreatePermitWindow.xaml
    /// </summary>
    public partial class CreatePermitWindow : Window
    {
        public int FacilityID;
        public SummaryVM vm;
        public CreatePermitWindow()
        {
            vm = new SummaryVM();
            DataContext = vm;
            InitializeComponent();
        }
        public CreatePermitWindow(int FacilityID)
        {
            vm = new SummaryVM(FacilityID);
            DataContext = vm;
            this.FacilityID = FacilityID;
            InitializeComponent();
        }
    }
}
