using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.Linq;

namespace OOPReview
{
    public class Roster 
    {
        private int _no;
        public int No
        {
            get { return _no; }
            set
            {
                if (value < 0 || value > 98)
                {
                    throw new ArgumentOutOfRangeException("Games played must be within 0-98");
                }
                _no = value;
            }
        }
        private string _playername;
        public string Playername
        {
            get { return _playername; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must conatin text.");
                }
                _playername = value.Trim();

            }
        }
        public Position Position { get; set; }
        public Roster(int no, string playername, Position position)
        {
            No = no;
            Playername = playername;
            Position = Position;
        }
        public override string ToString()
        {
            return $"{No},{Playername},{Position}";
        }
    }
}
