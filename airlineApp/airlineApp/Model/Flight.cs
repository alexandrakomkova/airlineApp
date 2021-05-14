using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airlineApp.Model
{
    public class Flight
    {
        public int Id { get; set; }
        public int WayId { get; set; }
        public Way Way { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }
        public int Price { get; set; }
        public int FreePlaces { get; set; }
        public List<Ticket> Tickets { get; set; }
        [NotMapped]
        public Company flightCompany 
        {
            get { return DataWorker.GetCompanyById(CompanyId); }
        }
        [NotMapped]
        public Way flightWay
        {
            get { return DataWorker.GetWayById(WayId); }
        }
        [NotMapped]
        public Plane flightPlane
        {
            get { return DataWorker.GetPlaneById(PlaneId); }
        }
    }
}
