using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Eksamensprojekt.Model;

namespace Eksamensprojekt.ViewModel
{
    public class SummaryVM
    {
        //DCD: +1
        private FacilityService _facilityService;

        private ObservableCollection<Facility> _facilities;

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
               
                ObservableCollection<Restriction> tempRestrictions = new ObservableCollection<Restriction>(); 
                foreach (Restriction restriction in facility.Restrictions)
                {
                    if (now > restriction.StartDate) { tempRestrictions.Add(restriction); }
                }

                tempRestrictions.OrderByDescending(tempRestrictions => tempRestrictions.StartDate);
                facility.Restrictions = tempRestrictions;
                Facilities.Add(facility);
            }
        }
    }
}
