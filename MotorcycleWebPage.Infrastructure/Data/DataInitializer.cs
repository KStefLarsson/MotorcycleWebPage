using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorcycleWebPage.Core.Models;

namespace MotorcycleWebPage.Infrastructure.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            dbContext.Database.Migrate();

            SeedRoles(dbContext);
            SeedUsers(userManager);
            SeedBikes(dbContext);
            SeedManufacturers(dbContext);
        }


        private static void SeedManufacturers(ApplicationDbContext dbContext)
        {
            if (!dbContext.Manufacturers.Any(m => m.Name == "Ducati"))
            {
                dbContext.Manufacturers.Add(new Manufacture
                {
                    Name = "Ducati",
                    Founded = 1926,
                    Country = "Italy",
                    Description = "Ducati Motor Holding S.p.A. är motorcykeltillverkningsavdelningen " +
                    "för det italienska företaget Ducati, med huvudkontor i Bologna, Italien. " +
                    "Företaget ägs av den italienska biltillverkaren Lamborghini, genom sitt tyska " +
                    "moderföretag Audi"
                });
            }
            if (!dbContext.Manufacturers.Any(m => m.Name == "Yamaha"))
            {
                dbContext.Manufacturers.Add(new Manufacture
                {
                    Name = "Yamaha",
                    Founded = 1955,
                    Country = "Japan",
                    Description = "Yamaha är en japansk tillverkare av motorcyklar, " +
                    "marina produkter som båtar och utombordsmotorer och andra motoriserade " +
                    "produkter. Företaget grundades 1955 efter separationen från Yamaha Corporation " +
                    "(dock är Yamaha Corporation fortfarande den största privata " +
                    "företagsägaren med 9,92%, från och med 2019), och har sitt huvudkontor i " +
                    "Iwata, Shizuoka, Japan."
                });
            }
            if (!dbContext.Manufacturers.Any(m => m.Name == "Kawazaki"))
            {
                dbContext.Manufacturers.Add(new Manufacture
                {
                    Name = "Kawazaki",
                    Founded = 1963,
                    Country = "Japan",
                    Description = "Under 1962 utvecklade Kawasaki-ingenjörer en fyrtakts " +
                    "motor för små bilar. Sedan överfördes några av ingenjörerna till Meguro" +
                    "fabrik för att arbeta på Meguro K1 och SG, en encylindrig 250 cc." +
                    "1963 gick Kawasaki och Meguro samman för att bilda Kawasaki Motorcycle Co." +
                    "Kawasaki - motorcyklar från 1962 till 1967 använde ett emblem som kan " +
                    "beskrivas som en flagga inom en vinge."
                });
            }
            if (!dbContext.Manufacturers.Any(m => m.Name == "Triumph"))
            {
                dbContext.Manufacturers.Add(new Manufacture
                {
                    Name = "Triumph",
                    Founded = 1983,
                    Country = "Great Britain",
                    Description = "Triumph Motorcycles Ltd är den största motorcykeltillverkaren " +
                    "i Storbritannien som grundades 1983 av John Bloor efter att det ursprungliga " +
                    "företaget Triumph Engineering gick i konkurs. [1] Det nya företaget, " +
                    "som ursprungligen kallades Bonneville Coventry Ltd, fortsatte Triumphs " +
                    "sortiment av motorcykelproduktion sedan 1902. De har stora " +
                    "tillverkningsanläggningar i Thailand."
                });
            }
            dbContext.SaveChanges();
        }

        private static void SeedBikes(ApplicationDbContext dbContext)
        {
            if (!dbContext.Motorcycles.Any(bike => bike.Model == "Diavel"))
            {
                dbContext.Motorcycles.Add(new Motorcycle
                {
                    ManufactureName = "Ducati",
                    Model = "Diavel",
                    TypeOfModel = "Touring",
                    Year = 2022,
                    HorsePower = "160hp",
                    TopSpeed = "272 km/h",
                    Description = "En crusier från Ducati med design och prestanda som bara Ducati " +
                    "kan skapa, X-Diavel! En slanglös DVT motor som levererar 98N.M " +
                    "redan vid 2000 varv och som mest 127N.M samt 160 hästkrafter. ABS, " +
                    "drivrem som standard. Ducati sätter ribban högt för definitionen av crusier!"
                });
            }
            if (!dbContext.Motorcycles.Any(bike => bike.Model == "Panigale V4 S"))
            {
                dbContext.Motorcycles.Add(new Motorcycle
                {
                    ManufactureName = "Ducati",
                    Model = "Panigale V4 S",
                    TypeOfModel = "Sport",
                    Year = 2018,
                    TopSpeed = "302 km/h",
                    HorsePower = "180hp",
                    Description = "Panigale V4S efterträdare till Panigale 1299. " +
                    "Unik grå färg framtagen av oss på Desmocenter. S versionen är utrustad med " +
                    "fullt justerbar aktiv elektronisk fjädring från Öhlins. Välkomna!"
                });
            }
            if (!dbContext.Motorcycles.Any(bike => bike.Model == "Mt-09"))
            {
                dbContext.Motorcycles.Add(new Motorcycle
                {
                    ManufactureName = "Yamaha",
                    Model = "Mt-09",
                    TypeOfModel = "Touring",
                    Year = 2021,
                    TopSpeed = "220 km/h",
                    HorsePower = "119hp",
                    Description = "Dess helt nya motor med 889cc och 119hk, " +
                    "hög kapacitet och kraftfullt vridmoment samt lätta aluminiumchassi " +
                    "ger en ännu mer spännande prestanda och vassa köregenskaper."
                });
            }
            if (!dbContext.Motorcycles.Any(bike => bike.Model == "Dragstar"))
            {
                dbContext.Motorcycles.Add(new Motorcycle
                {
                    ManufactureName = "Yamaha",
                    Model = "Dragstar",
                    TypeOfModel = "Custom",
                    Year = 2006,
                    TopSpeed = "200 km/h",
                    HorsePower = "96hp",
                    Description = "Allt krom är i gott skick, och piporna som kommer från Silvertail " +
                    "låter riktigt gott!  Trevlig maskin med gott om vrid med låg sitthöjd gör " +
                    "att den passar fint även för den som är lite kortare i rocken."
                });
            }
            if (!dbContext.Motorcycles.Any(bike => bike.Model == "VN800 Vulcan"))
            {
                dbContext.Motorcycles.Add(new Motorcycle
                {
                    ManufactureName = "Kawazaki",
                    Model = "VN800 Vulcan",
                    TypeOfModel = "Custom",
                    Year = 2004,
                    TopSpeed = "180 km/h",
                    HorsePower = "55hp",
                    Description = "En klassisk hoj med otroligt skön komfort"
                });
            }
            if (!dbContext.Motorcycles.Any(bike => bike.Model == "Ninja ZX-10R"))
            {
                dbContext.Motorcycles.Add(new Motorcycle
                {
                    ManufactureName = "Kawazaki",
                    Model = "Ninja ZX-10R",
                    TypeOfModel = "Sport",
                    Year = 2019,
                    TopSpeed = "320 km/h",
                    HorsePower = "203hp",
                    Description = "Kawasaki Ninja ZX-10R är en motorcykel i Ninja sportcykelserien " +
                    "från den japanska tillverkaren Kawasaki, efterföljaren till Ninja ZX-9R. " +
                    "Den släpptes ursprungligen 2004 och har uppdaterats och reviderats genom åren."
                });
            }
            if (!dbContext.Motorcycles.Any(bike => bike.Model == "Speed triple RS"))
            {
                dbContext.Motorcycles.Add(new Motorcycle
                {
                    ManufactureName = "Triumph",
                    Model = "Speed triple RS",
                    TypeOfModel = "Touring",
                    Year = 2021,
                    TopSpeed = "245 km/h",
                    HorsePower = "177hp",
                    Description = "Den mest kraftfulla starkaste och snabbaste Speed Triple någonsin." +
                    "Helt ny 1160 kubikstrippel på 177hk och 125nm. Totalt 10kg lättare än tidigare. "
                });
            }
            if (!dbContext.Motorcycles.Any(bike => bike.Model == "Rocket 3 GT"))
            {
                dbContext.Motorcycles.Add(new Motorcycle
                {
                    ManufactureName = "Triumph",
                    Model = "Rocket 3 GT",
                    TypeOfModel = "Custom",
                    Year = 2020,
                    TopSpeed = "230 km/h",
                    HorsePower = "167hp",
                    Description = "Rocket 3:s 2,500cc är världens största " +
                     "motorcykelmotor och är optimerad för att ge 18 kg massbesparingar " +
                     "jämfört med den tidigare Rocket-generationen, för spännande prestanda " +
                     "och hela dagen, alla växlar, enkel turkapacitet. ",
                });
            }
            dbContext.SaveChanges();
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            AddUserIfNotExists(userManager, "stefan.holmberg@systementor.se", "Hejsan123#", new string[] { "Admin" });
            AddUserIfNotExists(userManager, "stefan.larsson.syne20lin@tucsweden.se", "Hejsan123#", new string[] { "Customer" });
        }

        private static void AddUserIfNotExists(UserManager<IdentityUser> userManager,
        string userName, string password, string[] roles)
        {
            if (userManager.FindByEmailAsync(userName).Result != null) return;

            var user = new IdentityUser
            {
                UserName = userName,
                Email = userName,
                EmailConfirmed = true
            };
            var result = userManager.CreateAsync(user, password).Result;
            var r = userManager.AddToRolesAsync(user, roles).Result;
        }
        private static void SeedRoles(ApplicationDbContext dbContext)
        {
            if (!dbContext.Roles.Any(r => r.Name == "Admin"))
            {
                dbContext.Roles.Add(new IdentityRole
                {
                    NormalizedName = "Admin",
                    Name = "Admin"
                });
            }
            if (!dbContext.Roles.Any(r => r.Name == "Customer"))
            {
                dbContext.Roles.Add(new IdentityRole
                {
                    NormalizedName = "Customer",
                    Name = "Customer"
                });
            }
            dbContext.SaveChanges();
        }
    }
}
