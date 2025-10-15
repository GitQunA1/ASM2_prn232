using EVRental.Repositories.QuanNH.Models;
using EVRental.Services.QuanNH;

namespace EVRental.GraphQLWebAPI.QuanNH.GraphQLs
{
    public class Mutations
    {
        private readonly IServiceProviders _serviceProviders;
        public Mutations(IServiceProviders serviceProviders) => _serviceProviders = serviceProviders;

        public async Task<int> CreateCheckOutQuanNhAsync(CheckOutQuanNh entity)
        {
            return await _serviceProviders.ICheckOutQuanNhService.CreateAsync(entity);
        }

        public async Task<int> UpdateCheckOutQuanNhAsync(CheckOutQuanNh entity)
        {
            return await _serviceProviders.ICheckOutQuanNhService.UpdateAsync(entity);
        }

        public async Task<bool> DeleteCheckOutQuanNhAsync(int id)
        {
            return await _serviceProviders.ICheckOutQuanNhService.DeleteAsync(id);
        }
    }
}
