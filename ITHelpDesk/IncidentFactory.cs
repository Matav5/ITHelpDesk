using ITHelpDesk.Enums;
using ITHelpDesk.Incidents;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITHelpDesk
{
    public class IncidentFactory
    {

        public static Incident CreateIncident(IncidentType type, int id, IncidentState state, IncidentPriority priority, string description, string createdBy, IncidentLevel incidentLevel)
        {
            switch (type)
            {
                case IncidentType.HW:
                    return new HardwareIncident(id, state, priority, description, createdBy, incidentLevel);
                case IncidentType.SW:
                    return new SoftwareIncident(id, state, priority, description, createdBy, incidentLevel);
                case IncidentType.Network:
                    return new NetworkIncident(id, state, priority, description, createdBy, incidentLevel);
                case IncidentType.Security:
                    return new SecurityIncident(id, state, priority, description, createdBy, incidentLevel);

            }
            throw new Exception("Not supported Incident Level");
        }

    }
}
