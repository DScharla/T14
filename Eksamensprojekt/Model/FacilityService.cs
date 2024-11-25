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
        private readonly static string connectionString = "DBName";
        private FacilityRepo<Facility> repoTest = new FacilityRepo<Facility>(connectionString);
        private RestrictionRepo<Restriction> restrictionRepo = new RestrictionRepo<Restriction>(connectionString);

        public ObservableCollection<Facility> GetAllData()
        {
            ObservableCollection<Facility> tempFacilities = repoTest.GetAll();
            AddRestrictionsToFacility(tempFacilities);    
            return tempFacilities;
        }

        public ObservableCollection<Restriction> AddRestrictionsToFacility(ObservableCollection<Facility> facilities)
        {
            ObservableCollection<Restriction> restrictions = restrictionRepo.GetAll();
            foreach (Restriction restriction in restrictions)
            {
                foreach (Facility facility in facilities)
                {
                    if (facility.ID == restriction.FacilityID)
                    {
                        facility.Restrictions.Add(restriction);
                    }
                }
            }
            return restrictions;
        }
    }
}
