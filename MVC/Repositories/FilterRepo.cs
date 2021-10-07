using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Services;

namespace MVC.Repositories
{
    public class FilterRepo<T> : IFilter<T> where T : BaseModel
    {

        public FilterRepo()
        {
            
        }
        
        public FilterRepo(int limit, int skip, string sortBy)
        {
            Limit = limit;
            Skip = skip;
            SortBy = sortBy;
        }
        public Expression<Func<T, object>> OrderBy { get; set; }
        
        public string SortBy { get; set; }
        public int Limit { get; set; }
        public int Skip { get; set; }
        public Expression<Func<T, bool>> Where { get; set; }
        public List<Expression<Func<T, object>>> Include { get; set; } = new List<Expression<Func<T, object>>>();
        
        
        public IQueryable<T> GetFilter(IQueryable<T> query)
        {
            var q = query;
            if (OrderBy is not null)
            {
                if (SortBy is "ASC")
                {
                    q = q.OrderBy(OrderBy);
                }
                else
                {
                    q = q.OrderByDescending(OrderBy);
                }
            }
            
            if (Limit != 0)
            {
                q = q.Take(Limit);
            }
            else
            {
                q = q.Take(10);
            }
            
            if (Skip is not 0)
            {
                q = q.Skip(Skip);
            }
            
            if (Where is not null)
            {
                q = q.Where(Where);
            }

            if (Include.Count > 0)
            {
                foreach (var ine in Include)
                {
                    q = q.Include(ine);
                }
            }

            return q;
        }
    }
}