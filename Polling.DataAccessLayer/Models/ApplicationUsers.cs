using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.DataAccessLayer.Models
{
    public class ApplicationUsers : IdentityUser
    {
        public string UserName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
    }
}
