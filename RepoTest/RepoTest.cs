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
        string connectionString;
        int expectedRowsFacilityRepo;

        [TestInitialize]
        public void Init()
        {
            //ARRANGE
            //Instantiering af objektr
            connectionString = "TestDB";
            _facilityRepo = new FacilityRepo<Facility>(connectionString);
            _overflowRepo = new OverflowRepo<Overflow>(connectionString);
            _incidentRepo = new IncidentRepo<Incident>(connectionString);
            _restrictionRepo = new RestrictionRepo<Restriction>(connectionString);

            //int expectedRowsOverflowRepo = COUNT * IN FACILITY
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
            Assert.AreEqual(5, facilities.Count);
        }
    }
}