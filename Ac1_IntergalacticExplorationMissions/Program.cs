using System;

namespace Ac1_IntergalacticExplorationMissions
{
    public class Program
    {
        public static void Main()
        {
            const int MAX_SCORES = 5;
            List<Score> scores = new List<Score>();
            string player;
            string mission;
            int scoring;
            bool error = false;

            Console.WriteLine("Intergalactic Exploration Missions");
            Console.WriteLine("===================================");
            Console.WriteLine();

            for (int i = 0; i < MAX_SCORES; i++)
            {
                Console.WriteLine($"Score {i+1}");
                Console.WriteLine("Introdueix el nom del jugador (només pot contenir caràcters alfabètics, sense accents ni caràcters especials)");
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Nom incorrecte. Torna a introduir el nom del jugador (només pot contenir caràcters alfabètics, sense accents ni caràcters especials)");
                    }
                    Console.Write("Player: ");
                    player = Console.ReadLine().Trim();
                    Console.WriteLine(player.Replace(' ', '_'));
                    error = true;
                } while (!Methods.CheckPlayer(player));
                error = false;
                Console.WriteLine("Introdueix el nom de la missio (ha de contenir com a prefix el nom adaptat de les consonants en grec, seguit d’un guió i un número de 3 xifres.\nExemple: Delta-003)");
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Nom de missió incorrecte. Torna a introduir el nom de la missió (ha de contenir com a prefix el nom adaptat de les consonants en grec, seguit d’un guió i un número de 3 xifres.\nExemple: Delta-003)");
                    }
                    Console.Write("Mission: ");
                    mission = Console.ReadLine().Trim();
                    Console.WriteLine(mission.Replace(' ', '_'));
                    error = true;
                } while (!Methods.CheckMission(mission));
                error = false;
                Console.WriteLine("Introdueix la puntuació (un número enter entre 0 i 500 inclosos)");
                do
                {
                    if (error)
                    {
                        Console.WriteLine("Puntuació incorrecta. Torna a introduir la puntuació (un número enter entre 0 i 500 inclosos)");
                    }
                    Console.Write("Scoring: ");
                    scoring = Convert.ToInt32(Console.ReadLine());
                    error = true;
                } while (!Methods.CheckScoring(scoring));
                error = false;
                scores.Add(new Score(player, mission, scoring));
                Console.Clear();
            }

            List<Score> ranking = Methods.GenerateUniqueRanking(scores);
            ranking.Sort();
            Console.WriteLine("Rànquing de puntuacions úniques");
            Console.WriteLine("===============================");
            foreach (Score score in ranking)
            {
                Console.WriteLine($"{score.Player} - {score.Mission} - {score.Scoring}");
            }
        }
    }
}