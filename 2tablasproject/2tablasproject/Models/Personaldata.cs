using System;
using System.Collections.Generic;

namespace tablasproject.Models;

public partial class Personaldata
{
    public int PersonalId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Language { get; set; } = null!;

    public int CardIndexId { get; set; }
}
