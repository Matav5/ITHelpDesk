using ITHelpDesk.Enums;
using ITHelpDesk.Incidents;
using ITHelpDesk.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITHelpDesk
{
    public class NetworkIncident : Incident
    {
        public NetworkIncident(int id, IncidentState state, IncidentPriority priority, string description, string createdBy, IncidentLevel incidentLevel) : base(id, IncidentType.Network, state, priority, description, createdBy, incidentLevel) 
        {
        }
        protected override void AnalyzeIncident()
        {
            Console.WriteLine("Analyzing network issues");
        }

        protected override void WorkOnIncident()
        {
            Console.WriteLine("Working on router and documenting");
        }
    }
}
