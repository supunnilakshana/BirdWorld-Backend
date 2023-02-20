using BirdWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Services.AppServices.AppUserService
{
    public interface IAppUserRepository
    {
        public List<AppUser> GetallAppUsers();
    
        public AppUser? GetAppUser(int id);
    }
}
