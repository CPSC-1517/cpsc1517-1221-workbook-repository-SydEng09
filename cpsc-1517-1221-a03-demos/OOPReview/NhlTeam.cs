using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPReview
{
    public class NhlTeam
    {
        public NHLConference Conference { get; private set; }
        public NHLDivision Division { get; private set; }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must contain text.");
                }
                _name = value.Trim();
            }
        }
        private string _city;
        public string City
        {
            get=> _city;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must conatin text.");
                }
                _city = value.Trim();
                
                 
            }
        }
        private int _gamesplayed;
        public int GamesPlayed
        {
            get => _gamesplayed;
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Games played must >=0");
                }
                _gamesplayed = value;
            }
        }
        private int _wins;
        public int Wins
        {
            get => _wins;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Wins must be >=0");
                }
                _wins = value;
            }
        }
        private int _losses;
        public int Losses
        {
            get => _losses;
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Losses must be >=0");
                }
                _losses = value;
            }
        }
        private int _overtimeLosses;
        public int OvertimeLosses
        {
            get => _overtimeLosses;
                set
            { 
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Must be >=0");
                }
                _overtimeLosses = value;
            }
        }
        public int Points
        {
            get => (Wins * 2) + OvertimeLosses;
        }

        public List<Roster> Players { get; private set; }

        public NhlTeam(
           NHLConference conference,
           NHLDivision division,
           string name,
           string city,
           List<Roster> players)
        { 
            if(players == null)
            {
                players = new List<Roster>();
            }
            else
            {
                Players = players;
            }
        }
        private const int MaxPlayers = 23;
        public void AddPlayer(Roster currentPlayer)
        {
            if(Players.Count >= MaxPlayers)
            {
                throw new ArgumentException("Roster is full. Remove a player");
            }
            Players.Add(currentPlayer);
        }
        public void RemovePlayer(int no)
        {
            bool foundPlayer=false;
            int playerindex = -1;
            for(int index=0; index<Players.Count; index++)
            {
                if (Players[index].No == no)
                {
                    foundPlayer=true;
                    playerindex = index;
                    index = Players.Count;
                }
            }
            if (!foundPlayer)
            {
                throw new ArgumentException($"Player {no} does not exist.");
            }
            Players.RemoveAt(playerindex);
        }
        public NhlTeam(
            NHLConference conference, 
            NHLDivision division, 
            string name, 
            string city)
        {
            Players = new List<Roster>();
            Conference = conference;
            Division = division;
            Name = name;
            this.City=city;

        }
        public override string ToString()
        {
            return $"{Conference},{Division},{Name},{City}, {GamesPlayed}, {Wins}, {Losses},{OvertimeLosses}";
        }

    }
    }

