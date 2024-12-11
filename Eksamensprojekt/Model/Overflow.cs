using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt.Model
{
    public class Overflow 
    {
		public Overflow()
		{
			
		}
		public Overflow(string startTime, string endTime, string overflowVolume)
		{
			StartTime = DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            EndTime = DateTime.ParseExact(endTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
			OverflowVolume = double.Parse(overflowVolume);
        }
		
		private DateTime _startTime;

		public DateTime StartTime
		{
			get { return _startTime; }
			set { _startTime = value; }
		}
		private TimeSpan _duration;

		public TimeSpan Duration
		{
			get { return EndTime - StartTime; }
			//set { _duration = EndTime-StartTime; }
		}

		private DateTime _endTime;

		public  DateTime EndTime
		{
			get { return _endTime; }
			set { _endTime = value; }
		}

		private int _incidentID;

		public int IncidentID
		{
			get { return _incidentID; }
			set { _incidentID = value; }
		}


		private double _overflowVolume;

		public double OverflowVolume
		{
			get { return _overflowVolume; }
			set { _overflowVolume = value; }
		}
		private int _overflowID;
		public int OverflowID
        {
            get { return _overflowID; }
            set { _overflowID = value; }
        }
		private int _facilityID;

		public int FacilityID
		{
			get { return _facilityID; }
			set { _facilityID = value; }
		}

		


	}
}
