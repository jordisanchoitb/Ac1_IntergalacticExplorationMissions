using System;

namespace Ac1_IntergalacticExplorationMissions
{
    public class Program
    {
        public static void Main()
        {
            const string WelcomeMessage = "Intergalactic Exploration Missions";
            const string SeparatorWelcome = "===================================";
            const string NumScore = "Score {0}";
            const string MsgPlayer = "Introdueix el nom del jugador (només pot contenir caràcters alfabètics, sense accents ni caràcters especials)";
            const string MsgErrorPlayer = "Nom incorrecte. Torna a introduir el nom del jugador (només pot contenir caràcters alfabètics, sense accents ni caràcters especials)";
            const string MsgMission = "Introdueix el nom de la missio (ha de contenir com a prefix el nom adaptat de les consonants en grec, seguit d’un guió i un número de 3 xifres.\nExemple: Delta-003)";
            const string MsgErrorMission = "Nom de missió incorrecte. Torna a introduir el nom de la missió (ha de contenir com a prefix el nom adaptat de les consonants en grec, seguit d’un guió i un número de 3 xifres.\nExemple: Delta-003)";
            const string MsgScoring = "Introdueix la puntuació (un número enter entre 0 i 500 inclosos)";
            const string MsgErrorScoring = "Puntuació incorrecta. Torna a introduir la puntuació (un número enter entre 0 i 500 inclosos)";
            const string InputPlayer = "Player: ";
            const string InputMission = "Mission: ";
            const string InputScoring = "Scoring: ";
            const string MsgRanking = "Rànquing de puntuacions úniques";
            const string SeparatorRanking = "===============================";

            const int MAX_SCORES = 5;
            List<Score> scores = new List<Score>();
            string player;
            string mission;
            int scoring;
            bool error = false;

            Console.WriteLine(WelcomeMessage);
            Console.WriteLine(SeparatorWelcome);
            Console.WriteLine();

            for (int i = 0; i < MAX_SCORES; i++)
            {
                Console.WriteLine(NumScore,i+1);
                Console.WriteLine(MsgPlayer);
                do
                {
                    if (error)
                    {
                        Console.WriteLine(MsgErrorPlayer);
                    }
                    Console.Write(InputPlayer);
                    player = Console.ReadLine().Trim();
                    error = true;
                } while (!Methods.CheckPlayer(player));
                error = false;
                Console.WriteLine(MsgMission);
                do
                {
                    if (error)
                    {
                        Console.WriteLine(MsgErrorMission);
                    }
                    Console.Write(InputMission);
                    mission = Console.ReadLine().Trim();
                    error = true;
                } while (!Methods.CheckMission(mission));
                error = false;
                Console.WriteLine(MsgScoring);
                do
                {
                    if (error)
                    {
                        Console.WriteLine(MsgErrorScoring);
                    }
                    Console.Write(InputScoring);
                    scoring = Convert.ToInt32(Console.ReadLine());
                    error = true;
                } while (!Methods.CheckScoring(scoring));
                error = false;
                scores.Add(new Score(player, mission, scoring));
                Console.Clear();
            }

            List<Score> ranking = Methods.GenerateUniqueRanking(scores);
            ranking.Sort();
            Console.WriteLine(MsgRanking);
            Console.WriteLine(SeparatorRanking);
            foreach (Score score in ranking)
            {
                Console.WriteLine($"{score.Player} - {score.Mission} - {score.Scoring}");
            }
        }
    }
}