using Microsoft.EntityFrameworkCore;
using woolly_friends.Models.DTOs.General;
using woolly_friends.Services.Interfaces.General;

namespace woolly_friends.Services.Implementations.General
{
    public class PaginationService : IPaginationService
    {
        public async Task<PaginatedResult<T>> GetPaginatedAsync<T>(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var totalCount = await query.CountAsync();

            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
