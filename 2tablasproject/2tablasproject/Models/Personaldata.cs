using tablasproject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tablasproject.Models;

public partial class Personaldata
{
    public int PersonalId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Language { get; set; } = null!;

    public int CardIndexId { get; set; }

    [JsonIgnore]
    public virtual Cardclass CardIndex { get; set; } = null!;
}
