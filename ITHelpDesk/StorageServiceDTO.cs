using ITHelpDesk.Incidents;
using ITHelpDesk.Users;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ITHelpDesk
{
    internal class StorageServiceDTO
    {

        List<Incident> incidents = new List<Incident>();
        List<User> users = new List<User>();

        public List<Incident> Incidents { get => incidents; set => incidents = value; }
        public List<User> Users { get => users; set => users = value; }
    }
}
