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
        private FacilityRepo<Facility> facilityRepo = new FacilityRepo<Facility>(connectionString);
        private PermitRepo<Permit> permitRepo = new PermitRepo<Permit>(connectionString);
        private IncidentRepo<Incident> incidentRepo = new IncidentRepo<Incident>(connectionString);
        private OverflowRepo<Overflow> overflowRepo = new OverflowRepo<Overflow>(connectionString);


        public FacilityService() 
        {
            List<string> facilitIDs = new List<string>();
        }
        public ObservableCollection<Facility> GetAllData()
        {
            ObservableCollection<Facility> tempFacilities = facilityRepo.GetAll();
            AddPermitsToFacility(tempFacilities);
            InsertIncidentsIntoFacility(tempFacilities); //Gemmer alle incidents der har det FacilityID som facility
            return tempFacilities;
        }

        public void AddCsvToFacility(int facilityID)
        {
            overflowRepo.FromCsvToOverflow(@"/Vejen_OB208 - Overløbsregistrering.txt", facilityID);
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

        public int AddToFacilityRepo(Facility facility)
        {
            int facilityID = facilityRepo.Add(facility);
            return facilityID;
        }
        public void AddToPermitRepo(Permit permit)
        {
            permitRepo.Add(permit);
        }
        public ObservableCollection<string> GetRestrictionOptionsFromRepo(string NameOfRestriction)
        {
            ObservableCollection<string> restrictionOptions = new ObservableCollection<string>();
            restrictionOptions = permitRepo.GetRestrictionOptionsFromDB(NameOfRestriction);
            return restrictionOptions;
        }
        public void UpdateInFacilityRepo(Facility facility)
        {
            facilityRepo.Update(facility);
        }
        public void InsertIncidentsIntoFacility(ObservableCollection<Facility> facilities)
        {
            foreach (Facility facility in facilities)
            {
                ObservableCollection<Incident> incidents = new ObservableCollection<Incident>();
                ObservableCollection<Overflow> overflows = new ObservableCollection<Overflow>();
                overflows = OverflowDurationGreaterThanFive(facility);
                EvaluateOverflowForFacility(facility, incidents, overflows);
            }

        }
        public void EvaluateOverflowForFacility(Facility facility, ObservableCollection<Incident> incidents, ObservableCollection<Overflow> overflows)
        {
            Incident tempIncident = new Incident(); //Lav tom constructor
                foreach (Overflow overflow in overflows) //Iterere gennem alle overflows der varer mere end 5 minutter og er for samme facility
                {
                    if (IsOverflowOver5hoursOfIncident(incidents, overflow)) //Hvis Overflow IKKE er sket indenfor 5 timer af EndDate på Sidste Incident
                    {
                        incidents.Add(new Incident(
                        overflow.StartTime,
                        overflow.StartTime + overflow.Duration,
                        overflow.OverflowVolume,
                        overflow.FacilityID)
                        ); //Tilføjer alle overflows der varer mere end 5 minutter og er fra samme facility
                        incidents[incidents.Count - 1].IncidentID = incidentRepo.Add(incidents[incidents.Count - 1]);
                        }
                    else if (IsOverflowOver5hoursOfIncident(incidents, overflow)==false) 
                    {
                        if (incidents.Count!= 0)
                        {
                            // Dette overflow er idnenfor 5 timer af et tidligere incident, derfor skal den lægge dette overflow volumen oveni det incident, og sætte endTime i incident til at være slut tidpunktet for overflowet. overflow.StartTime + overflow.Duration
                            incidents[incidents.Count - 1].EndTime = overflow.EndTime;
                            incidents[incidents.Count - 1].OverflowVolume += overflow.OverflowVolume;
                            incidentRepo.Update(incidents[incidents.Count - 1]);
                        }
                        else
                        {
                            tempIncident = new Incident()
                            {
                                StartTime = overflow.StartTime,
                                EndTime = overflow.EndTime,
                                OverflowVolume = overflow.OverflowVolume,
                                FacilityID = overflow.FacilityID
                            };
                            incidents.Add(tempIncident);
                            incidents[incidents.Count - 1].IncidentID = incidentRepo.Add(tempIncident);
                            
                        }

                    }
                overflow.IncidentID = incidents[incidents.Count - 1].IncidentID;
                overflowRepo.Update(overflow);
                }
                facility.Incidents = incidents;
        }
        public ObservableCollection<Overflow> OverflowDurationGreaterThanFive(Facility facility)
        {
            ObservableCollection<Overflow> overflows = new ObservableCollection<Overflow>(); 
            foreach (Overflow overflow in overflowRepo.GetAll())
            {
                if (overflow.Duration >= new TimeSpan(0, 5, 0) && overflow.FacilityID == facility.ID)
                {
                    overflows.Add(overflow);
                }
            }
            return overflows;
        }
        public bool IsOverflowOver5hoursOfIncident(ObservableCollection<Incident> incidents, Overflow overflow) 
        {
            bool isOverflowWithin5hours = false;
            if (incidents.Count > 0)
            {
                if (overflow.StartTime- incidents[incidents.Count-1].EndTime > new TimeSpan(5,0,0)) // Hvis der er gået mere end 5 timer mellem Incidents EndTime og overflowets Start Time 
                {
                    isOverflowWithin5hours = true;
                }
                
            }
            return isOverflowWithin5hours;
        }
        public bool RemoveFacilityFromRepo(Facility facility) 
        { 
            return facilityRepo.Remove(facility);
        }
        public void RemovePermitFromRepp(Facility facility)
        {
            foreach (Permit permit in facility.Permits)
            {
                permitRepo.Remove(permit);
            }
        }
    }
}
