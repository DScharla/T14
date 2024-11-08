using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt.Model
{
    public class Overflow 
    {
		private DateTime _startTime;

		public DateTime StartTime
		{
			get { return _startTime; }
			set { _startTime = value; }
		}
		private TimeSpan _duration;

		public TimeSpan Duration
		{
			get { return _duration; }
			set { _duration = value; }
		}
		private int _overflowVolume;

		public int OverflowVolume
		{
			get { return _overflowVolume; }
			set { _overflowVolume = value; }
		}



	}
}
