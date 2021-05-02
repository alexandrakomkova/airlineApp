using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airlineApp.Model
{
    public class Plane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxOfPlaces { get; set; }
        public List<Flight> Flights { get; set; }

    }
}
