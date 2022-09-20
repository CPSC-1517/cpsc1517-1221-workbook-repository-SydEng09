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
        public Player (string fullname, Position position, int primaryNo, int goals, int assists) : base(fullname)
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
    }
}
