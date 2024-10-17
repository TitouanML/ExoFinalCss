using System;
using System.Collections.Generic;

namespace ExerciceFinaleCs.Classes
{
    public class IHM
    {
        public int etapeSaisie { get; set; } = 0;
        public Dictionary<int, Client> listeClients { get; } = new Dictionary<int, Client>();
        public Dictionary<int, Evenement> listeEvenements { get; } = new Dictionary<int, Evenement>();
        public Client clientConnecter { get; set; }

        public IHM()
        {
        }

        public void Start()
        {
            // On génère des événements
            ajouterEvenement(new Evenement("Titanic", new Lieu("Nationale", "Lille", 120), "20/12/2024"));
            ajouterEvenement(new Evenement("Terrifier 3", new Lieu("Gambetta", "Lille", 40), "01/12/2024"));
            ajouterEvenement(new Evenement("Titanic", new Lieu("Bvrd de la Liberté", "Paris", 160), "20/12/2024"));

            do
            {
                switch (etapeSaisie)
                {
                    case 0:
                        introduction();
                        break;
                    case 1:
                        creerClient();
                        break;
                    case 2:
                        dejaClient();
                        break;
                    case 3:
                        choisirEvenement();
                        break;
                }
            }
            while (true);
        }

        public void ajouterClient(Client client)
        {
            listeClients[listeClients.Count + 1] = client;
        }

        public void ajouterEvenement(Evenement evenement)
        {
            listeEvenements[listeEvenements.Count + 1] = evenement;
        }

        public void introduction()
        {
            Console.WriteLine("Bonjour, êtes-vous déjà enregistré ?");
            Console.WriteLine("oui\nnon");
            string choix = Console.ReadLine();
            if (choix == "oui")
            {
                Console.Clear();
                etapeSaisie = 2;
            }
            else if (choix == "non")
            {
                Console.Clear();
                etapeSaisie = 1;
            }
        }

        public void dejaClient()
        {
            Console.WriteLine("Voici les clients qui ont déjà acheté un billet chez nous : ");
            // Affichage de tous les clients
            foreach (var client in listeClients.Values)
            {
                Console.WriteLine($"- {client.NomPrenom}");
            }
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Tapez le nom et le prénom exactement comme ils sont affichés pour pouvoir vous connecter.\n (tapez retour pour faire revenir en arrière)");
            string reponse = Console.ReadLine();
            if (reponse == "retour")
            {
                etapeSaisie = 0;
                return;
            }
            else
            {
                foreach (var client in listeClients.Values)
                {
                    if (client.NomPrenom == reponse)
                    {
                        clientConnecter = client;
                        Console.WriteLine($"Ravi de vous revoir {clientConnecter.NomPrenom}");
                        etapeSaisie = 3; // Passer à la réservation après connexion
                        return;
                    }
                }
                // Si le client n'existe pas
                Console.WriteLine("Le nom n'est pas valide /!\\");
                etapeSaisie = 0;
            }
        }

        public void creerClient()
        {
            Console.WriteLine("1/6 Quel est votre nom ?");
            string nomClient = Console.ReadLine();
            Console.WriteLine("2/6 Quel est votre prénom ?");
            string prenomClient = Console.ReadLine();
            Console.WriteLine("3/6 Quel est votre âge ?");
            int ageClient;
            do
            {
                string stringAge = Console.ReadLine();
                if (int.TryParse(stringAge, out ageClient))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un nombre correct.");
                }
            } while (true);
            Console.WriteLine("4/6 Dans quelle ville habitez-vous ?");
            string villeClient = Console.ReadLine();
            Console.WriteLine("5/6 Le nom de votre rue ?");
            string rueClient = Console.ReadLine();
            Console.WriteLine("6/6 Votre numéro de téléphone ?");
            string telClient = Console.ReadLine();

            ajouterClient(new Client(nomClient, prenomClient, new Adresse(rueClient, villeClient), ageClient, telClient));
            Console.Clear();
            Console.WriteLine($"Bienvenue chez nous {prenomClient} !");
            clientConnecter = new Client(nomClient, prenomClient, new Adresse(rueClient, villeClient), ageClient, telClient);
            etapeSaisie = 3; // Passer à la réservation après création du client
        }

        public void choisirEvenement()
        {
            Console.WriteLine("Voici la liste des événements disponibles : ");
            foreach (var evenement in listeEvenements.Values)
            {
                Console.WriteLine($"- {evenement.Nom} à {evenement.Lieu.Ville}, le {evenement.Date}");
            }
            Console.WriteLine("Tapez le nom de l'événement auquel vous souhaitez assister (tapez retour pour revenir en arrière) :");
            string nomEvenement = Console.ReadLine();
            if (nomEvenement == "retour")
            {
                Console.Clear();
                etapeSaisie = 0;
                return;
            }

            foreach (var evenement in listeEvenements.Values)
            {
                if (evenement.Nom == nomEvenement)
                {
                    reserverBillet(clientConnecter, evenement);
                    return;
                }
            }
            // Si l'événement n'existe pas
            Console.Clear();
            Console.WriteLine("L'événement choisit n'est pas valide /!\\");
            etapeSaisie = 3; // Rester à l'étape de choix d'événement
        }

        public void reserverBillet(Client client, Evenement evenement)
        {
            Console.WriteLine($"Vous êtes en train de réserver un billet pour {evenement.Nom} le {evenement.Date}");
            Console.WriteLine("Quel type de place souhaitez-vous ?");
            Console.WriteLine("0 - Standard\n1 - Gold\n2 - VIP");
            string typePlace = "";
            do
            {
                string choixTypePlace = Console.ReadLine();
                int choix;
                if (int.TryParse(choixTypePlace, out choix) && choix <= 2 && choix >= 0)
                {
                    switch (choix)
                    {
                        case 0:
                            typePlace = "Standard";
                            break;
                        case 1:
                            typePlace = "Gold";
                            break;
                        case 2:
                            typePlace = "VIP";
                            break;
                    }
                    break; // Sortir de la boucle après avoir fait un choix valide
                }
                else
                {
                    Console.WriteLine("Veuillez faire un choix valide.");
                }
            } while (true);

            int numBillet = evenement.ListeBillet.Count + 1;
            Billet billetToAdd = new Billet(numBillet, client, evenement, typePlace);
            evenement.AjouterBillet(billetToAdd);
            client.AjouterBillet(billetToAdd);
            Console.Clear();
            Console.WriteLine($"Merci pour votre réservation {client.Prenom}, vous avez le billet numéro {numBillet}");
            etapeSaisie = 0; // Retour à l'introduction après la réservation
        }
    }
}
