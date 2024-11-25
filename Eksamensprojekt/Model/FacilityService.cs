using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt.Model
{
    public class FacilityService
    {
        private static string connectionString = "DBName";
        private FacilityRepo<Facility> repoTest = new FacilityRepo<Facility>(connectionString);
        private PermitRepo<Permit> permitRepo = new PermitRepo<Permit>(connectionString);

        public ObservableCollection<Facility> GetAllData()
        {
            ObservableCollection<Facility> tempFacilities = repoTest.GetAll();
            AddPermitsToFacility(tempFacilities);    
            return tempFacilities;
        }

        public ObservableCollection<Permit> AddPermitsToFacility(ObservableCollection<Facility> facilities)
        {
            ObservableCollection<Permit> restrictions = permitRepo.GetAll();
            foreach (Permit restriction in restrictions)
            {
                foreach (Facility facility in facilities)
                {
                    if (facility.ID == restriction.FacilityID)
                    {
                        facility.Permits.Add(restriction);
                    }
                }
            }
            return restrictions;
        }
    }
}
