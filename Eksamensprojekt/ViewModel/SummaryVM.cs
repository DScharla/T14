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
                _facilities = ShowFacilities(); 
            } 
        }
        //DCD: +1
        public SummaryVM()
        {
            _facilityService = new FacilityService();
            Facilities = ShowFacilities();
        }

        //DCD: private
        private ObservableCollection<Facility> ShowFacilities()
        {
            ObservableCollection<Facility> facilities = _facilityService.GetAllData();

            // SD: Rename method
            //facilities = _facilityService.GetAllData();

            return facilities;
        }
    }
}
