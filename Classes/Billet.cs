using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceFinaleCs.Classes
{
    public class Billet
    {
        #region Propriétés
        public int NumeroPlace { get; set; }
        public Client Client { get; set; }
        public Evenement Evenement { get; set; }
        public string TypePlace { get; set; }


        #endregion

        #region Constructeur
        public Billet(int numeroPlace, Client client, Evenement evenement, string typePlace)
        {
            NumeroPlace = numeroPlace;
            Client = client;
            Evenement = evenement;
            TypePlace = typePlace;
        }
        #endregion

        public override string ToString()
        {
            return $"Billet pour {Evenement.Nom} le {Evenement.Date}\n Place n°{NumeroPlace}\n Emplacement {TypePlace}\n #---#Ce billet est au nom de {Client.NomPrenom} #---# ";
        }
    }
}
