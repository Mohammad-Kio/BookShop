﻿using System;
using MVC.Data;
using MVC.Models;
using MVC.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC.Repositories
{
    public class BaseRepo<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly AddDbContext _db;

        public BaseRepo(AddDbContext db)
        {
            this._db = db;
        }
        

        public void Delete(T t)
        {
            _db.Set<T>().Remove(t);
        }

        public async Task<IEnumerable<T>> GetAllAsync(IFilter<T> filter)
        {
            var data = await _db.Set<T>()
                .OrderBy(x => filter.OrderBy)
                .Skip(filter.Skip)
                .Take(filter.Limit).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetOne(int id)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Save(T t)
        {
            await _db.AddAsync(t);
            return await _db.SaveChangesAsync();
        }
    }
}