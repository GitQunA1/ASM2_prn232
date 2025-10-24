using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EVRental.BlazorWebApp.QuanNH.Models;

public partial class CheckOutQuanNh
{
    [Key]
    public int CheckOutQuanNhid { get; set; }

    public DateTime? CheckOutTime { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public decimal? ExtraCost { get; set; }

    public decimal? TotalCost { get; set; }

    public decimal? LateFee { get; set; }

    public bool IsPaid { get; set; }

    public bool IsDamageReported { get; set; }

    public string Notes { get; set; }

    public string CustomerFeedback { get; set; }

    public string PaymentMethod { get; set; }

    public string StaffSignature { get; set; }

    public string CustomerSignature { get; set; }

    public int? ReturnConditionId { get; set; }

    public virtual ReturnCondition ReturnCondition { get; set; }
}

public partial class CheckOutQuanNhsGraphQLResponse
{
    public List<CheckOutQuanNh> checkOutQuanNhs { get; set; }
}

public partial class CheckOutQuanNhGraphQLResponse
{
    public CheckOutQuanNh checkOutQuanNh { get; set; }
}

public partial class CreateCheckOutQuanNhGraphQLResponse
{
    public int createCheckOutQuanNh { get; set; }
}

public partial class UpdateCheckOutQuanNhGraphQLResponse
{
    public int updateCheckOutQuanNh { get; set; }
}

public partial class DeleteCheckOutQuanNhGraphQLResponse
{
    public bool deleteCheckOutQuanNh { get; set; }
}

public partial class PaginationResult<T>
{
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public T Items { get; set; }
}

public partial class CheckOutQuanNhPaginationGraphQLResponse
{
    public PaginationResult<List<CheckOutQuanNh>> getCheckOutQuanNhsWithPagination { get; set; }
}

public partial class SearchWithPaginationGraphQLResponse
{
    public PaginationResult<List<CheckOutQuanNh>> searchWithPagination { get; set; }
}