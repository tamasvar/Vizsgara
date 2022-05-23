using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace WebApi2.Models
{
    public partial class Versenyszamok
    {
        public int VersenyszamId { get; set; }
        public string VersenyszamFajta { get; set; }
        public int VersenyzoId { get; set; }

        [JsonIgnore]
        public virtual Versenyzo Versenyzo { get; set; }
    }
}
