using ITHelpDesk.Incidents;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITHelpDesk
{
    public interface IObserver
    {
        public void Update(Incident incident);
    }
}
