using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystem
{
    public class Team
    {

        public Coach Coach { get; private set; } = null!;
        public List<Player> Players { get; } = new List<Player>();

        public void AddPLayer(Player newPLayer)
        {
            if(newPLayer == null)
            {
                throw new ArgumentNullException("Player is required");
            }
            if(Players.Count >= 3)
            {
                throw new ArgumentException ("team is full. can not add anymore players");
            }
            bool primaryNoFound = false;
            foreach(Player currentPlayer in Players)
            {
                if(currentPlayer.PrimaryNo == newPLayer.PrimaryNo)
                {
                    primaryNoFound = true;
                    break;
                }
            }
            if (primaryNoFound)
            {
                throw new ArgumentException("PrimaryNo is already in use");
            }
            Players.Add(newPLayer);

        }
        public int TotalPlayerPoints
        {
            get
            {
                int totalPoints = 0;
                foreach(Player currentPlayer in Players)
                {
                    totalPoints += currentPlayer.Points;
                }
                return totalPoints;
            }
        }

        private string _teamName= string.Empty;
        public string TeamName
        {
            get { return _teamName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Team Name is required");
                }
                if (value.Trim().Length < 5)
                {
                    throw new ArgumentException("Team Name must contain 5 or more characters");
                }
            }
        }
        public Team(string teamName, Coach coach)
        {
            if (coach == null)
            {
                throw new ArgumentNullException("Team requires a coach");
            }
            Coach = coach;
            TeamName = teamName;
           
        }
        public override string ToString()
        {
            return $"{TeamName}, {Coach}";
        }
    }
}
