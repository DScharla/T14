using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Eksamensprojekt.Model;
using System.Windows.Navigation;
using Eksamensprojekt.View;
using System.Windows;
using System.Threading.Channels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;



namespace Eksamensprojekt.ViewModel 
{
    public class SummaryVM : INotifyPropertyChanged
    {
        //cla rød/grøn test ***
        private Brush _color = Brushes.Red;
        public Brush Color
        {
            get { return _color; }
            set
            { _color = value; }
        }
        //cla rød/grøn test ***

        private string _name = string.Empty;
        public string Name {  
            get { return _name; } 
            set { _name = value; }}

        private string _UDLNumber = string.Empty;
        public string UDLNumber
        {
            get { return _UDLNumber; }
            set { _UDLNumber = value; }
        }

        private string _OBNumber = string.Empty;
        public string OBNumber
        {
            get { return _OBNumber; }
            set { _OBNumber = value; }
        }

        private string _system = string.Empty;
        public string System
        {
            get { return _system; }
            set { _system = value; }
        }

        private string _minimumPoolSize = string.Empty;
        public string MinimumPoolSize
        {
            get { return _minimumPoolSize; }
            set { _minimumPoolSize = value; }
        }

        private DateTime _startDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        private DateTime? _endDate = null;
        public DateTime? EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        private string _allowedYearlyIncidents = string.Empty;
        public string AllowedYearlyIncidents
        {
            get { return _allowedYearlyIncidents; }
            set { _allowedYearlyIncidents = value; }
        }

        private string _allowedYearlyOverflowVolume = string.Empty;
        public string AllowedYearlyOverflowVolume
        {
            get { return _allowedYearlyOverflowVolume; }
            set { _allowedYearlyOverflowVolume = value; }
        }

        private string _additionalRestriction = string.Empty;
        public string AdditionalRestriction
        {
            get { return _additionalRestriction; }
            set { _additionalRestriction = value; }
        }
        private string _equipmentRestriction = string.Empty;
        public string EquipmentRestriction
        {
            get { return _equipmentRestriction; }
            set { _equipmentRestriction = value; }
        }
        private string _measurementRestriction = string.Empty;
        public string MeasurementRestriction
        {
            get { return _measurementRestriction; }
            set { _measurementRestriction = value; }
        }

        private string _maintenanceRestriction = string.Empty;
        public string MaintenanceRestriction
        {
            get { return _maintenanceRestriction; }
            set { _maintenanceRestriction = value; }
        }

        private ObservableCollection<string> _equipmentRestrictionCollection;

        public ObservableCollection<string> EquipmentRestrictionCollection
        {
            get { return _equipmentRestrictionCollection; }
            set { _equipmentRestrictionCollection = value; }
        }

        private ObservableCollection<string> _measurementRestrictionCollection;

        public ObservableCollection<string> MeasurementRestrictionCollection
        {
            get { return _measurementRestrictionCollection; }
            set { _measurementRestrictionCollection = value; }
        }

        private ObservableCollection<string> _maintenanceRestrictionCollection;

        public ObservableCollection<string> MaintenanceRestrictionCollection
        {
            get { return _maintenanceRestrictionCollection; }
            set { _maintenanceRestrictionCollection = value; }
        }

        private ObservableCollection<string> _systemOptions;

        public ObservableCollection<string> SystemOptions
        {
            get { return _systemOptions; }
            set { _systemOptions = value; }
        }

        private Facility facility;
        //DCD: +1
        private FacilityService _facilityService;

