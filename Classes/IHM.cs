using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceFinaleCs.Classes
{
    public interface IHM
    {
        public int etapeSaisie { get; set; }
        public Dictionary<int, Client> listeClients { get; }
        public Dictionary<int, Evenement> listeEvenements { get; }


        public void Start()
        {

            //On génère des événements
            ajouterEvenement(new Evenement("Titanic", new Lieu("Nationale", "Lille", 120), "20/12/2024"));
            ajouterEvenement(new Evenement("Terrifier 3", new Lieu("Gambetta", "Lille", 40), "01/12/2024"));
            ajouterEvenement(new Evenement("Titanic", new Lieu("Bvrd de la Liberté", "Paris", 160), "20/12/2024"));



        }


        public void ajouterClient(Client client)
        {
            listeClients[listeClients.Count + 1] = client;
            return;
        }

        public void ajouterEvenement(Evenement evenement)
        {
            listeEvenements[listeEvenements.Count + 1] = evenement;
            return;
        }


        public int introduction()
        {
            Console.WriteLine("Bonjour, êtes-vous déjà enregistré ?");
            Console.WriteLine("oui\nnon");
            string choix = Console.ReadLine();
            if(choix == "oui")
            {
                return 1;
            }else if(choix == "non")
            {
                return 2;
            }
            return 0;
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
            Console.WriteLine($"Bienvenue chez nous {prenomClient} !");
            return;
        }

        public void reserverBillet(Client client, Evenement evenement)
        {
            Console.WriteLine($"Vous êtes en train de reserver un billet pour {evenement.Nom} le {evenement.Date}");
            Console.WriteLine("Quel type de place souhaitez vous ?");
            Console.WriteLine("0 - Standard\n1 - Gold\n2 - VIP");
            string typePlace;
            do
            {
                string choixTypePlace = Console.ReadLine();
                int choix;
                if (int.TryParse(choixTypePlace, out choix) && choix <= 3 && choix >= 0)
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
            Console.WriteLine($"Merci pour votre reservation {client.Prenom}, vous avez le billet numero {numBillet}");
            return;
        }


    }
}
