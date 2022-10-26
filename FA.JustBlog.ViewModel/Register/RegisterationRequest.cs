using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModel.Register
{
    public class RegisterationRequest
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
    }
}
