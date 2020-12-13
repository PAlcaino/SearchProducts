namespace ProductsSearch.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Pagination List items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T>: List<T>
    {
        /// <summary>
        /// Page Metadata properties
        /// </summary>
        public PageMetadata PageMetadata { get; set; }

        /// <summary>
        /// Paged List constructor with parameters
        /// </summary>
        /// <param name="items"></param>
        /// <param name="count"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PageMetadata = new PageMetadata
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            AddRange(items);
        }
        /// <summary>
        /// Converts a list of items into paged list
        /// </summary>
        /// <param name="source">The source items to convert</param>
        /// <param name="pageNumber">The page number that belongs this items</param>
        /// <param name="pageSize">the page size</param>
        /// <returns>a paged list</returns>
        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
