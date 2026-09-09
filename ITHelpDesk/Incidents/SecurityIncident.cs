using ITHelpDesk.Enums;
using ITHelpDesk.Incidents;
using ITHelpDesk.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITHelpDesk
{
    public class SecurityIncident : Incident
    {
        public SecurityIncident(int id, IncidentState state, IncidentPriority priority, string description, string createdBy, IncidentLevel incidentLevel) : base(id, IncidentType.Security, state, priority, description, createdBy, incidentLevel)
        {
        }

        protected override void AnalyzeIncident()
        {
            Console.WriteLine("Analyzing security breach");
        }

        protected override void WorkOnIncident()
        {
            Console.WriteLine("Working on the security breach");
        }
    }
}
