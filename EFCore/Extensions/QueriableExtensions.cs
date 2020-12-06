using System;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Extensions
{
    public static class QueriableExtensions
    {
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, PagedOptions options) where T:BaseEntity
        {
            var pageNumber = options.PageNumber;
            var pageSize = options.PageSize;
            int count = source.Count();
            var items = await source.OrderBy(i=>i.Id).Skip((pageNumber- 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        public static async Task<PagedList<U>> ToPagedListAsync<T, U>(this IQueryable<T> source, Func<T, U> selector,
            PagedOptions options) where T:BaseEntity
        {
            var pl = await source.ToPagedListAsync<T>(options);
            return new PagedList<U>(pl.Select(selector).ToList(), pl.TotalCount, pl.CurrentPage, pl.PageSize);
        }
    }
}