
using ExerciceFinaleCs.Classes;


//Clients

Client client1 = new Client("Massé Laude", "Titouan", new Adresse("Jean Baptiste Lebas", "Provin"), 19, "0785297538");
Console.WriteLine(client1.ToString());

//Evenements
Evenement event1 = new Evenement("Terrifier 3", new Lieu("Nationale", "Lille", 412),"19/10/2024");
Console.WriteLine(event1.ToString());

//Billets
Billet billet1 = new Billet(1, client1, event1, "vip");
Console.WriteLine(billet1.ToString());