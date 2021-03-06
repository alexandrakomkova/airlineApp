using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsPaid { get; set; }
        public string Passport { get; set; }
        public string Fullname { get; set; }
        public int Seat { get; set; }
        [NotMapped]
        public Flight ticketFlight
        {
            get { return DataWorker.GetFlightById(FlightId); }
        }
        [NotMapped]
        public Company ticketCompany
        {
            get { return DataWorker.GetCompanyById(ticketFlight.CompanyId); }
        }
        [NotMapped]
        public Way ticketWay
        {
            get { return DataWorker.GetWayById(ticketFlight.WayId); }
        }
        [NotMapped]
        public Plane ticketPlane
        {
            get { return DataWorker.GetPlaneById(ticketFlight.PlaneId); }
        }
    }
}
