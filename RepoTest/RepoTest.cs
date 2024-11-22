using Eksamensprojekt.Model;
using System.Collections.ObjectModel;

namespace RepoTest
{
    [TestClass]
    public class RepoTest
    {
        //Initialisering af objekter
        FacilityRepo<Facility> _facilityRepo;
        OverflowRepo<Overflow> _overflowRepo;
        IncidentRepo<Incident> _incidentRepo;
        RestrictionRepo<Restriction> _restrictionRepo;
        int expectedRowsFacilityRepo;

        [TestInitialize]
        public void Init()
        {
            //ARRANGE
            //Instantiering af objektr
            _facilityRepo = new FacilityRepo<Facility>();
            _overflowRepo = new OverflowRepo<Overflow>();
            _incidentRepo = new IncidentRepo<Incident>();
            _restrictionRepo = new RestrictionRepo<Restriction>();

            int expectedRowsOverflowRepo = COUNT * IN FACILITY
            //ACT
            //"Manipulering" af objekter
        }
        [TestMethod]
        public void GetAllFacilityRepo()
        {
            ObservableCollection<Facility> facilities = _facilityRepo.GetAll();

            //ASSERT
            //Er resultatet lig det vi forventer
            //
            Assert.AreEqual(expectedRowsFacilityRepo, facilities.Count);
        }
    }
}