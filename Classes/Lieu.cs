using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceFinaleCs.Classes
{
    public class Lieu : Adresse
    {

        #region Propriétés
        public int Capacite { get; set; }
        #endregion

        #region Méthodes
        //METHODES
        #endregion

        #region Constructeur
        public Lieu(string rue, string ville, int capacite) : base(rue, ville)
        {
            Capacite = capacite;
        }
        #endregion
    }
}
