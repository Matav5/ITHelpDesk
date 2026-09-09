using ITHelpDesk.Enums;
using ITHelpDesk.Incidents;
using ITHelpDesk.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITHelpDesk
{
    public class SoftwareIncident : Incident
    {
        public SoftwareIncident(int id, IncidentState state, IncidentPriority priority, string description, string createdBy, IncidentLevel incidentLevel) : base(id, IncidentType.SW, state, priority, description, createdBy, incidentLevel)
        {

        }

        protected override void AnalyzeIncident()
        {
            Console.WriteLine("Analyzing software issues");
        }

        protected override void WorkOnIncident()
        {
            Console.WriteLine("Updating software. Looking into the issues");
        }
    }
}
