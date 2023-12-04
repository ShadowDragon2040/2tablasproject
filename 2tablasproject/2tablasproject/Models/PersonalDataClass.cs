namespace _2tablasproject.Models
{
    public class PersonalDataClass
    {
        public PersonalDataClass()
        {
            CardClasses = new HashSet<CardClass>();
        }

        public int PersonalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public int CardIndexId { get; set; }

        public virtual ICollection<CardClass> CardClasses { get; set; }
    }
}
