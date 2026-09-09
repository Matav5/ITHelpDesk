using ITHelpDesk.Incidents;
using ITHelpDesk.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITHelpDesk.Handlers
{
    public class L1Handler : SupportHandler
    {
        public L1Handler(User handlerUser) : base(handlerUser)
        {
        }

        protected override bool CanHandleIncident(Incident incident)
        {
            return incident.IncidentLevel == Enums.IncidentLevel.L1 && incident.Priority <= Enums.IncidentPriority.High && HandlerUser.isQualifiedForIncident(incident.IncidentType);
        }
    }
}
