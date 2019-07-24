using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageAllCars { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageAllCars, int pageSize)
        {
            PageAllCars = pageAllCars;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageAllCars > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageAllCars < TotalPages);
            }
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageAllCars, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageAllCars - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageAllCars, pageSize);
        }
    }
}
