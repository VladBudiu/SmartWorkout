using Microsoft.EntityFrameworkCore;
using SmartWorkout.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DataAccess.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private DbContext context;
        private DbSet<T> set;
        public GenericRepository(SmartWorkoutContext context)
        {
            this.context = context;
            set = context.Set<T>();
        }

        public async Task AddAsync(T t)
        {
           await set.AddAsync(t);
        }
        public async Task DeleteByIdAsync(int id)
        {
            var user = set.FindAsync(id);
            set.Remove(await user);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            return set.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await set.FindAsync(id);
        }

        public Task UpdateAsync(T t)
        {
            throw new NotImplementedException();
        }
    }
}
