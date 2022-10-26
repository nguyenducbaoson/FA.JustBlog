using FA.JustBlog.Entities.Models;
using FA.JustBlog.ViewModel.Login;
using FA.JustBlog.ViewModel.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Responsitory.IResponsitory
{
    public interface IUserResponsitory
    {
        bool IsUniqueUser(string username);
        Task<LoginResponse> Login(LoginRequest request);
        Task<LocalUser> Register(RegisterationRequest registerationRequest);
    }
}