        private ObservableCollection<Facility> _facilities;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public ObservableCollection<Facility> Facilities
        {
            get
            {
                return _facilities;
            }
            set
            {
                _facilities = value;
                NotifyPropertyChanged();
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") 
        { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        public RelayCommand CreateFacilityCommand => new RelayCommand(
            execute => OpenCreateFacilityWindow(),
            canExecute => { return true; }
            );
        public RelayCommand AddFacilityCommand => new RelayCommand(
            execute => AddFacility(),
            canExecute => { return true; }
            );

        public RelayCommand AddPermitCommand => new RelayCommand(
            execute => AddPermit(),
            canExecute => { return true; }
            );
        
        //DCD: +1
        public SummaryVM()
        {
            _facilityService = new FacilityService();
            _facilities = new ObservableCollection<Facility>();
            ShowFacilities();
            _equipmentRestrictionCollection = GetRestrictionOptions("EQUIPMENTRESTRICTION");
            _measurementRestrictionCollection = GetRestrictionOptions("MEASUREMENTRESTRICTION");
            _maintenanceRestrictionCollection = GetRestrictionOptions("MAINTENANCERESTRICTION");
            _systemOptions = GetRestrictionOptions("SYSTEM");// - skal der være en getOptions metode for systems - skal de 3 metodekald herover samles i én metode?
        }

        
        public SummaryVM(Facility facility)
        {
            _facilityService = new FacilityService();
            _facilities = new ObservableCollection<Facility>();
            ShowFacilities();
            this.facility = facility;
            _equipmentRestrictionCollection = GetRestrictionOptions("EQUIPMENTRESTRICTION");
            _measurementRestrictionCollection = GetRestrictionOptions("MEASUREMENTRESTRICTION");
            _maintenanceRestrictionCollection = GetRestrictionOptions("MAINTENANCERESTRICTION");
            
            
        }
        
        //DCD: private
        private void ShowFacilities()
        {
            ObservableCollection<Facility> tempFacilities = _facilityService.GetAllData();

            foreach (Facility facility in tempFacilities)
            {
                DateTime now = new DateTime();
                now = DateTime.Now;
               
                ObservableCollection<Permit> tempRestrictions = new ObservableCollection<Permit>(); 
                foreach (Permit restriction in facility.Permits)
                {
                    if (now > restriction.StartDate) { tempRestrictions.Add(restriction); }
                }

                tempRestrictions.OrderByDescending(tempRestrictions => tempRestrictions.StartDate);
                facility.Permits = tempRestrictions;
                Facilities.Add(facility);
            }
        }

        public void OpenCreateFacilityWindow()
        {
            CreateFacilityWindow facilityWindow = new CreateFacilityWindow();
            //CloseAction();
            facilityWindow.Show();
            
            
        }
        public void AddFacility()
        {
            Facility facility = FromStringToFacility();
            facility.ID = _facilityService.AddToFacilityRepo(facility);
            ShowFacilities();
            CreatePermitWindow permitWindow = new CreatePermitWindow(facility);
            permitWindow.Show();
            ShowFacilities();
            CloseAction();
            
            //Tilføjelse af 
        }
        


        
        public void AddPermit()
        {
            /* CreatePermitWindow permitWindow = new CreatePermitWindow(facility);
            permitWindow.Show();            */
            Permit permit = FromStringToPermit();
            _facilityService.AddToPermitRepo(permit);
            string messageBoxText = "Tilladelsen er gemt"; 
            string caption = "Succes"; 
            MessageBoxButton button = MessageBoxButton.OK; 
            MessageBoxImage icon = MessageBoxImage.Exclamation; 
            MessageBoxResult result; 
            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            ShowFacilities();
            CloseAction();

            


            //Tilføjelse af 
        }

        public Action CloseAction { get; set; }

        public Facility FromStringToFacility()
        {
            Facility facility = new Facility();
            facility.Name = Name;
            facility.UDLNumber = UDLNumber;
            facility.OBNumber = OBNumber;
            facility.System = System;
            facility.MinimumPoolSize = MinimumPoolSize;
            return facility;
        }
        public Permit FromStringToPermit()
        {
            Permit permit = new Permit();
            permit.StartDate = StartDate;
            try { permit.EndDate = EndDate; }
            catch { permit.EndDate = null; }
            permit.AllowedYearlyIncidents = Int32.Parse(AllowedYearlyIncidents);
            permit.AllowedYearlyOverflowVolume = Int32.Parse(AllowedYearlyOverflowVolume);
            permit.AdditionalRestriction = AdditionalRestriction;
            permit.MaintenanceRestriction = MaintenanceRestriction;
            permit.MeasurementRestriction = MeasurementRestriction;
            permit.EquipmentRestriction = EquipmentRestriction;
            permit.FacilityID = facility.ID;
            return permit;
        }
        public ObservableCollection<string> GetRestrictionOptions(string NameOfRestrictions)
        {
            ObservableCollection<string> restrictionOptions = new ObservableCollection<string>();
            restrictionOptions=_facilityService.GetRestrictionOptionsFromRepo(NameOfRestrictions);
            return restrictionOptions;
        }
    }
}
