using System;
using System.ComponentModel.DataAnnotations;

namespace EVRental.BlazorWebApp.QuanNH.Models
{
    public class CheckOutQuanNhViewModel
    {
        public int CheckOutQuanNhid { get; set; }

        [Required(ErrorMessage = "Check out time is required")]
        [DataType(DataType.DateTime)]
        public DateTime? CheckOutTime { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? ReturnDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Extra cost must be a positive number")]
        public decimal? ExtraCost { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Total cost must be a positive number")]
        public decimal? TotalCost { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Late fee must be a positive number")]
        public decimal? LateFee { get; set; }

        public bool IsPaid { get; set; }

        public bool IsDamageReported { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string? Notes { get; set; }

        [StringLength(1000, ErrorMessage = "Customer feedback cannot exceed 1000 characters")]
        public string? CustomerFeedback { get; set; }

        [Required(ErrorMessage = "Payment method is required")]
        [StringLength(100, ErrorMessage = "Payment method cannot exceed 100 characters")]
        public string? PaymentMethod { get; set; }

        [Required(ErrorMessage = "Staff signature is required")]
        [StringLength(200, ErrorMessage = "Staff signature cannot exceed 200 characters")]
        [MinLength(2, ErrorMessage = "Staff signature must be at least 2 characters")]
        public string? StaffSignature { get; set; }

        [Required(ErrorMessage = "Customer signature is required")]
        [StringLength(200, ErrorMessage = "Customer signature cannot exceed 200 characters")]
        [MinLength(2, ErrorMessage = "Customer signature must be at least 2 characters")]
        public string? CustomerSignature { get; set; }

        public int? ReturnConditionId { get; set; }

        // Helper method to convert to CheckOutQuanNh
        public CheckOutQuanNh ToCheckOutQuanNh()
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

        // Helper method to create from CheckOutQuanNh
        public static CheckOutQuanNhViewModel FromCheckOutQuanNh(CheckOutQuanNh entity)
        {
            return new CheckOutQuanNhViewModel
            {
                CheckOutQuanNhid = entity.CheckOutQuanNhid,
                CheckOutTime = entity.CheckOutTime,
                ReturnDate = entity.ReturnDate,
                ExtraCost = entity.ExtraCost,
                TotalCost = entity.TotalCost,
                LateFee = entity.LateFee,
                IsPaid = entity.IsPaid,
                IsDamageReported = entity.IsDamageReported,
                Notes = entity.Notes,
                CustomerFeedback = entity.CustomerFeedback,
                PaymentMethod = entity.PaymentMethod,
                StaffSignature = entity.StaffSignature,
                CustomerSignature = entity.CustomerSignature,
                ReturnConditionId = entity.ReturnConditionId
            };
        }
    }
}
