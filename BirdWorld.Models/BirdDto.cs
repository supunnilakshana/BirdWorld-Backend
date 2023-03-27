
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWorld.Models
{
    public class BirdDto
    {
        public int Id { get; set; }
        public string ScienceName { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public string Deit { get; set; }
        public string Group { get; set; }
        public double  Weight { get; set; }
        public double Height { get; set; }
        public int AvgLife { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Edited { get; set; } = DateTime.Now;
        public ICollection<string> Images { get; set; } = new List<string>();






    }
}
