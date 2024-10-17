using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceFinaleCs.Classes
{
    public class Adresse
    {
        #region Propriétés
        public string Rue { get; set; }
        public string Ville { get; set; }


        #endregion

        #region Constructeur
        public Adresse(string rue, string ville)
        {
            Rue = rue;
            Ville = ville;
        }
        #endregion

        public override string ToString()
        {
            return $"rue {Rue} à {Ville}";
        }

    }
}
