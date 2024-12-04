using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt.Model
{
    public class Facility
    {
        //cla rød/grøn test ***
        private string _incidentsCompliance;

        public string IncidentsCompliance
        {
            get { return _incidentsCompliance; }
            set { _incidentsCompliance = value; }
        }

        private string _overflowCompliance;

        public string OverflowCompliance
        {
            get { return _overflowCompliance; }
            set { _overflowCompliance = value; }
        }

        //cla rød/grøn test ***
        private int _ID;

        public int ID 
        { 
            get { return _ID; }
            set { _ID = value; }
        }

        private string _name;
        
        public string Name
        {
            get { return _name; }
            set {_name = value;}
        }

        private int? _numberOfIncidents;
        public int? NumberOfIncidents
        {
            get { return _numberOfIncidents; }
            set { _numberOfIncidents = value; }
        }

        private int? _totalOverflow;
        public int? TotalOverflow
        {
            get { return _totalOverflow; }
            set { _totalOverflow = value; }
        }

        private string _UDLNumber;
        public string UDLNumber
        {
            get { return _UDLNumber; }
            set { _UDLNumber = value; }
        }

        private string _OBNumber;
        public string OBNumber
        {
            get { return _OBNumber; }
            set { _OBNumber = value; }
        }

        private int _systemID;
        public int SystemID
        {
            get { return _systemID; }
            set { _systemID = value; }
        }

        private string _minimumPoolSize;
        public string MinimumPoolSize
        {
            get { return _minimumPoolSize; }
            set { _minimumPoolSize = value; }
        }

        private ObservableCollection<Permit> _permits;
        public ObservableCollection<Permit> Permits   
        { 
            get { return _permits; }
            set { _permits = value; }
        }
        private ObservableCollection<Incident> _incidents;

        public ObservableCollection<Incident> Incidents
        {
            get { return _incidents; }
            set 
            { 
                _incidents = value;
                NumberOfIncidents = Incidents.Count;
                TotalOverflow = CalculateTotalOverflow(Incidents);
            }
        }

        public Facility()
        {
            Permits = new ObservableCollection<Permit>();
            Incidents = new ObservableCollection<Incident>();
        }
        public int CalculateTotalOverflow(ObservableCollection<Incident> incidents)
        {
            int totalOverflow = 0;
            foreach (Incident incident in Incidents)
            {
                totalOverflow += incident.OverflowVolume; 
            }
            return totalOverflow;
        }
    }
}
