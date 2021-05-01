using airlineApp.Model.Data;
using airlineApp.ViewModel;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
                //check existence
                bool IsExist = db.Companies.Any(el => el.Name == name);
                if (IsExist == false) 
                {
                    if (logo == null)
                    {
                        logo = @"Styles/no_image.png";
                    }
                    
                        Company newCompany = new Company { Name = name, Logo = logo };
                        db.Companies.Add(newCompany);
                        db.SaveChanges();
                        result = "Новая компания успешно добавлена!";
                    
                }
                return result;
            }
        }
        //create flight
        public static string CreateFlight(Way way, Company company, decimal price, int allPlaces)
        {
            string result = "Авиарейс с такими данными уже есть.";
            using (ApplicationContext db = new ApplicationContext())
            {
                //check existence
                bool IsExist = db.Flights.Any(el => el.Way == way 
                && el.Company==company 
                && el.AllPlaces == allPlaces );
                if (!IsExist)
                {
                    if (price <0)
                    {
                        price = 1000;
                    }
                    if (allPlaces<0) 
                    {
                        allPlaces = 100;
                    }
                    else
                    {
                        Flight newFlight = new Flight
                        {
                            WayId = way.Id,
                            CompanyId = company.Id,
                            AllPlaces = allPlaces,
                            FreePlaces = allPlaces,
                            Price = price
                        };
                       // DataManageViewModel.FlightCollection.Add(newFlight);
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
        public static string EditFlight(Flight oldFlight, Way newWay, Company newCompany, decimal newPrice, int newAllPlaces)
        {
            string result = "Авиарейса с такими данными не существует.";
            using (ApplicationContext db = new ApplicationContext())
            {
                Flight flight = db.Flights.FirstOrDefault(f => f.Id==oldFlight.Id);
                if (flight != null)
                {
                    flight.Price = newPrice;
                    flight.WayId = newWay.Id;
                    flight.CompanyId = newCompany.Id;
                    flight.AllPlaces = newAllPlaces;
                    int diff = flight.AllPlaces - (oldFlight.AllPlaces - oldFlight.FreePlaces);
                    if (diff > 0)
                    {
                        flight.FreePlaces = flight.AllPlaces - (oldFlight.AllPlaces - oldFlight.FreePlaces);
                        result = "Авиарейс " + flight.Id + "\r"
                        + flight.Company + "\n"
                        + flight.Way + "\n"
                        + " успешно изменен!";
                    }
                    else
                    {
                        //flight.FreePlaces = 0;
                        result = "Кто-то останется без билета. :(\nВажно, чтобы все, кто уже приобрели билет, смогли полететь этим самолетом.\n\nДанные о количестве мест не будут изменены. ";
                    }
                    db.SaveChanges();
                }
                
                
            }
            return result;
        }
        public static List<Flight> GetAllFlights()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Flights.ToList();
                
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

        public static List<Way> GetAllWays()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Ways.ToList();
                return result;
            }
        }

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
                    result = "Регистрация прошла успешно! Войдите в систему для дальнейшей работы.";

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
