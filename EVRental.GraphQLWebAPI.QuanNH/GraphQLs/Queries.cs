using EVRental.Repositories.QuanNH.ModelExtensions;
using EVRental.Repositories.QuanNH.Models;
using EVRental.Services.QuanNH;

namespace EVRental.GraphQLWebAPI.QuanNH.GraphQLs
{
    public class Queries
    {
        private readonly IServiceProviders _serviceProviders;

        public Queries(IServiceProviders serviceProviders) => _serviceProviders = serviceProviders;

        public async Task<List<CheckOutQuanNh>> GetCheckOutQuanNhsAsync()
        {
            return await _serviceProviders.ICheckOutQuanNhService.GetAllAsync();
        }

        public async Task<List<ReturnCondition>> GetReturnConditions()
        {
            return await _serviceProviders.ReturnConditionService.GetAllAsync();
        }

        public async Task<CheckOutQuanNh> GetCheckOutQuanNh(int id)
        {
            return await _serviceProviders.ICheckOutQuanNhService.GetByIdAsync(id);
        }

        public async Task<PaginationResult<List<CheckOutQuanNh>>> SearchWithPaginationAsync(CheckOutQuanNhSearchRequest request)
        {
            return await _serviceProviders.ICheckOutQuanNhService.SearchWithPaginationAsync(request);
        }

        public async Task<PaginationResult<List<CheckOutQuanNh>>> GetCheckOutQuanNhsWithPagination(int currentPage, int pageSize)
        {
            var request = new CheckOutQuanNhSearchRequest
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                note = null,
                cost = null,
                name = null
            };
            return await _serviceProviders.ICheckOutQuanNhService.SearchWithPaginationAsync(request);
        }
    }
}
