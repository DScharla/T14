using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt.Model
{
    public class Restriction
    {
		private DateTime _startDate;

		public DateTime StartDate
		{
			get { return _startDate; }
			set { _startDate = value; }
		}
		private DateTime _endDate;

		public DateTime EndDate
		{
			get { return _endDate; }
			set { _endDate = value; }
		}
		private int _allowedOverflowVolume;

		public int AllowedOverflowVolume
		{
			get { return _allowedOverflowVolume; }
			set { _allowedOverflowVolume = value; }
		}
		private int _allowedIncidents;

		public int AllowedIncidents
		{
			get { return _allowedIncidents; }
			set { _allowedIncidents = value; }
		}
		private string _equipmentRestriction;

		public string EquipmentRestriction
		{
			get { return _equipmentRestriction; }
			set { _equipmentRestriction = value; }
		}
		private string _maintenanceRestriction;

		public string MaintenanceRestriction
		{
			get { return _maintenanceRestriction; }
			set { _maintenanceRestriction = value; }
		}
		private string _measurementRestriction;

		public string MeasurementRestriction
		{
			get { return _measurementRestriction; }
			set { _measurementRestriction = value; }
		}
		private string _additionalRestriction;

		public string AdditionalRestriction
		{
			get { return _additionalRestriction; }
			set { _additionalRestriction = value; }
		}








	}
}
