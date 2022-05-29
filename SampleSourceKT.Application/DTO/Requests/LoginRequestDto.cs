using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSourceKT.Application.DTO.Requests.Users
{
    public class LoginRequestDto
    {
        public string Username { get; set; }
        public string Password  { get; set; }
        public bool IsRemembered  { get; set; }
    }
}
