using System;
using System.Collections.Generic;
using System.Linq;

namespace BurgerApp.Api
{
	public static class PagingExtensions
	{
		public static IQueryable<TType> GetPaged<TType>(this IQueryable<TType> queryable, int pageCount, int pageSize, out int totalPageCount)
		{
			pageCount = (pageCount > 0) ? pageCount : 1;
			totalPageCount = (int)Math.Ceiling((double)queryable.Count() / pageSize);
			return queryable.Skip((pageCount - 1) * pageSize).Take(pageSize);
		}

		public static IEnumerable<TType> GetPaged<TType>(this IEnumerable<TType> queryable, int pageCount, int pageSize, out int totalPageCount)
		{
			pageCount = (pageCount > 0) ? pageCount : 1;
			totalPageCount = (int)Math.Ceiling((double)queryable.Count() / pageSize);
			return queryable.Skip((pageCount - 1) * pageSize).Take(pageSize);
		}

		public static PagedResult<T> GetPagedResult<T>(this List<T> list, int pageCount, int pageSize, int totalPages)
			=> new PagedResult<T>()
			{
				CurrentPage = pageCount,
				PageSize = pageSize,
				TotalPages = totalPages,
				Elements = list
			};
	}
}
