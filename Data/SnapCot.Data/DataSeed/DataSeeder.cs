namespace SnapCot.Data.DataSeed
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.IO;

    public class DataSeeder : IDataSeeder
    {
        const string AdminRole = "Admin";
        const string AdminName = "admin@gmail.com";

        const string ManagerRole = "SupplyManager";
        const string ManagerName = "snapcotmag@snap.com";

        private SnapCotDbContext context;
        private static readonly Random generator = new Random();

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

            // Producers
            if (!this.context.Producers.Any())
            {
                var inputCountries = this.context.Countries.ToList();
                SeedProducers(inputCountries);
            }

            if (!this.context.Products.Any())
            {

                // Images
                var images = new List<Image>();
                var directory = AssemblyHelpers.GetDirectoryForAssembyl(Assembly.GetExecutingAssembly());
                var files = Directory.GetFiles(directory + "/Images/", "*.*");
                foreach (var file in files)
                {
                    var byteArray = File.ReadAllBytes(file);
                    var image = new Image
                    {
                        Content = byteArray,
                        FileExtension = file.Substring(file.LastIndexOf(".") + 1)
                    };

                    images.Add(image);
                }

                // Products
                var producers = this.context.Producers.ToList();
                var classifications = this.context.HazardClassifications.ToList();
                var industryType = this.context.Industries.ToList();
                var products = new List<Product>
            {
                new Product
                {
                     Name = "ACETIC ACID",
                     Description = "An organic compound with the chemical formula CH3COOH (also written as CH3CO2H or C2H4O2). It is a colourless liquid that when undiluted is also called glacial acetic acid. Vinegar is roughly 3–9% acetic acid by volume, making acetic acid the main component of vinegar apart from water. Acetic acid has a distinctive sour taste and pungent smell. Besides its production as household vinegar, it is mainly produced as a precursor to polyvinylacetate and cellulose acetate. Although it is classified as a weak acid, concentrated acetic acid is corrosive and can attack the skin.",
                     Price = 22.49M,
                     Quantity = 10M,
                     ProductType = ProductType.Liquid,
                     DateAdded = DateTime.Now
                },
                  new Product
                {
                     Name = "AMMONIUM BISULPHITE",
                     Description = "A white, crystalline solid with formula (NH4)HSO4. It is the product of the half-neutralization of sulfuric acid by ammonia.",
                     Price = 15.50M,
                     Quantity = 5M,
                     ProductType = ProductType.Powder,
                     DateAdded = DateTime.Now
                },
                new Product
                {
                     Name = "AMMONIUM CHLORIDE",
                     Description = "An inorganic compound with the formula NH4Cl, is a white crystalline salt, highly soluble in water. Solutions of ammonium chloride are mildly acidic. Sal ammoniac is a name of the natural, mineralogical form of ammonium chloride. The mineral is commonly formed on burning coal dumps, due to condensation of coal-derived gases. It is also found around some types of volcanic vents. It is mainly used as fertilizer and a flavouring agent in some types of liquorice. It is the product from the reaction of hydrochloric acid and ammonia.",
                     Price = 14.44M,
                     Quantity = 6M,
                     ProductType = ProductType.Powder,
                     DateAdded = DateTime.Now
                },
                new Product
                {
                     Name = "Baryte",
                     Description = "A mineral consisting of barium sulfate.The baryte group consists of baryte, celestine, anglesite and anhydrite. Baryte is generally white or colorless, and is the main source of barium. Baryte and celestine form a solid solution (Ba,Sr)SO4",
                     Price = 16.99M,
                     Quantity = 7M,
                     ProductType = ProductType.Powder,
                     DateAdded = DateTime.Now
                },
                 new Product
                {
                     Name = "HYDRATED ALUMINIUM SILICATE",
                     Description = "Aluminium silicate is a type of fibrous material made of aluminium oxide and silicon dioxide, (such materials are also called aluminosilicate fibres). These are glassy solid solutions rather than chemical compounds. The compositions are often described in terms of % weight of alumina, Al2O3 and silica, SiO2. Temperature resistance increases as the % alumina increases. These fibrous materials can be encountered as loose wool, blanket, felt, paper or boards.",
                     Price = 16.89M,
                     Quantity = 5.5M,
                     ProductType = ProductType.Powder,
                     DateAdded = DateTime.Now
                },
                 new Product
                {
                     Name = "CALCIUM CARBONATE",
                     Description = "A chemical compound with the formula CaCO3. It is a common substance found in rocks as the minerals calcite and aragonite (most notably as limestone), and is the main component of shells of marine organisms, snails, pearls, and eggshells. Calcium carbonate is the active ingredient in agricultural lime, and is created when calcium ions in hard water react with carbonate ions creating limescale. It is commonly used medicinally as a calcium supplement or as an antacid, but excessive consumption can be hazardous.",
                     Price = 16.89M,
                     Quantity = 6M,
                     ProductType = ProductType.Powder,
                     DateAdded = DateTime.Now
                },
                  new Product
                {
                     Name = "CITRIC ACID",
                     Description = "A weak organic tribasic acid. It occurs naturally in citrus fruits. In biochemistry, it is an intermediate in the citric acid cycle, which occurs in the metabolism of all aerobic organisms.More than a million tons of citric acid are manufactured every year. It is used widely as an acidifier, as a flavoring, and as a chelating agent.",
                     Price = 22M,
                     Quantity = 9M,
                     ProductType = ProductType.Liquid,
                     DateAdded = DateTime.Now
                },
                new Product
                {
                     Name = "CITRIC ACID",
                     Description = "A weak organic tribasic acid. It occurs naturally in citrus fruits. In biochemistry, it is an intermediate in the citric acid cycle, which occurs in the metabolism of all aerobic organisms.More than a million tons of citric acid are manufactured every year. It is used widely as an acidifier, as a flavoring, and as a chelating agent.",
                     Price = 22M,
                     Quantity = 9M,
                     ProductType = ProductType.Liquid,
                     DateAdded = DateTime.Now
                },
                new Product
                {
                     Name = "GLUTARALDEHYDE",
                     Description = "An organic compound with the formula CH2(CH2CHO)2. A pungent colorless oily liquid, glutaraldehyde is used to sterilise medical and dental equipment. It is also used for industrial water treatment and as a preservative. It is mainly available as an aqueous solution, and in these solutions the aldehyde groups are hydrated.",
                     Price = 23.99M,
                     Quantity = 8M,
                     ProductType = ProductType.Liquid,
                     DateAdded = DateTime.Now
                },
                new Product
                {
                     Name = "GLUTARALDEHYDE",
                     Description = "A clear, colorless, highly pungent solution of hydrogen chloride (HCl) in water. It is a highly corrosive, strong mineral acid with many industrial uses. Hydrochloric acid is found naturally in gastric acid. When it reacts with an organic base it forms a hydrochloride salt",
                     Price = 10.99M,
                     Quantity = 6M,
                     ProductType = ProductType.Liquid,
                     DateAdded = DateTime.Now
                },
                 new Product
                {
                     Name = "ISO-BUTANOL",
                     Description = "An organic compound with the formula (CH3)2CHCH2OH (sometimes represented as i-BuOH). This colorless, flammable liquid with a characteristic smell is mainly used as a solvent. Its isomers, the other butanols, include n-butanol, 2-butanol, and tert-butanol, all of which are important industrially.",
                     Price = 9.95M,
                     Quantity = 7M,
                     ProductType = ProductType.Liquid,
                     DateAdded = DateTime.Now
                },
                new Product
                {
                     Name = "Starch",
                     Description = "A carbohydrate consisting of a large number of glucose units joined by glycosidic bonds. This polysaccharide is produced by most green plants as an energy store. It is the most common carbohydrate in human diets and is contained in large amounts in staple foods such as potatoes, wheat, maize (corn), rice, and cassava. Pure starch is a white, tasteless and odorless powder that is insoluble in cold water or alcohol. It consists of two types of molecules: the linear and helical amylose and the branched amylopectin.Depending on the plant, starch generally contains 20 to 25 % amylose and 75 to 80 % amylopectin by weight.",
                     Price = 25M,
                     Quantity = 10M,
                     ProductType = ProductType.Powder,
                     DateAdded = DateTime.Now
                },
                 new Product
                {
                     Name = "SODIUM CHLORIDE",
                     Description = "An ionic compound with the chemical formula NaCl, representing a 1:1 ratio of sodium and chloride ions. Sodium chloride is the salt most responsible for the salinity of seawater and of the extracellular fluid of many multicellular organisms. In the form of edible or table salt it is commonly used as a condiment and food preservative. Large quantities of sodium chloride are used in many industrial processes, and it is a major source of sodium and chlorine compounds used as feedstocks for further chemical syntheses. A second major consumer of sodium chloride is de-icing of roadways in sub-freezing weather.",
                     Price = 21M,
                     Quantity = 10M,
                     ProductType = ProductType.Powder,
                     DateAdded = DateTime.Now
                }
            };

                for (int i = 0; i < products.Count; i++)
                {
                    products[i].ProducerId = producers[generator.Next(0, producers.Count())].Id;
                    products[i].HazardClassificationId = classifications[generator.Next(0, classifications.Count())].Id;
                    products[i].Industries.Add(industryType[generator.Next(0, industryType.Count())]);
                    products[i].Picture = images[i];

                    this.context.Products.Add(products[i]);
                }

                this.context.SaveChanges();
            }
        }

        private void SeedProducers(IList<Country> countries)
        {
            var producers = new List<Producer>()
            {
                new Producer()
                {
                     Name = "Weifang Qiangyuan Chemical Industry Co., LTD",
                     Address = "Binhai Economic Development Zone, Weifang, Shandong 62737",
                     Telephone = "86-536-8309826",
                     Website = "www.bro-chem.com",
                     Email = "qiangyuan@gmail.com"
                },
                new Producer()
                {
                     Name = "WEIFANG HONGYUAN CHEMICAL CO., LTD",
                     Address = "XINXING INDUSTRIAL PARK,DAJIAWA SUB-DISTRICT OFFICE,COASTAL ECONOMIC DEVELOPMENT ZONE,WEIFANG CITY",
                     Telephone = "+86-536-8897257",
                     Email = "hongyuan@gmail.com"
                },
                  new Producer()
                {
                     Name = "Saboo Sodium Chloro Ltd.",
                     Address = "Surya House, L-5, B-ll, Krishna Marg, C Scheme, Ashok Nagar, Jaipur- 302 001 Rajasthan",
                     Telephone = "+86-536-8897257",
                     Email = "hongyuan@gmail.com"
                },
                new Producer()
                {
                     Name = "Fineton Industrial Minerals Limited",
                     Address = "No. 11, 3/F., International Trade Centre, 11-19 Sha Tsui Road, Tsuen Wan, N. T.",
                     Telephone = "(852) 2402-1782",
                     Email = "ericlo@fineton.com"
                },
                new Producer()
                {
                     Name = "JAY MINERALS",
                     Address = "Plot No. 1003/4, Phase – IV,G.I.D.C. Estate, Naroda",
                     Telephone = "091-79-2281 3294",
                     Email = "info@jayminerals.com",
                     Website = "www.jayminerals.com"
                },
                new Producer()
                {
                     Name = "Kutch Chemilcal lndustries Limited",
                     Address = "20121, Harinagar Co. Op. Society, Gotri Road, Earoda'390 007",
                     Telephone = "91 265 2397013",
                     Email = "info@kutch.com",
                     Website = "www.kcil.co.in"
                },
                 new Producer()
                {
                     Name = "TOC Glycol Company Limited",
                     Address = "555/1, Energy Complex Building A, 15th Floor, Vibhavadi Rangsit Road, Chatuchak, Bangkok 10900",
                     Telephone = "91 265 2397013",
                     Email = "info@glycol.com",
                },
                new Producer()
                {
                     Name = "Timuraya Tunggal Company",
                     Address = "Perkantoran Permata Senayan D-35, Jl. Tentara Pelajar, Jakarta-12210",
                     Telephone = "(62-21) 5794 0809",
                     Email = "contact@timuraya.com",
                     Website = "www.timuraya.com"
                },
                new Producer()
                {
                     Name = "Kemira France SAS",
                     Address = "Route de Mothern, Zone Portuaire FR-67630 L Lauterbourg",
                     Telephone = "+33 3 8854 9850",
                     Email = "contact@kemira.com",
                },
                new Producer()
                {
                     Name = "SHRI GANDHAR CHEMICAL INDUSTRIES",
                     Address = "VASUNDHAR, SARAOGIAN STREET, BEAWAR – 305901, RAJASTHAN",
                     Telephone = "+91-1462-258850",
                     Email = "info@shrigandhar.com",
                     Website = "www.shrigandhar.com"
                },
                new Producer()
                {
                     Name = "Esseco Srl",
                     Address = "Via S. Cassiano 99 - San Martino, 28069 Trecate",
                     Telephone = "+39 0321 7901",
                     Email = "esseco@esseco.it",
                }
            };

            foreach (var producer in producers)
            {
                producer.CountryId = countries[generator.Next(0, countries.Count())].Id;
                this.context.Producers.Add(producer);
            }

            this.context.SaveChanges();
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
