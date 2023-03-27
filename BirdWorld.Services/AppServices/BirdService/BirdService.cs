using BirdWorld.DataAcess;
using BirdWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Services.AppServices.BirdService
{
    public class BirdService :IBirdRepository
    {
        private readonly AppDbContext dbContext;

        public BirdService()
        {
            this.dbContext = new AppDbContext();
        }

        public bool CreatBird(Bird bird)
        {
            try
            {
                dbContext.Birds.Add(bird);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public bool DeleteBird(int id)
        {
            try
            {
                dbContext.Remove(new Bird { Id = id });
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public List<Bird>? GetAllBirds()
        {
            try
            {
                var list = dbContext.Birds.ToList();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return null;
            }
        }

        public Bird? GetBird(int id)
        {
            try
            {
                var bird = dbContext.Birds.FirstOrDefault(c => c.Id.Equals(id));
                return bird;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return null;
            }
        }

        public Bird? GetBirdByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Bird>? SearchBirdByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBird(Bird bird)
        {
            try
            {
                var res = dbContext.Birds
                    .Update(bird);
                Console.WriteLine(res);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }
    }
}
