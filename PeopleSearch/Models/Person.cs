using System.ComponentModel.DataAnnotations;

namespace PeopleSearch.Models
{
    public class Person
    {
        public int PersonID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public string Interests { get; set; }

        [Display(Name = "Image")]
        public string ImageURL { get; set; }
    }
}