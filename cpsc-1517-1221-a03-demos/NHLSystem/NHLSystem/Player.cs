using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystem
{
    public class Player : Person
    {
        public Position Position { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }

        private int _primaryNo;
        public int PrimaryNo
        {
            get
            {
                return _primaryNo;
            }
            set
            {
                if(value <0 || value > 98)
                {
                    throw new ArgumentOutOfRangeException("PrimaryNo has to be between 0 and 98");
                }
                _primaryNo = value;
            }
        }
           
        public int Points
        {
            get
            {
                return Goals + Assists;
            }
        }
        public Player(string fullName, Position position, int primaryNo) : base(fullName)
        {
            Position = position;
            PrimaryNo = primaryNo;
            Goals = 0;
            Assists = 0;
        }
        public Player (string fullname, int primaryNo, Position position, int goals, int assists) : base(fullname)
        {
            Position=position;
            PrimaryNo=primaryNo;
            Goals=goals;
            Assists=assists;
        }
        public override string ToString()
        {
            return  $"{FullName}, {PrimaryNo}, {Position}, {Goals}, {Assists}, {Points}";
        }
        public static Player ParseCsv(string line)
        {
            const char Delimiter = ',';
            string[] tokens = line.Split(Delimiter);

            if (tokens.Length != 6)
            {
                throw new FormatException($"CSV line must contain exactly 6 values. {line}");
            }
            string playerName = tokens[0];
            int playerNumber = int.Parse(tokens[1]);
            Position position = (Position) Enum.Parse(typeof(Position), tokens[2]);
            int goals = int.Parse(tokens[3]);
            int assists = int.Parse(tokens[4]);
            return new Player(
                fullname: playerName, 
                primaryNo: playerNumber, 
                position: position, 
                goals: goals, 
                assists: assists);
        }
        public static bool TryParse(string line, out Player player)
        {
            bool success = false;
            try
            {
                player = ParseCsv(line);
                success= true;
            }
            catch(FormatException ex)
            {
                throw new FormatException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception($"Player TryParse exception {ex.Message}");
            }
            return success;
        }
    }
}
