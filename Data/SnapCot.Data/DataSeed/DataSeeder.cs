namespace SnapCot.Data.DataSeed
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Linq;

    public class DataSeeder : IDataSeeder
    {
        const string AdminRole = "Admin";
        const string AdminName = "admin@gmail.com";

        const string ManagerRole = "SupplyManager";
        const string ManagerName = "snapcotmag@snap.com";

        private SnapCotDbContext context;

        public DataSeeder(SnapCotDbContext context)
        {
            this.context = context;
        }

        public void SeedData()
        {
            var countries = new string[]
              {
                        "Afghanistan",
                        "Albania",
                        "Algeria",
                        "Argentina",
                        "Armenia",
                        "Australia",
                        "Austria",
                        "Azerbaijan",
                        "Bahamas",
                        "Bahrain",
                        "Bangladesh",
                        "Barbados",
                        "Belarus",
                        "Belgium",
                        "Bolivia",
                        "Bosnia and Herzegovina",
                        "Botswana",
                        "Bouvet Island",
                        "Brazil",
                        "Bulgaria",
                        "Cambodia",
                        "Canada",
                        "Chad",
                        "Chile",
                        "China",
                        "Colombia",
                        "Congo",
                        "Costa Rica",
                        "Croatia",
                        "Czech Republic",
                        "Denmark",
                        "Djibouti",
                        "Dominica",
                        "Dominican Republic",
                        "Ecuador",
                        "Egypt",
                        "Estonia",
                        "Ethiopia",
                        "Finland",
                        "France",
                        "Gabon",
                        "Gambia",
                        "Georgia",
                        "Germany",
                        "Ghana",
                        "Gibraltar",
                        "Greece",
                        "Greenland",
                        "Grenada",
                        "Guadeloupe",
                        "Guam",
                        "Guatemala",
                        "Guinea",
                        "Guyana",
                        "Haiti",
                        "Honduras",
                        "Hong Kong",
                        "Hungary",
                        "Iceland",
                        "India",
                        "Indonesia",
                        "Iraq",
                        "Ireland",
                        "Israel",
                        "Italy",
                        "Jamaica",
                        "Japan",
                        "Jordan",
                        "Kazakhstan",
                        "Kenya",
                        "Kyrgyzstan",
                        "Latvia",
                        "Lebanon",
                        "Lithuania",
                        "Luxembourg",
                        "Mexico",
                        "Monaco",
                        "Namibia",
                        "Nauru",
                        "Nepal",
                        "Netherlands",
                        "Netherlands Antilles",
                        "New Caledonia",
                        "New Zealand",
                        "Nicaragua",
                        "Niger",
                        "Nigeria",
                        "Niue",
                        "Norfolk Island",
                        "Northern Mariana Islands",
                        "Norway",
                        "Oman",
                        "Pakistan",
                        "Palau",
                        "Palestinian Territory, Occupied",
                        "Panama",
                        "Papua New Guinea",
                        "Paraguay",
                        "Peru",
                        "Philippines",
                        "Pitcairn",
                        "Poland",
                        "Portugal",
                        "Puerto Rico",
                        "Qatar",
                        "Reunion",
                        "Romania",
                        "Russia",
                        "Saudi Arabia",
                        "Serbia and Montenegro",
                        "Singapore",
                        "Slovenia",
                        "South Africa",
                        "Spain",
                        "Sri Lanka",
                        "Sudan",
                        "Sweden",
                        "Switzerland",
                        "Taiwan, Province of China",
                        "Tajikistan",
                        "Thailand",
                        "Togo",
                        "Trinidad and Tobago",
                        "Turkey",
                        "Turkmenistan",
                        "Uganda",
                        "Ukraine",
                        "United Arab Emirates",
                        "United Kingdom",
                        "United States",
                        "Uruguay",
                        "Uzbekistan",
                        "Vanuatu",
                        "Venezuela",
                        "Viet Nam",
                        "Zambia",
                        "Zimbabwe",
              };

            var industries = new string[]
            {
                    "Agriculture",
                    "Coatings & Adhesives",
                    "Environmental Sciences",
                    "Food Ingredients",
                    "Household & Industrial Cleaning",
                    "Mining",
                    "Oil & Gas",
                    "Personal Care",
                    "Pharma Ingredients",
                    "Water Treatment"
            };

            var hazards = new string[]
            {
                "Not Classified",
                "Explosives",
                "Gases",
                "Flammable Liquids",
                "Flammable Solids",
                "Oxidizing Substances",
                "Toxic & Infectious Substances",
                "Radioactive Material",
                "Corrosives",
                "Miscellaneous Dangerous Goods"
            };

            if (!this.context.Countries.Any())
            { 
                foreach (var countryName in countries)
                {
                    var newCountry = new Country()
                    {
                        Name = countryName
                    };

                    this.context.Countries.Add(newCountry);
                }

                this.context.SaveChanges();
            }

            if (!this.context.Industries.Any())
            {
                foreach (var industryName in industries)
                {
                    var newIndustry = new Industry()
                    {
                        Name = industryName
                    };

                    this.context.Industries.Add(newIndustry);
                }

                this.context.SaveChanges();
            }

            if (!this.context.HazardClassifications.Any())
            {
                foreach (var hazard in hazards)
                {
                    var newHazard = new HazardClassification()
                    {
                        Class = hazard
                    };

                    this.context.HazardClassifications.Add(newHazard);
                }

                this.context.SaveChanges();
            }

            if (!this.context.TransportModes.Any())
            {
                var sea = new TransportMode()
                {
                    Mode = "sea freight"
                };

                var air = new TransportMode()
                {
                    Mode = "air freight"
                };

                this.context.TransportModes.Add(sea);
                this.context.TransportModes.Add(air);

                this.context.SaveChanges();
            }
        }

        public void SeedRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.context));

            if (!(roleManager.Roles.Any()))
            {
                roleManager.Create(new IdentityRole() { Name = AdminRole });
                roleManager.Create(new IdentityRole() { Name = ManagerRole });
                this.context.SaveChanges();
            }
        }

        public void SeedUsers()
        {
            if (this.context.Users.Any())
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(this.context));

            var adminUser = new User()
            {
                Email = AdminName,
                RegistrationDate = DateTime.Now,
                CreditLimit = 0,
                Telephone = "+359895177466",
                Address = "Sofia, bul. Alexandar Malinov",
                Name = "SnapCot",
                UserName = AdminName
            };

            var supplyManagerUser = new SupplyManager()
            {
                Email = ManagerName,
                RegistrationDate = DateTime.Now,
                CreditLimit = 0,
                Telephone = "+359895188499",
                Address = "Sofia, bul. Alexandar Malinov",
                Name = "SnapCot",
                UserName = ManagerName
            };

            var result = userManager.Create(adminUser, "123456");
            userManager.Create(supplyManagerUser, "654321");

            var admin = this.context.Users.FirstOrDefault(u => u.Email == AdminName);
            var manager = this.context.Users.FirstOrDefault(u => u.Email == ManagerName);

            userManager.AddToRole(admin.Id, AdminRole);
            userManager.AddToRole(manager.Id, ManagerRole);
        }
    }
}
