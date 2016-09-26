using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetB.Models.DTO
{
    [JsonObject]
    public class LoginDTO
    {
        [JsonProperty]
        [Required]
        public string Email { get; set; }
        [JsonProperty]
        [Required]
        public string Senha { get; set; }

    }
}
