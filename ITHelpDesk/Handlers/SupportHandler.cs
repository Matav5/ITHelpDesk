using ITHelpDesk.Incidents;
using ITHelpDesk.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITHelpDesk.Handlers
{
    abstract public class SupportHandler
    {
        SupportHandler? next;
        User handlerUser;

        protected SupportHandler(User handlerUser)
        {
            this.HandlerUser = handlerUser;
        }

        public SupportHandler? Next { get => next; set => next = value; }
        public User HandlerUser { get => handlerUser; set => handlerUser = value; }

        protected abstract bool CanHandleIncident(Incident incident);
        public virtual bool HandleIncident(Incident incident)
        {
            if (CanHandleIncident(incident))
            {
                bool processedSuccesfully = incident.Process();
                if (processedSuccesfully)
                {
                    return true;
                }
                return Next?.HandleIncident(incident) ?? false;
            }
            return false;
        }
    }
}
