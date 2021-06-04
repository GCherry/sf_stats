using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_stats.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Grade { get; set; }
    }
}
