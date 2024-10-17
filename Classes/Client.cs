using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceFinaleCs.Classes
{
    public class Client
    {
        #region Propriétés
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Adresse Adresse { get; set; }
        public int Age { get; set; }
        public string NumTel { get; set; }
        public List<Billet> ListeBilletClient { get; private set; } = new List<Billet>();

        public string NomPrenom { get; private set; }
        #endregion

        #region Méthodes
        public void AjouterBillet(Billet billet)
        //Ajoute un billet à la liste de billets réservés du client
        {
            ListeBilletClient.Add(billet);
            return;
        }
        #endregion

        #region Constructeur
        public Client(string nom, string prenom, Adresse adresse, int age, string numtel)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Age = age;
            NumTel = numtel;
            NomPrenom = $"{Nom} {Prenom}";
        }
        #endregion

        public override string ToString()
        {
            return $"{NomPrenom}\n Âge : {Age}\n  Habite {Adresse}\n Tel : {NumTel}";
        }
    }
}
