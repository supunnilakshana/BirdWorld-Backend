﻿using BirdWorld.DataAcess;
using BirdWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Services.AppServices.AppUserService
{
    public class AppUserService:IAppUserRepository
    {
        private readonly AppDbContext context;

        public AppUserService(){
            this.context =new AppDbContext();

            
        }

        public List<AppUser> GetallAppUsers()
        {
           var users= context.Users.ToList();

            return users;   
        }

        public AppUser? GetAppUser(String id)
        {
            var user = context.Users.FirstOrDefault(u=>u.Id.Equals(id));

            return user;
        }
    }
}
