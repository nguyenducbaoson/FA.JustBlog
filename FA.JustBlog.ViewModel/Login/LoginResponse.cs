using FA.JustBlog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModel.Login
{
    public class LoginResponse
    {
        public LocalUser User { get; set; } 
        public string Token { get; set; }
    }
}
