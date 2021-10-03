﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Services
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T> GetOne(int id);

        public Task<IEnumerable<T>> GetAllAsync(IFilter<T> filter);

        public Task<int> Save(T t);

        public void Delete(T t);
    }
}
