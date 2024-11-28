using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Eksamensprojekt.Model;
using System.Windows.Navigation;

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
        //DCD: +1
        private FacilityService _facilityService;

        private ObservableCollection<Facility> _facilities;
        public RelayCommand AddFacility => new RelayCommand(
            execute => AddCommand(),
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
        public void AddCommand()
        {
            Facility facility = FromStringToFacility();
            _facilityService.AddToFacilityRepo(facility);
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
    }
}
