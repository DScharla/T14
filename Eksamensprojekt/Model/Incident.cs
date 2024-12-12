using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt.Model
{
    public class Incident
    {
		private DateTime _startTime;

		public DateTime StartTime
		{
			get { return _startTime; }
			set { _startTime = value; }
		}
        private DateTime _endTime;

        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
        private double _overflowVolume;

		public double OverflowVolume
		{
			get { return _overflowVolume; }
			set { _overflowVolume = value; }
		}
        private int _facilityID;
        public int FacilityID
        {
            get { return _facilityID; }
            set { _facilityID = value; }
        }

        private int _incidentID;
        public int IncidentID
        {
            get { return _incidentID; }
            set { _incidentID = value; }
        }

        public Incident()
        {

        }

        public Incident(DateTime startTime, DateTime EndTime, double OverflowVolume, int facilityID)
        {
            this._startTime = startTime;
            this._endTime = EndTime;
            this._overflowVolume = OverflowVolume;
            this._facilityID = facilityID;
        }
        public Incident(DateTime startTime, DateTime EndTime, double OverflowVolume, int facilityID, int incidentID) 
        {
            this._startTime = startTime;
            this._endTime = EndTime;
            this._overflowVolume = OverflowVolume;
            this._facilityID = facilityID;
            this._incidentID = IncidentID;
        }

    }
}
