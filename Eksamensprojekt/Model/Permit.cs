using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt.Model
{
    public class Permit
    {
		private DateTime _startDate;

		public DateTime StartDate
		{
			get { return _startDate; }
			set { _startDate = value; }
		}
		private DateTime? _endDate;

		public DateTime? EndDate
		{
			get { return _endDate; }
			set { _endDate = value; }
		}
		private int? _allowedAverageOverflowVolume;

		public int? AllowedAverageOverflowVolume
        {
			get { return _allowedAverageOverflowVolume; }
			set { _allowedAverageOverflowVolume = value; }
		}
        private DateTime? _allowedAverageOverflowPeriod;

        public DateTime? AllowedAverageOverflowPeriod
        {
            get { return _allowedAverageOverflowPeriod; }
            set { _allowedAverageOverflowPeriod = value; }
        }
        private int? _allowedYearlyOverflowVolume;

        public int? AllowedYearlyOverflowVolume
        {
            get { return _allowedYearlyOverflowVolume; }
            set { _allowedYearlyOverflowVolume = value; }
        }
        private int? _allowedAverageIncidents;

		public int? AllowedAverageIncidents
        {
			get { return _allowedAverageIncidents; }
			set { _allowedAverageIncidents = value; }
		}
        private DateTime? _allowedAverageIncidentsPeriod;

        public DateTime? AllowedAverageIncidentsPeriod
        {
            get { return _allowedAverageIncidentsPeriod; }
            set { _allowedAverageIncidentsPeriod = value; }
        }
        private int? _allowedYearlyIncidents;

        public int? AllowedYearlyIncidents
        {
            get { return _allowedYearlyIncidents; }
            set { _allowedYearlyIncidents = value; }
        }

        private string? _equipmentRestriction;

		public string? EquipmentRestriction
		{
			get { return _equipmentRestriction; }
			set { _equipmentRestriction = value; }
		}
		private string? _maintenanceRestriction;

		public string? MaintenanceRestriction
		{
			get { return _maintenanceRestriction; }
			set { _maintenanceRestriction = value; }
		}
		private string? _measurementRestriction;

		public string? MeasurementRestriction
		{
			get { return _measurementRestriction; }
			set { _measurementRestriction = value; }
		}
		private string? _additionalRestriction;

		public string? AdditionalRestriction
		{
			get { return _additionalRestriction; }
			set { _additionalRestriction = value; }
		}

		private int _facilityID;

		public int FacilityID
		{
			get { return _facilityID; }
			set { _facilityID = value; }
		}
        private int _permitID;

        public int PermitID
        {
            get { return _permitID; }
            set { _permitID = value; }
        }






    }
}
