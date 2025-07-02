using woolly_friends.Models.DTOs.General;

namespace woolly_friends.Services.Interfaces.General
{
    public interface IPaginationService
    {
        Task<PaginatedResult<T>> GetPaginatedAsync<T>(IQueryable<T> query, int pageNumber, int pageSize);
    }
}