using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using tablasproject.Models;

namespace tablasproject.Models;

public partial class Cardclass
{
    public int CardId { get; set; }

    public int CardNumber { get; set; }

    public string CardTypeName { get; set; } = null!;

    public string CurrencyName { get; set; } = null!;

    public int CurrencyAmmount { get; set; }

    [JsonIgnore]
    public virtual ICollection<Personaldata> Personaldata { get; set; } = new List<Personaldata>();
}
