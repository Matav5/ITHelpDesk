using ITHelpDesk.Enums;
using ITHelpDesk.Incidents;
using ITHelpDesk.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ITHelpDesk.Storage
{
    internal class JsonStorage
    {
        static string path = "Storage.json";
        public static StorageServiceDTO Load()
        {
            StorageServiceDTO? storageServiceDTO = null;
            if (File.Exists(path))
            {
            string storageJson =  File.ReadAllText(path);
            storageServiceDTO = JsonSerializer.Deserialize<StorageServiceDTO>(storageJson);

            }
            if(storageServiceDTO == null)
            {
                storageServiceDTO = new StorageServiceDTO();
                Seed(storageServiceDTO);
            }
            return storageServiceDTO;
        }

        private static void Seed(StorageServiceDTO storageServiceDTO)
        {
            if (storageServiceDTO.Users.Count == 0)
            {
                storageServiceDTO.Users.Add(new User("L1", UserRole.L1, new List<IncidentType> { IncidentType.HW}));
                storageServiceDTO.Users.Add(new User("L2", UserRole.L2, new List<IncidentType> { IncidentType.SW, IncidentType.HW }));
                storageServiceDTO.Users.Add(new User("L3", UserRole.L3, new List<IncidentType> { IncidentType.Network, IncidentType.SW, IncidentType.HW, IncidentType.Security }));
                storageServiceDTO.Users.Add(new User("Admin", UserRole.Admin, new List<IncidentType> { IncidentType.Network, IncidentType.SW, IncidentType.HW, IncidentType.Security }));
            }

            if (storageServiceDTO.Incidents.Count == 0)
            {
                Incident l1Incident = IncidentFactory.CreateIncident(IncidentType.HW, 1, IncidentState.New,IncidentPriority.High, "Wifi on the second floor is broken", "L1", IncidentLevel.L1);
                Incident l2Incident = IncidentFactory.CreateIncident(IncidentType.SW,2, IncidentState.New, IncidentPriority.High, "Wifi on the second floor is not updated", "L2", IncidentLevel.L2);
                Incident l3Incident = IncidentFactory.CreateIncident(IncidentType.Network, 3, IncidentState.New, IncidentPriority.High, "Wifi on the second floor is down", "L2",IncidentLevel.L2);
                storageServiceDTO.Incidents.AddRange([l1Incident, l2Incident, l3Incident]);
            }
        }

        public static void Save(StorageServiceDTO storageServiceDTO)
        {
            JsonSerializer.Serialize(storageServiceDTO);
        }
    }
}
