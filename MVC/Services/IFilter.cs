using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MVC.Services
{
    public interface IFilter<T> where T : class
    {
        
        
        public Expression<Func<T, Object>> OrderBy {  get; set; }

        public string SortBy {  get; set; }

        public int Limit { get; set; }

        public int Skip { get; set; }

        public Expression<Func<T, bool>> Where { get; set; }

        public List<Expression<Func<T, Object>>> Include { get; set; }

        public IQueryable<T> GetFilter(IQueryable<T> query);
    }
}
