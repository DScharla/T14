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

        private int _numberOfIncidents;
        public int NumberOfIncidents
        {
            get { return _numberOfIncidents; }
            set { _numberOfIncidents = value; }
        }

        private int _totalOverflow;
        public int TotalOverflow
        {
            get { return _totalOverflow; }
            set { _totalOverflow = value; }
        }

        private int _UDLNumber;
        public int UDLNumber
        {
            get { return _UDLNumber; }
            set { _UDLNumber = value; }
        }

        private int _OBNumber;
        public int OBNumber
        {
            get { return _OBNumber; }
            set { _OBNumber = value; }
        }

        private string _system;
        public string System
        {
            get { return _system; }
            set { _system = value; }
        }

        private string _minimumPoolSize;
        public string MinimumPoolSize
        {
            get { return _minimumPoolSize; }
            set { _minimumPoolSize = value; }
        }

        private ObservableCollection<Restriction> _restrictions;
        public ObservableCollection<Restriction> Restrictions   
        { 
            get { return _restrictions; }
            set { _restrictions = value; }
        }

        public Facility()
        {
            _restrictions = new ObservableCollection<Restriction>();
        }
    }
}
