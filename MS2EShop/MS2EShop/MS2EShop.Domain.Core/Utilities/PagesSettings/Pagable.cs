using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MS2EShop.Domain.Core.Utilities.PagesSettings
{
    public class Pagable
    {
        /// <summary>
        /// صفحه
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// تعداد در هر صفحه
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// جستجو
        /// </summary>
        [StringLength(100, MinimumLength = 2, ErrorMessage = "مقدار جستجو باید بین 2 تا 100 کارکاتر باشد")]
        public string Search { get; set; } = null;
    }

    public class Pagination
    {
        public Pagination() { }

        public Pagination(int page, int pageSize, int count)
        {
            Total = count;
            Current = page;
            Per_page = pageSize;
            From = GetFrom(page, pageSize);
            To = GetTo(page, pageSize);
            Links = GetPageLinks(pageSize);
            HasPrev = page != 1;
            HasNext = GetNextValue(pageSize, count, page);
        }

        public Pagination(Pagable pagable, int count)
        {
            int page = pagable.Page;
            int pageSize = pagable.PageSize;

            Total = count;
            Current = page;
            Per_page = pageSize;
            From = GetFrom(page, pageSize);
            To = GetTo(page, pageSize);
            Links = GetPageLinks(pageSize);
            HasPrev = page != 1;
            HasNext = GetNextValue(pageSize, count, page);
        }

        public bool HasPrev { get; set; }
        public List<PageLink> Links { get; set; }
        public int Current { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public bool HasNext { get; set; }

        int GetFrom(int page, int pageSize)
        {
            return ((page - 1) * pageSize) + 1;
        }

        int GetTo(int page, int pageSize)
        {
            int count = page * pageSize;

            if (count < Total)
            {
                return count;
            }
            else
            {
                return Total;
            }
        }

        bool GetNextValue(int pageSize, int count, int page)
        {
            double lastPage = Math.Ceiling((double)count / (double)pageSize);

            return page < lastPage;
        }

        List<PageLink> GetPageLinks(int pageSize)
        {
            List<PageLink> result = new();

            double count = Math.Ceiling((double)Total / (double)pageSize);

            if ((int)count == 0)
            {
                result.Add(new() { Id = 1, Label = "1", Active = true });
            }
            else
            {
                for (int i = 1; i <= count; i++)
                {
                    PageLink pageLink = new();

                    if (i == Current) pageLink.Active = true;

                    pageLink.Id = i;
                    pageLink.Label = i.ToString();

                    result.Add(pageLink);
                }
            }

            return result;
        }


    }

    public class PageLink
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public bool Active { get; set; } = false;
    }

    public static class PagableExtension
    {
        public static IQueryable<T> ToPaged<T>(this IQueryable<T> query, int page, int pageSize)
        {
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IQueryable<T> ToPaged<T>(this IQueryable<T> query, Pagable pagable)
        {
            return query.Skip((pagable.Page - 1) * pagable.PageSize).Take(pagable.PageSize);
        }
    }
}
