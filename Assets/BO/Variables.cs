using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace Assets.BO
{
    public class Variables
    {
        private int score;
        private bool depart=false;
        private DateTime tempsDepart;
        
        private TimeSpan chrono;

        #region "Singleton"
        /// <summary>
        /// stocker l'instance d'un objet
        /// </summary>
        /// <remarks></remarks>
        private static Variables _instance;

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        public int Temps
        {
            get
            {
                return DateTime.Now.Subtract(tempsDepart).Seconds;
            }

            
        }

        public String TempsAffiche
        {
            get
            {
                return (10 - Temps).ToString(); ;
            }

            
        }

        public bool Depart
        {
            get
            {
                return depart;
            }

            set
            {
                depart = value;
            }
        }

        

        /// <summary>
        /// constructeur privé
        /// </summary>
        /// <remarks></remarks>
        private Variables()
        {
            Score = 0;
        }
        /// <summary>
        /// Methode fournissant une instance de MgtService
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Variables GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Variables();
            }
            return _instance;
        }
        #endregion

        public void PremiereCollision()
        {
            if (!Depart)
            {
                tempsDepart = DateTime.Now;
                Depart = true;
            }
        }
    }
}
