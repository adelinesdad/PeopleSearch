using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PeopleSearch.Models
{
    public class PersonInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            const int NumPersons = 100;

            // generated from http://listofrandomnames.com/
            var names = new string[]
            {
                "Beatrice Limberg",
                "Carita Felten",
                "Dexter Ramires",
                "Aura Ochsner",
                "Cheree Ebel",
                "Cherrie Dougherty",
                "Geneva Spaulding",
                "Renato Byrom",
                "Taina Patnode",
                "Denita Berg",
                "Floy Mcintyre",
                "Ricardo Horak",
                "Zackary Ambler",
                "Tam Jester",
                "Lucienne Oubre",
                "Eldridge Deng",
                "Jonathan Hebb",
                "Mandie Gauna",
                "Melba Spillers",
                "Janine Bradham",
                "Delma Elzey",
                "Lai Schwartzberg",
                "Elisa Coblentz",
                "Diego Ellithorpe",
                "Elden Latham",
                "Rufus Fasano",
                "Ta Geers",
                "Fredric Cimmino",
                "Carman Croyle",
                "Leonia Meadows",
                "Trinh Vause",
                "Johnna Demmer",
                "Christie Balboa",
                "Jenine Bagdon",
                "Patrina Rodarte",
                "Dorla Kirwin",
                "Slyvia Harbin",
                "Reed Petrarca",
                "Rema Foxx",
                "Ozie Borey",
                "Vanetta Kessler",
                "Earnest Bonilla",
                "King Ice",
                "Dale Garvey",
                " Crim",
                "Cora Pettus",
                "Elizbeth Bold",
                "Angila Zucco",
                "Louann Armer",
                "Celinda Schwanke",
                "Natashia Lollar",
                "Elly Wernick",
                "Haywood Anderton",
                "Nerissa Crandall",
                "German Meshell",
                "Remona Knarr",
                "Marjory Jankowski",
                "Wynona Jefferis",
                "Shawnee Saraiva",
                "Conception Schlater",
                "Leana Washinton",
                "Carrie Diller",
                "Grady Lefebure",
                "Sharen Patton",
                "Richie Hauptman",
                "Aleida Nickle",
                "Jenae Najera",
                "Nieves Mcnickle",
                "Tiana Crabtree",
                "Eloy Webb",
                "Naomi Rotenberry",
                "Jody Woodford",
                "Wanda Paschal",
                "Nina Zavala",
                "Serina Luken",
                "Kasha Dundon",
                "Anamaria Catlin",
                "Elinor Dysart",
                "Harley Branch",
                "Bernie Taff",
                "Sheree Fillers",
                "Trudi Wardlow",
                "Rivka Truelove",
                "Edward Alex",
                "Willie Novotny",
                "Clementina Cramer",
                "Luetta Carnley",
                "Penelope Longenecker",
                "Domitila Kilcrease",
                "Buffy Leday",
                "Georgianna Guyette",
                "Erlene Rains",
                "Jackson Sheely",
                "Lauran Dearborn",
                "Leisa Hise",
                "Buster Gesell",
                "Hae Fairweather",
                "Lesa Rasnick",
                "Wendy Mannings",
                "Cary Pardon"
            };

            // generated from https://www.randomlists.com/random-addresses
            var addresses = new string[]
            {
                "94 Newport St. New Kensington, PA 15068",
                "91 St Louis Street, Reading, MA 01867",
                "426 Homewood Street, Springboro, OH 45066",
                "337 Liberty Ave., Howard Beach, NY 11414",
                "206 Cedar Swamp Ave., Corona, NY 11368",
                "7905 Pin Oak Ave., Apex, NC 27502",
                "9291 Bishop Ave., Bettendorf, IA 52722",
                "9329 Williams Street, Mason, OH 45040",
                "8261 W. Roberts St., Chester, PA 19013",
                "594 Pawnee Dr., Port Huron, MI 48060",
                "28 Tower Road, Norwood, MA 02062",
                "78 Littleton St., Westbury, NY 11590",
                "876 E. Young Street, El Dorado, AR 71730",
                "811 Nicolls Lane, Torrington, CT 06790",
                "740 Branch St., New Orleans, LA 70115",
                "9590 N. Fairview Street, Brownsburg, IN 46112",
                "9853 Riverside Dr., Anaheim, CA 92806",
                "215 Meadowbrook Lane, Boynton Beach, FL 33435",
                "9488 Sycamore Ave., Syosset, NY 11791",
                "189 SW. Devonshire Drive, Roselle, IL 60172",
                "65 Golden Star Dr., Mansfield, MA 02048",
                "597 Warren Rd., Macomb, MI 48042",
                "532 Depot Drive, Harrisonburg, VA 22801",
                "922 Colonial Lane, Petersburg, VA 23803",
                "4 Edgemont Court, Fargo, ND 58102",
                "6 Mountainview St., Pasadena, MD 21122",
                "929 Winchester Dr., Tewksbury, MA 01876",
                "7596 Belmont St., Bonita Springs, FL 34135",
                "155 Beechwood Drive, Southgate, MI 48195",
                "9318 Main Street, Opa Locka, FL 33054",
                "82 Mill Pond Court, Elmont, NY 11003",
                "695 Thatcher Avenue, Norwalk, CT 06851",
                "361 Pennington St., Vincentown, NJ 08088",
                "884 2nd Avenue, Point Pleasant Beach, NJ 08742",
                "8761 Highland Street, Maplewood, NJ 07040",
                "44 Ridgewood St., Longwood, FL 32779",
                "115 Glen Eagles Court, Wappingers Falls, NY 12590",
                "1 Lafayette Ave., Satellite Beach, FL 32937",
                "33 Temple St., La Crosse, WI 54601",
                "7516 Birch Hill Court, Henrico, VA 23228",
                "415 Magnolia St., West Bloomfield, MI 48322",
                "9292 West Hawthorne Dr., York, PA 17402",
                "85 Pheasant Street, Hempstead, NY 11550",
                "40 Middle River St., Asheville, NC 28803",
                "8932 Rockville Rd., Kearny, NJ 07032",
                "47 Summerhouse Lane, Cartersville, GA 30120",
                "24 S. Prairie Street, Elizabethtown, PA 17022",
                "853 Division Dr., High Point, NC 27265",
                "48 South Edgewood Rd., Orland Park, IL 60462",
                "842 Lilac St., Hopkins, MN 55343",
                "466 Lawrence St., Oshkosh, WI 54901",
                "674 NW. Rockledge Street, Round Lake, IL 60073",
                "9199 Bay Rd., Chattanooga, TN 37421",
                "50 N. Maple Circle, Brookline, MA 02446",
                "573 Hartford St., Poughkeepsie, NY 12601",
                "9811 Overlook Lane, Allison Park, PA 15101",
                "7237 Brewery Court, Powell, TN 37849",
                "584 Fairview Court, Hammonton, NJ 08037",
                "694 Taylor Ave., Saint Albans, NY 11412",
                "5 Overlook St., Woonsocket, RI 02895",
                "899 Rock Maple Dr., Spring Valley, NY 10977",
                "528 Taylor Drive, Reynoldsburg, OH 43068",
                "8941 3rd Street, West Springfield, MA 01089",
                "787 Beacon St., Deerfield, IL 60015",
                "9628 Constitution Lane, Avon Lake, OH 44012",
                "134 Bow Ridge Lane, Melbourne, FL 32904",
                "684 Gonzales Street, Northville, MI 48167",
                "4 Princess Drive, Southgate, MI 48195",
                "870 Pulaski Ave., North Ridgeville, OH 44039",
                "612 Ocean Street, Defiance, OH 43512",
                "5 Glenridge Dr., Port Saint Lucie, FL 34952",
                "9718 Prairie Lane, Jupiter, FL 33458",
                "326 Fairfield Lane, Hialeah, FL 33010",
                "8477 Fieldstone St., Schenectady, NY 12302",
                "435 Race Rd., Defiance, OH 43512",
                "7040 Oak Meadow St.,Littleton, CO 80123",
                "41 Meadowbrook Road, Grandville, MI 49418",
                "89 Summit Street, East Haven, CT 06512",
                "773 Wilson Street, Westminster, MD 21157",
                "883 Proctor Dr., Waltham, MA 02453",
                "60 Vine St., Ephrata, PA 17522",
                "979 Glen Ridge Rd., Winter Springs, FL 32708",
                "36 South Crescent St., Lumberton, NC 28358",
                "368 Overlook Ave., Southgate, MI 48195",
                "10 Sunbeam Lane, Ashtabula, OH 44004",
                "192 South Jefferson St., Boca Raton, FL 33428",
                "7383 Front Road, Barrington, IL 60010",
                "6 Oklahoma Street, Nutley, NJ 07110",
                "171 Fairground Rd., Salt Lake City, UT 84119",
                "9260 Nut Swamp Dr., Bangor, ME 04401",
                "9796 North Vernon Street, Douglasville, GA 30134",
                "428 E. Manor Station Ave., Ballston Spa, NY 12020",
                "8556 Spruce St., Glen Burnie, MD 21060",
                "76 Old 8th Drive, Woodbridge, VA 22191",
                "23 Arch Street, Nashville, TN 37205",
                "3 Prairie Street, Roy, UT 84067",
                "789 San Carlos Road, North Tonawanda, NY 14120",
                "9321 Winding Way St., Macomb, MI 48042",
                "95 Fulton Street, Monroeville, PA 15146",
                "33 Pin Oak Rd., Mocksville, NC 27028"
            };

            if (names.Length != NumPersons || addresses.Length != NumPersons)
            {
                throw new InvalidOperationException("Invalid initialization data");
            }

            Random rand = new Random();
            for (int i = 0; i < NumPersons; i++)
            {
                context.People.Add(new Person()
                {
                    Name = names[i],
                    Address = addresses[i],
                    Age = rand.Next(0, 100),
                    Interests = GenerateRandomInterests(rand),
                    ImageURL = GenerateRandomImageURL(rand)
                });
            }

            context.SaveChanges();
        }

        private string[] AllInterests = new string[]
            {
                "Cats", "Dogs", "Fish", "Monkeys", "Horses",
                "Baseball", "Football", "Soccer", "Hockey", "Basketball",
                "Sewing", "Scrapbooking", "Stamp collecting", "Crochia", "Gaming",
                "Running", "Biking", "Swimming", "Yoga", "Hiking",
                "Drawing", "Sculpture", "Photography", "Music", "Theater"
            };

        private string GenerateRandomInterests(Random rand)
        {
            const int MaxInterests = 5;

            var numInterests = rand.Next(0, MaxInterests);
            var interests = new HashSet<string>();
            while (interests.Count < numInterests)
            {
                interests.Add(AllInterests[rand.Next(0, AllInterests.Length)]); // won't add if already present
            }

            return string.Join(", ", interests);
        }

        private string GenerateRandomImageURL(Random rand)
        {
            var url = "https://randomuser.me/api/portraits/";
            url += (rand.Next(0, 2) == 0) ? "men/" : "women/";
            url += rand.Next(0, 100);
            url += ".jpg";
            return url;
        }
    }
}