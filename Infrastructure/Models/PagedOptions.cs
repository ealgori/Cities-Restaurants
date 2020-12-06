using System;

namespace Infrastructure.Models
{
    public class PagedOptions
    {
        private const int MAX_PAGE_SIZE = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = MAX_PAGE_SIZE;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = Math.Min(MAX_PAGE_SIZE, value);
        }



    }
}