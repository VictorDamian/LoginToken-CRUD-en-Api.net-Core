using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore.Models.ObjectValues
{
    public class UserResponse
    {
        public string username { get; set; }
        public string token { get; set; }
    }
}
