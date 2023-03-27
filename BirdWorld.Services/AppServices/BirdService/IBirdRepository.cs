using BirdWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Services.AppServices.BirdService
{
    public interface IBirdRepository
    {
        public List<Bird>? GetAllBirds();
        
        public Bird? GetBird(int id);
        public Bird? GetBirdByName(String name);
        public List<Bird>? SearchBirdByName(String name);

        public bool CreatBird(Bird bird);
        public bool DeleteBird(int id);
        public bool UpdateBird(Bird bird);
    }
}
