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

        public async Task<PaginationResult<List<CheckOutQuanNh>>> SearchWithPaginationAsync(CheckOutQuanNhSearchRequestInput request)
        {
            var searchRequest = new CheckOutQuanNhSearchRequest
            {
                CurrentPage = request.CurrentPage ?? 1,
                PageSize = request.PageSize ?? 10,
                note = request.Note,
                cost = request.Cost,
                name = request.Name
            };

            return await _serviceProviders.ICheckOutQuanNhService.SearchWithPaginationAsync(searchRequest);
        }

        public async Task<PaginationResult<List<CheckOutQuanNh>>> GetCheckOutQuanNhsWithPagination(int currentPage = 1, int pageSize = 10)
        {
            var request = new CheckOutQuanNhSearchRequest
            {
                CurrentPage = currentPage > 0 ? currentPage : 1,
                PageSize = pageSize > 0 ? pageSize : 10,
                note = null,
                cost = null,
                name = null
            };
            return await _serviceProviders.ICheckOutQuanNhService.SearchWithPaginationAsync(request);
        }

        public async Task<SystemUserAccount> Login(string userName, string password)
        {
            return await _serviceProviders.SystemUserAccountService.GetUserAccount(userName, password);
        }
    }
}
