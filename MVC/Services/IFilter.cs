using MVC.Models;
using System;
using System.Linq.Expressions;

namespace MVC.Services
{
    public interface IFilter<T> where T : class
    {
        public Expression<Func<T, Object>> OrderBy {  get; set; }

        public Expression<Func<T, Object>> SortBy {  get; set; }

        public int Limit { get; set; }

        public int Skip { get; set; }
        
    }
}
