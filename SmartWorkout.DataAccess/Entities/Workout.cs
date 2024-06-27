using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Entities
{
    public class Workout
    {
        public int Id { get; set; }
        public int User_Id { get; set; } 
        public int? Duration { get; set; }
        public DateTime Date { get; set; }
        public Users User { get; set; } = null!;
    }

}
