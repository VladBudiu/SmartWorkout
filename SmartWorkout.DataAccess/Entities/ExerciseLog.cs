using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Entities
{
    public class ExerciseLog
    {
        public int WorkoutId;
        public int ExerciseId;
        public double Weight;
        public int Sets;
        public int Reps;
        public double Duration;
        public double Distance;

        public Exercise Exercise;
        public Workout Workout;

    }
}
