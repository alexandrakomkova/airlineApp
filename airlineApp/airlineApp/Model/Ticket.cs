using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airlineApp.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public bool IsPaid { get; set; }
        public string Passport { get; set; }
        public string Fullname { get; set; }
    }
}
