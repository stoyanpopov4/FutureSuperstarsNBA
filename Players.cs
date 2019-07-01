using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureSuperstarsNBA
{
    class Players
    {
        public string Name { get; set; }
        public int PlayingSince { get; set; }
        public string Position { get; set; }
        public int Rating { get; set; }

        public String ToCSV()
        {
            return string.Format(Name + ", " + Rating.ToString());
        }
    }
}
