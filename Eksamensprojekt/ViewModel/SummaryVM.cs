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

namespace Eksamensprojekt.ViewModel
{
    public class SummaryVM
    {
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
        private Facility facility;
        //DCD: +1
        private FacilityService _facilityService;

        private ObservableCollection<Facility> _facilities;
        public RelayCommand AddFacilityCommand => new RelayCommand(
            execute => AddFacility(),
            canExecute => { return true; }
            );

        public RelayCommand AddPermitCommand => new RelayCommand(
            execute => AddPermit(),
            canExecute => { return true; }
            );
        public ObservableCollection<Facility> Facilities { 
            get {
                return _facilities; 
            } 
            set {
                ShowFacilities(); 
            } 
        }
        //DCD: +1
        public SummaryVM()
        {
            _facilityService = new FacilityService();
            _facilities = new ObservableCollection<Facility>();
            ShowFacilities();
            _equipmentRestrictionCollection = GetRestrictionOptions("EQUIPMENTRESTRICTION");
        }
        public SummaryVM(Facility facility)
        {
            _facilityService = new FacilityService();
            _facilities = new ObservableCollection<Facility>();
            ShowFacilities();
            this.facility = facility;
            _equipmentRestrictionCollection = GetRestrictionOptions("EQUIPMENTRESTRICTION");
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
        public void AddFacility()
        {
            Facility facility = FromStringToFacility();
            facility.ID=_facilityService.AddToFacilityRepo(facility);
            ShowFacilities();
            CreatePermitWindow permitWindow = new CreatePermitWindow(facility);
            permitWindow.Show();
            //Tilføjelse af 
        }
        public void AddPermit()
        {
            Permit permit = FromStringToPermit();
            _facilityService.AddToPermitRepo(permit);
            ShowFacilities();
            //Tilføjelse af 
        }
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
