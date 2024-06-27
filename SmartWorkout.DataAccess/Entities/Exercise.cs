using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Entities
{
    public class Exercise
    {
        public int Id;
        public string Name;

        public ICollection<ExerciseLog> ExerciseLogs { get; set; } = null!;

    }
}
