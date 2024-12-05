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

        private string _incidentsCompliance;
        public string IncidentsCompliance
        {
            get { return _incidentsCompliance; }
            set { _incidentsCompliance = value; }
        }

        private string _overflowCompliance;

        public string OverflowCompliance
        {
            get { return _overflowCompliance; }
            set { _overflowCompliance = value; }
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

        private Facility? _facility;
        public Facility? Facility
        {
            get { return _facility; }
            set { _facility = value; }
        }
        //DCD: +1
        private FacilityService _facilityService;

        private ObservableCollection<Facility> _facilities;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                OnPropertyChanged();
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
        public RelayCommand OpenCreatePermitWindowWithSelectedFacilityCommand => new RelayCommand(
            execute => OpenCreatePermitWindowWithSelectedFacility(),
            canExecute => { return IsSelectedNull(Facility); }
            );
       
        public RelayCommand CancelAndCloseCurrentCommand => new RelayCommand(
            execute => CancelAndCloseCurrent(),
            canExecute => { return true; }
            );
            
        public RelayCommand EditFacilityCommand => new RelayCommand(
           execute => EditFacility(),
           canExecute => { return IsSelectedNull(Facility); }
           );
        public RelayCommand SaveEditFacilityCommand => new RelayCommand(
           execute => SaveEditFacility(),
           canExecute => { return true; }
           );
        public RelayCommand SeeMoreWindowCommand => new RelayCommand(
            execute => SeeMore(),
            canExecute => { return true; }
            );

        public RelayCommand PermitOneActiveCommand => new RelayCommand(
            execute => SetPermitAsCurrent(0),
            canExecute => { return true; }
            );

        public RelayCommand PermitTwoActiveCommand => new RelayCommand(
            execute => SetPermitAsCurrent(1),
            canExecute => { return true; }
            );

        public void SetPermitAsCurrent(int index)
        {
            CurrentPermit = Facility.Permits[index];
        }

        private Permit _currentPermit;

        public Permit CurrentPermit
        {
            get { return _currentPermit; }
            set { _currentPermit = value; OnPropertyChanged(); }
        }

        public RelayCommand RemoveFacilityCommand => new RelayCommand(
            execute => RemoveFacility(),
            canExecute => { return IsSelectedNull(Facility); }
            );

        //DCD: +1
        public SummaryVM()
        {
            _facilityService = new FacilityService();
            Facilities = new ObservableCollection<Facility>();
            ShowFacilities();
/*            _equipmentRestrictionCollection = GetRestrictionOptions("EQUIPMENTRESTRICTION");
            _measurementRestrictionCollection = GetRestrictionOptions("MEASUREMENTRESTRICTION");
            _maintenanceRestrictionCollection = GetRestrictionOptions("MAINTENANCERESTRICTION");*/
            _systemOptions = GetRestrictionOptions("SYSTEM");// - skal der være en getOptions metode for systems - skal de 3 metodekald herover samles i én metode?
        }

        
        public SummaryVM(Facility facility)
        {
            _facilityService = new FacilityService();
            _facilities = new ObservableCollection<Facility>();
            ShowFacilities();
            Facility = facility;
            _equipmentRestrictionCollection = GetRestrictionOptions("EQUIPMENTRESTRICTION");
            _measurementRestrictionCollection = GetRestrictionOptions("MEASUREMENTRESTRICTION");
            _maintenanceRestrictionCollection = GetRestrictionOptions("MAINTENANCERESTRICTION");
            _systemOptions = GetRestrictionOptions("SYSTEM");
            SetPermitAsCurrent(0);

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
                

                facility.IncidentsCompliance = CheckIncidentsCompliance(facility);
                facility.OverflowCompliance = CheckOverflowCompliance(facility);

                
                Facilities.Add(facility);
            }
        }

        
        public string CheckIncidentsCompliance(Facility facility)
        {
            if (facility.Permits.Count > 0 && facility.NumberOfIncidents > facility.Permits[0].AllowedYearlyIncidents)
            {
                return "Red";
            }
            return "Green";
        }

        public string CheckOverflowCompliance(Facility facility)
        {
            if (facility.Permits.Count > 0 && facility.TotalOverflow > facility.Permits[0].AllowedYearlyOverflowVolume)
            {
                return "Red";
            }
            return "Green";
        }
        

        public void OpenCreateFacilityWindow()
        {
            CreateFacilityWindow facilityWindow = new CreateFacilityWindow();
            CloseAction();
            facilityWindow.Show();
            
            
        }
        public void AddFacility()
        {
            Facility facility = FromStringToFacility();
            facility.ID = _facilityService.AddToFacilityRepo(facility);
            ShowFacilities();
            CreatePermitWindow permitWindow = new CreatePermitWindow(facility);
            CloseAction();
            permitWindow.Show();
            ShowFacilities();
            
            //Tilføjelse af 
        }

        public void OpenCreatePermitWindowWithSelectedFacility()
        {
            CreatePermitWindow permitWindow = new CreatePermitWindow(Facility);
            CloseAction();
            permitWindow.Show();
            
        }


        public void CancelAndCloseCurrent()
        {
            SummaryWindow summaryWindow = new SummaryWindow();
            CloseAction();
            summaryWindow.Show();
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
            SummaryWindow summaryWindow = new SummaryWindow();
            CloseAction();
            summaryWindow.Show();




            //Tilføjelse af 
        }
        public void EditFacility() //edit Permit?
        {
            EditFacilityWindow editFacilityWindow = new EditFacilityWindow(Facility);
            CloseAction();
            editFacilityWindow.Show();

        }

        public void SaveEditFacility()
        {
            _facilityService.UpdateInFacilityRepo(Facility);
            ShowFacilities();
            SummaryWindow summaryWindow = new SummaryWindow();
            CloseAction();
            summaryWindow.Show();
        }
        public void SeeMore()
        {
            SeeMoreWindow seeMoreWindow = new SeeMoreWindow(Facility);
            seeMoreWindow.Show();
        }
        public void RemoveFacility()
        {
            _facilityService.RemoveFacilityFromRepo(Facility);
            ShowFacilities();
        }
        private bool IsSelectedNull(Facility facility)
        {
            if (facility != null) return true;
            return false;
        }
        public Action CloseAction { get; set; }

        public Facility FromStringToFacility()
        {
            int systemID = 0;
            for (int i = 0; i < (SystemOptions.Count); i++)
            {
                if (System == SystemOptions[i]) { systemID = i+1; }
            }

            Facility facility = new Facility();
            facility.Name = Name;
            facility.UDLNumber = UDLNumber;
            facility.OBNumber = OBNumber;
            facility.SystemID = systemID;
            facility.MinimumPoolSize = MinimumPoolSize;
            facility.System = SystemOptions[facility.SystemID-1];
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
            permit.FacilityID = Facility.ID;
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
