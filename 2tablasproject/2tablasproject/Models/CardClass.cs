using System.Text.Json.Serialization;

namespace _2tablasproject.Models
{
    public class CardClass
    {
        public int CardId { get; set; }
        public int CardNumber { get; set; }
        public string CardTypeName { get; set; }
        public string CurrencyName { get; set; }
        public int CurrencyAmmount { get; set; }

        [JsonIgnore]
        public virtual PersonalDataClass CardIndexId { get; set; } = null!;
    }
}
