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
        Facility _facility1;
        string connectionString;
        int expectedRowsFacilityRepo;

        [TestInitialize]
        public void Init()
        {
            //ARRANGE
            //Instantiering af objektr
            connectionString = "DBTest";
            _facilityRepo = new FacilityRepo<Facility>(connectionString);
            _overflowRepo = new OverflowRepo<Overflow>(connectionString);
            _incidentRepo = new IncidentRepo<Incident>(connectionString);
            _restrictionRepo = new RestrictionRepo<Restriction>(connectionString);
            _facility1 = new Facility();


            //int expectedRowsOverflowRepo = COUNT * IN FACILITY
            //ACT
            //"Manipulering" af objekter

            _facilityRepo.Add(_facility1);
        }
        [TestMethod]
        public void GetAllFacilityRepo()
        {
            ObservableCollection<Facility> facilities = _facilityRepo.GetAll();

            //ASSERT
            //Er resultatet lig det vi forventer
            //
            Assert.AreEqual(1, facilities.Count);
        }
        [TestMethod]
        public void AddToFacilities()
        {

            //ASSERT
            //Er resultatet lig det vi forventer
            //
            Assert.AreEqual(_facility1, _facilityRepo.GetById(1));
        }
    }
}