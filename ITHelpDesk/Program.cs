using ITHelpDesk.Handlers;
using ITHelpDesk.Incidents;
using ITHelpDesk.Storage;
using ITHelpDesk.Users;
using System.Xml;
using System.Xml.Linq;

namespace ITHelpDesk
{

    //Udělat nestatickou appku
    internal class Program
    {
        static StorageServiceDTO storageServiceDTO;
        static User loggedUser;
        static void Main(string[] args)
        {
            LoadIncidents();
            Login();
            SetupNotifications();
            while (true)
            {
                Console.Clear();
                UserAction();
            }
        }

        private static void SetupNotifications()
        {
            foreach(Incident incident in storageServiceDTO.Incidents)
            {
                incident.OnIncidentStateChanged += loggedUser.OnIncidentStateChanged;
            }
        }

        private static void UserAction()
        {

            bool run = true;
            while (run)
            {

                while (run)
                {
                    ShowAllIncidents();
                    ShowNotifications();
                    Console.WriteLine("Vyberte Akci (process,exit):");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {

                        case "process":
                            ProcessIncidents();
                            run = false;
                            break;

                        case "exit":
                            run = false;
                            break;
                    }
                }
            }
        }

        private static void ShowNotifications()
        {
            string notifications = loggedUser.getNotifications();
            if (notifications != "")
            {
                Console.WriteLine(notifications);
                loggedUser.clearNotifications();
            }
        }

        private static void ProcessIncidents()
        {
            User l1User = storageServiceDTO.Users.Find(user => user.UserRole == UserRole.L1);
            User l2User = storageServiceDTO.Users.Find(user => user.UserRole == UserRole.L2);
            User l3User = storageServiceDTO.Users.Find(user => user.UserRole == UserRole.L3);
            L1Handler l1Handler = new L1Handler(l1User);
            L2Handler l2Handler = new L2Handler(l2User);
            L3Handler l3Handler = new L3Handler(l3User);
            l1Handler.Next = l2Handler;
            l2Handler.Next = l3Handler;
            List<Incident> incidentsToProcess = storageServiceDTO.Incidents.FindAll(incident => incident.State == Enums.IncidentState.New);
            foreach (Incident incident in incidentsToProcess)
            {
                l1Handler.HandleIncident(incident);
            }
        }


        private static void ShowAllIncidents()
        {
            foreach (Incident incident in storageServiceDTO.Incidents)
            {
                Console.WriteLine(incident.ToString());
            }
        }

      
        private static Incident? IncidentByInput()
        {

            while (true)
            {
                Console.WriteLine("Vyber incident podle ID");
                int id = int.Parse(Console.ReadLine());
                Incident? chosenIncident = storageServiceDTO.Incidents.Find((incident) => incident.Id == id);
                if (chosenIncident != null)
                {
                    return chosenIncident;
                }
            }
        }


   
        private static void LoadIncidents()
        {
            storageServiceDTO = JsonStorage.Load();
        }

        private static void Login()
        {
            while (true)
            {
                Console.WriteLine("Vložte uživatelské jméno (L1, L2, L3, Admin)");
                string username = Console.ReadLine();
                User? user = storageServiceDTO.Users.Find((user) => user.UserName == username);
                if (user != null)
                {
                    loggedUser = user;
                    break;
                }
                Console.WriteLine("Neplatné přihlašovací údaje");
            }

        }
    }
}
