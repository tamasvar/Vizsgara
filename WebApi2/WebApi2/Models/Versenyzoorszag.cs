using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace WebApi2.Models
{
    public partial class Versenyzoorszag
    {
        public int OrszagId { get; set; }
        public string Orszagneve { get; set; }
        public string Orszaghelye { get; set; }
        public int VersenyzoId { get; set; }

        [JsonIgnore]
        public virtual Versenyzo Versenyzo { get; set; }
    }
}
