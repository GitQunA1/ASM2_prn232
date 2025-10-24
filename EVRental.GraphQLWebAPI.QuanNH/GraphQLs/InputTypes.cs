using EVRental.Repositories.QuanNH.Models;

namespace EVRental.GraphQLWebAPI.QuanNH.GraphQLs
{
    public class CheckOutQuanNhInput
    {
        public int CheckOutQuanNhid { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public DateOnly? ReturnDate { get; set; }
        public decimal? ExtraCost { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? LateFee { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDamageReported { get; set; }
        public string? Notes { get; set; }
        public string? CustomerFeedback { get; set; }
        public string? PaymentMethod { get; set; }
        public string? StaffSignature { get; set; }
        public string? CustomerSignature { get; set; }
        public int? ReturnConditionId { get; set; }

        public CheckOutQuanNh ToEntity()
        {
            return new CheckOutQuanNh
            {
                CheckOutQuanNhid = this.CheckOutQuanNhid,
                CheckOutTime = this.CheckOutTime,
                ReturnDate = this.ReturnDate,
                ExtraCost = this.ExtraCost,
                TotalCost = this.TotalCost,
                LateFee = this.LateFee,
                IsPaid = this.IsPaid,
                IsDamageReported = this.IsDamageReported,
                Notes = this.Notes,
                CustomerFeedback = this.CustomerFeedback,
                PaymentMethod = this.PaymentMethod,
                StaffSignature = this.StaffSignature,
                CustomerSignature = this.CustomerSignature,
                ReturnConditionId = this.ReturnConditionId
            };
        }
    }

    public class CheckOutQuanNhSearchRequestInput
    {
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
        public string? Note { get; set; }
        public decimal? Cost { get; set; }
        public string? Name { get; set; }
    }
}
