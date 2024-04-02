using System;
using System.Text.RegularExpressions;

namespace Ac1_IntergalacticExplorationMissions
{
    public static class Methods
    {
        /// <summary>
        /// Comprova si el nom del jugador cumpleix amb el patró de només contenir caràcters alfabètics, sense accents ni caràcters especials
        /// </summary>
        /// <returns>boolean</returns>
        public static bool CheckPlayer(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        /// <summary>
        /// Comprova si el nom de la missió cumpleix amb el patró de tenir com a prefix el nom adaptat de les consonants en grec, seguit d’un guió i un número de 3 xifres
        /// </summary>
        /// <returns>boolean</returns>
        public static bool CheckMission(string name)
        {
            return Regex.IsMatch(name, @"^(Alpha|Beta|Gamma|Delta|Epsilon|Zeta|Eta|Theta|Iota|Kappa|Lambda|Mu|Nu|Xi|Omicron|Pi|Rho|Sigma|Tau|Upsilon|Phi|Chi|Psi|Omega)-[0-9]{3}$");
        }

        /// <summary>
        /// Comprova si la puntuació està entre 0 i 500
        /// </summary>
        /// <returns>boolean</returns>
        public static bool CheckScoring(int scoring)
        {
            return scoring >= 0 && scoring <= 500;
        }

        /// <summary>
        /// Genera un ranking únic de les puntuacions més altes de cada jugador en cada missió
        /// </summary>
        /// <returns>List</returns>
        public static List<Score> GenerateUniqueRanking(List<Score> scores)
        {           
            // Hace un group by de los jugadores y las misiones y ordena las puntuaciones de mayor a menor,
            // cogiendo la primera para asi obtener la puntuacion mas alta de cada jugador en cada mision
            var rankings = from players in scores
                           group players by (players.Player, players.Mission) into playerRanking
                           select playerRanking.OrderByDescending(x => x.Scoring).First();
            
            return rankings.ToList();
        }
    }
}
