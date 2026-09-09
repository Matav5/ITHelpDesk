using ITHelpDesk.Enums;
using ITHelpDesk.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITHelpDesk.Incidents
{
    public abstract class Incident : ISubject
    {
        int id;
        IncidentType type;
        IncidentLevel incidentLevel;
        IncidentState state;
        IncidentPriority priority;
        string description;
        string createdBy;
        public Incident(int id, IncidentType type, IncidentState state, IncidentPriority priority, string description, string createdBy, IncidentLevel incidentLevel)
        {
            this.Id = id;
            this.IncidentType = type;
            this.State = state;
            this.Priority = priority;
            this.Description = description;
            this.CreatedBy = description;
            this.IncidentLevel = incidentLevel;
        }

        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        internal IncidentPriority Priority { get => priority; set => priority = value; }
        internal IncidentState State
        {
            get => state; set
            {
                state = value;
                Notify();
            }
        }
        internal IncidentType IncidentType { get => type; set => type = value; }
        internal string CreatedBy { get => createdBy; set => createdBy = value; }
        public IncidentLevel IncidentLevel { get => incidentLevel; set => incidentLevel = value; }

        List<IObserver> observers = new List<IObserver>();
        public bool Process()
        {
            try
            {
                AcceptIncident();
                AnalyzeIncident();
                WorkOnIncident();
                CloseIncident();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing incident {Id}: {ex.Message}");
                State = IncidentState.Escalated;
                return false;
            }

        }

        protected virtual void CloseIncident()
        {
            State = IncidentState.Resolved;
        }

        protected abstract void WorkOnIncident();

        protected abstract void AnalyzeIncident();
        protected virtual void AcceptIncident()
        {
            State = IncidentState.Processing;
        }

        override public string ToString()
        {
            return $"{Id};{IncidentType};{State};{Priority};{Description}";
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(this);
            }
        }
    }
}
