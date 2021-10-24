using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JwtApiAuth.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
