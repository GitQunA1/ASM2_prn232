using EVRental.Repositories.QuanNH.Basic;
using EVRental.Repositories.QuanNH.DBContext;
using EVRental.Repositories.QuanNH.ModelExtensions;
using EVRental.Repositories.QuanNH.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRental.Repositories.QuanNH
{
    public class CheckOutQuanNhRepository : GenericRepository<CheckOutQuanNh>
    {
        public CheckOutQuanNhRepository() { }

        public CheckOutQuanNhRepository(FA25_PRN232_SE1717_G6_EVRentalContext context) => _context = context;

        public async Task<List<CheckOutQuanNh>> GetAllAsync()
        {
            var items = await _context.CheckOutQuanNhs.Include(c => c.ReturnCondition).ToListAsync();

            return items ?? new List<CheckOutQuanNh>();
        }

        public async Task<CheckOutQuanNh> GetByIdAsync(int code)
        {
            var item = await _context.CheckOutQuanNhs
                .Include(c => c.ReturnCondition)
                .FirstOrDefaultAsync(c => c.CheckOutQuanNhid == code);
            return item ?? new CheckOutQuanNh();
        }

        public async Task<List<CheckOutQuanNh>> SearchAsync(string note, decimal? cost, string name)
        {
            try
            {
                var query = _context.CheckOutQuanNhs
                    .Include(c => c.ReturnCondition)
                    .AsQueryable();

                // Tìm kiếm theo note (nếu có)
                if (!string.IsNullOrWhiteSpace(note))
                {
                    query = query.Where(c => c.Notes != null && c.Notes.Contains(note));
                }

                // Tìm kiếm theo cost (nếu có)
                if (cost.HasValue && cost.Value > 0)
                {
                    query = query.Where(c => c.TotalCost.HasValue && c.TotalCost.Value == cost.Value);
                }

                // Tìm kiếm theo name của ReturnCondition (nếu có)
                if (!string.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(c => 
                        c.ReturnCondition != null && 
                        c.ReturnCondition.Name != null && 
                        c.ReturnCondition.Name.Contains(name)
                    );
                }

                var items = await query
                    .OrderByDescending(c => c.CheckOutTime)
                    .ToListAsync();

                return items ?? new List<CheckOutQuanNh>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchAsync: {ex.Message}");
                return new List<CheckOutQuanNh>();
            }
        }

        public async Task<PaginationResult<List<CheckOutQuanNh>>> SearchWithPagingAsync(CheckOutQuanNhSearchRequest searchRequest)
        {
            // Đảm bảo có giá trị mặc định cho pagination
            int currentPage = searchRequest.CurrentPage ?? 1;
            int pageSize = searchRequest.PageSize ?? 10;

            var items = await this.SearchAsync(searchRequest.note, searchRequest.cost, searchRequest.name);

            var totalItems = items.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Đảm bảo currentPage hợp lệ
            if (currentPage < 1) currentPage = 1;
            if (currentPage > totalPages && totalPages > 0) currentPage = totalPages;

            items = items.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            var result = new PaginationResult<List<CheckOutQuanNh>>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = currentPage,
                PageSize = pageSize,
                Items = items
            };

            return result ?? new PaginationResult<List<CheckOutQuanNh>>();
        }
    }
}
