using ITHelpDesk.Enums;
using ITHelpDesk.Incidents;
using ITHelpDesk.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITHelpDesk
{
    public class HardwareIncident : Incident
    {
        public HardwareIncident(int id, IncidentState state, IncidentPriority priority, string description, string createdBy, IncidentLevel incidentLevel) : base(id,IncidentType.HW, state, priority, description, createdBy, incidentLevel)
        {
        }
   
        public override string ToString()
        {
            return $"{Id};{IncidentType};{State};{Priority};{Description}";
        }

        protected override void AnalyzeIncident()
        {
            Console.WriteLine("Analyzing hardware specs");
        }

        protected override void WorkOnIncident()
        {
            Console.WriteLine("Pressed on/off switch. Working on hadware and documenting");
        }
    }
}
