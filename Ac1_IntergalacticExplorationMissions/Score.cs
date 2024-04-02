using System;

namespace Ac1_IntergalacticExplorationMissions
{
    public class Score : IComparable<Score>
    {
        public string? Player { get; set; }
        public string? Mission { get; set; }
        public int Scoring { get; set; }

        public Score(string player, string mission, int scoring)
        {
            this.Player = player;
            this.Mission = mission;
            this.Scoring = scoring;
        }
        public override string ToString()
        {
            return $"{this.Player} - {this.Mission} - {this.Scoring}";
        }

        public int CompareTo(Score? other)
        {
            if (other == null)
            {
                return 1;
            }
            return -this.Scoring.CompareTo(other.Scoring);
        }
    }
}
