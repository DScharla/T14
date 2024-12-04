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
        private int _overflowVolume;

		public int OverflowVolume
		{
			get { return _overflowVolume; }
			set { _overflowVolume = value; }
		}
        private int _incidentID;
        public int IncidentID
        {
            get { return _incidentID; }
            set { _incidentID = value; }
        }

        public Incident(DateTime startTime, DateTime EndTime, int OverflowVolume)
        {
            this._startTime = startTime;
            this._endTime = EndTime;
            this._overflowVolume = OverflowVolume;
        }
        public Incident(DateTime startTime, DateTime EndTime, int OverflowVolume, int incidentID) 
        {
            this._startTime = startTime;
            this._endTime = EndTime;
            this._overflowVolume = OverflowVolume;
            this._incidentID = IncidentID;
        }

    }
}
