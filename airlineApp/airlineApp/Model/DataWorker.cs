using airlineApp.Model.Data;
using airlineApp.ViewModel;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace airlineApp.Model
{
    public static class DataWorker
    {
        //create company
        public static string CreateCompany(string name, string logo) 
        {
            string result = "Компания с таким названием уже есть.";
           
            using (ApplicationContext db = new ApplicationContext()) 
            {
                
                bool IsExist = db.Companies.Any(el => el.Name == name);
                if (IsExist == false) 
                {
                    Company newCompany = new Company { Name = name, Logo = logo };
                        db.Companies.Add(newCompany);
                        db.SaveChanges();
                        result = "Новая компания успешно добавлена!";
                    
                }
                return result;
            }
        }
        public static string CreateTicket(string fullname, string passport, int seat, Flight flight, User user)
        {
            string result = "Что-то пошло не так..";

            using (ApplicationContext db = new ApplicationContext())
            {
                
                Ticket newTicket = new Ticket 
                { 
                    Fullname = fullname, 
                    Passport = passport,
                    Seat = seat,
                    IsPaid = false,
                    FlightId = flight.Id,
                    UserId = user.Id
                };
                db.Tickets.Add(newTicket);
                db.SaveChanges();
                result = "Билет успешно приобретен!\nМожете посмотреть данные о билете в пункте 'Мои билеты'";
                return result;
            }
        }
        //create flight
        public static string CreateFlight(Way way, string companyName, string planeName, int price)
        {
            string result = "Авиарейс с такими данными уже есть.";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check existence
                bool IsExist = db.Flights.Any(el => el.Way == way
                && el.Company.Name == companyName
                && el.Plane.Name == planeName);
                
                if (!IsExist)
                {
                    if (price < 1000)
                    {
                        price = 1000;
                    }
                    else
                    {
                        //MessageBox.Show(companyName.ToString());
                        var company = db.Companies.FirstOrDefault(c => c.Name == companyName);
                        var plane = db.Planes.FirstOrDefault(p => p.Name == planeName);
                        
                        Flight newFlight = new Flight
                        {
                            WayId = way.Id,
                            CompanyId = company.Id,
                            PlaneId = plane.Id,
                            Price = price,
                            FreePlaces = plane.MaxOfPlaces
                        };

                        db.Flights.Add(newFlight);
                        db.SaveChanges();
                        result = "Новый авиарейс успешно добавлен!";
                    }
                }
                return result;
            }
        }

        //delete company
        public static string DeleteCompany(Company company) 
        {
            string result = "Компании с таким названием не существует.";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Companies.Remove(company);
                db.SaveChanges();
                result = "Компания " + company.Name + " успешно удалена!";
            }
            return result;
        }
        //delete flight
        public static string DeleteFlight(Flight flight)
        {
            string result = "Авиарейса с такими данными не существует.";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Flights.Remove(flight);
                db.SaveChanges();
                result = "Авиарейс " + flight.Id + "\r" 
                    + flight.Company + "\n"
                    + flight.Way + "\n"
                    + " успешно удален!";
            }
            return result;
        }
        //public static void DeleteUser(User user)
        //{
            
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        db.Users.Remove(user);
        //        db.SaveChanges();

        //    }

        //}
        public static void EditUser(string email, string newPassword)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    IPasswordHasher hasher = new PasswordHasher();
                    string hashedPassword = hasher.HashPassword(newPassword);
                    user.Email = email;
                    user.Password = hashedPassword;

                    db.SaveChanges();
                }

            }
            
        }
        //edit company
        public static string EditCompany(Company oldCompany, string newName, string newLogo)
        {
            string result = "Компании с таким названием не существует.";
            using (ApplicationContext db = new ApplicationContext())
            {
                Company company = db.Companies.FirstOrDefault(c => c.Id == oldCompany.Id);
                if (company != null)
                {
                    company.Name = newName;
                    company.Logo = newLogo;

                    result = "Данные о компании были успешно изменены!";
                    db.SaveChanges();
                }

            }
            return result;
        }
        //edit flight
        public static string EditFlight(Flight oldFlight, Way newWay, string newCompanyName,string newPlaneName, int newPrice)
        {
            string result = "Авиарейса с такими данными не существует.";
            using (ApplicationContext db = new ApplicationContext())
            {
                var newCompany = db.Companies.FirstOrDefault(c => c.Name == newCompanyName);
                var newPlane = db.Planes.FirstOrDefault(p => p.Name == newPlaneName);
                Flight flight = db.Flights.FirstOrDefault(f => f.Id==oldFlight.Id);
                if (flight != null)
                {
                    flight.Price = newPrice;
                    flight.WayId = newWay.Id;
                    flight.CompanyId = newCompany.Id;
                    
                  
                    int diff  = newPlane.MaxOfPlaces - (oldFlight.flightPlane.MaxOfPlaces - oldFlight.FreePlaces);
                    
                        flight.PlaneId = newPlane.Id;
                        flight.FreePlaces = diff;
                        result = "Авиарейс " + flight.Id + " "
                        + flight.flightCompany.Name + " "
                        + flight.flightWay.Departure + "->"+ flight.flightWay.Arrival + "\n"
                        + " успешно изменен!";
                   
                    db.SaveChanges();
                }
                
                
            }
            return result;
        }
        public static List<Ticket> GetAllUserTickets(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Tickets.Where(t=> t.UserId == user.Id).ToList();

                return result;
            }
        }
        public static List<Ticket> GetAllUserTicketsSorted(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Tickets.Where(t => t.UserId == user.Id).OrderBy(t=>t.ticketWay).ToList();

                return result;
            }
        }
        public static List<Ticket> GetAllTickets()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Tickets.ToList();

                return result;
            }
        }
        public static List<Flight> GetAllFlights()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Flights.ToList();
                
                return result;
            }
        }

        public static List<Plane> GetAllPlanes()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Planes.ToList();

                return result;
            }
        }
        public static List<string> GetAllPlanesString()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Planes.Select(p => p.Name).Distinct().ToList();

                return result;
            }
        }

        public static List<Company> GetAllCompanies()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Companies.ToList();
                return result;
            }
        }
        public static List<string> GetAllCompaniesString()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Companies.Select(c => c.Name).Distinct().ToList();
                return result;
            }
        }

        public static List<Way> GetAllWays()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Ways.ToList(); //сделать группировку по полю

                return result;
            }
        }
        public static List<string> GetAllDepartures()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Ways.Select(w => w.Departure).Distinct().ToList(); //сделать группировку по полю

                return result;
            }
        }
        //public static List<List<Way>> GetAllWaysGr()
        //{
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        var result = db.Ways.GroupBy(w => w.Departure).Select(grp => grp.ToList()).ToList();

        //        return result;
        //    }
        //}

        //get company by id
        public static Company GetCompanyById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Company company = db.Companies.FirstOrDefault(p => p.Id == id);
                return company;
            }
        }
        //get way by id
        public static Way GetWayById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Way way  = db.Ways.FirstOrDefault(p => p.Id == id);
                return way;
            }
        }
        //public static Way GetWayByDepartureArrival(string d, string a)
        //{
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        Way way = db.Ways.FirstOrDefault(p => p.Departure == d && p.Arrival==);
        //        return way;
        //    }
        //}
        //get plane by id
        public static Plane GetPlaneById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Plane plane = db.Planes.FirstOrDefault(p => p.Id == id);
                return plane;
            }
        }
        public static Flight GetFlightById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Flight flight = db.Flights.FirstOrDefault(f => f.Id == id);
                return flight;
            }
        }
        //create user
        public static string CreateUser(string email, string password)
        {
            string result = "Пользователь с таким email уже зарегистрирован.";

            using (ApplicationContext db = new ApplicationContext())
            {
                //check existence
                bool IsExist = db.Users.Any(u => u.Email == email && u.Password==password);
                if (IsExist == false)
                {
                    IPasswordHasher hasher = new PasswordHasher();
                    string hashedPassword = hasher.HashPassword(password);

                    User newUser = new User { Email = email, Password = hashedPassword };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    result = "Регистрация прошла успешно!";

                }
                return result;
            }
        }
        //get user by email
        public static User GetUserByEmail(string e)
        {
            User user = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                user = db.Users.Where(u => u.Email == e).FirstOrDefault();
               
            }
            return user;
        }
    }
}
