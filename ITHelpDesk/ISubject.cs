using ITHelpDesk.Incidents;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITHelpDesk
{
    public interface ISubject
    {
        public void Attach(IObserver observer);
        public void Detach(IObserver observer);
        public void Notify();
    }
}
