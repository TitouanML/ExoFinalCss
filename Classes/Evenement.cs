using System;
using System.Collections.Generic;

namespace ExerciceFinaleCs.Classes
{
    public class Evenement
    {

        #region Propriétés
        public string Nom { get; set; }
        public Lieu Lieu { get; set; }
        public string Date { get; set; }
        public int NombreBillet { get; private set; }
        public List<Billet> ListeBillet { get; private set; }
        public void AjouterBillet(Billet billet)
        {
            if(NombreBillet < Lieu.Capacite)
            {
                //Si il reste des billets disponibles
                ListeBillet.Add(billet);
                NombreBillet++;
                Console.WriteLine($"{Lieu.Capacite-NombreBillet} place(s) désormais restante(s)");
            }
            else
            {
                //Si l'événement est déjà complet
                Console.WriteLine("Cet événement est malheureusement complet...");
            }

        }
        #endregion

        #region Constructeur
        public Evenement(string nom, Lieu lieu, string date)
        {
            Nom = nom;
            Lieu = lieu;
            Date = date;
            ListeBillet = new List<Billet>();
            NombreBillet = ListeBillet.Count;
        }
        #endregion

        public override string ToString()
        {
            return $"Evenement : {Nom}\n Lieu: {Lieu}\n Date: {Date}\n {Lieu.Capacite-NombreBillet} places restantes\n";
        }
    }
}
