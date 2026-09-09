using ITHelpDesk.Enums;
using ITHelpDesk.Incidents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ITHelpDesk.Users
{
    public class User
    {
        string userName;
        UserRole userRole;
        string notifications = "";
        List<IncidentType> skills;

        public User(string userName, UserRole userRole, List<IncidentType> skills)
        {
            this.UserName = userName;
            this.UserRole = userRole;
            this.skills = skills;
        }

        public string UserName { get => userName; set => userName = value; }
        public UserRole UserRole { get => userRole; set => userRole = value; }

        public bool hasRole(UserRole userRole)
        {
            return this.userRole == userRole;
        }
        public bool isQualifiedForIncident(IncidentType incidentType)
        {
            return skills.Contains(incidentType);
        }
        public string getNotifications()
        {
            return notifications;
        }
        public void clearNotifications()
        {
            notifications = "";
        }

        internal void OnIncidentStateChanged(Incident incident)
        {
            if (incident.CreatedBy == userName)
            {
                notifications += $"Your created Incident {incident.Id} state changed to {incident.State}\n";
            }
            else if (UserRole == UserRole.Admin){
                notifications += $"Incident {incident.Id} state changed to {incident.State}\n";
            }
        }

    }
}
