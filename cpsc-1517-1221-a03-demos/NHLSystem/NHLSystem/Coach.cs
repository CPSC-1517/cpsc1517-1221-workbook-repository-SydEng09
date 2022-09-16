using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystem
{
    public class Coach : Person
    {
        public DateTime HireDate { get; set; }

        public Coach(string fullName, DateTime hireDate) : base(fullName)
        {
            HireDate = hireDate;
        }
    }
}
