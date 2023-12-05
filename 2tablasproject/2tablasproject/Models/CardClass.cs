using System;
using System.Collections.Generic;

namespace tablasproject.Models;

public partial class Cardclass
{
    public int CardId { get; set; }

    public int CardNumber { get; set; }

    public string CardTypeName { get; set; } = null!;

    public string CurrencyName { get; set; } = null!;

    public int CurrencyAmmount { get; set; }
}
