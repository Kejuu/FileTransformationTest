using Azure;
using FileTransformationTest.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransformationTest.Models
{
    public class Details
    {
        public string? RecordType { get; set; }
        public string? CheckNumber { get; set; }
        public string? BankId { get; set; }
        public string? BankAccountNo { get; set; }
        public string? CheckDate { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? InvoiceDate { get; set; }
        public string? VoucherNumber { get; set; }
        public string? VoucherDate { get; set; }
        public string? GrossAmount { get; set; }
        public string? DiscountAmount { get; set; }
        public string? NetAmount { get; set; }
        public string? Concept { get; set; }
        public string? BenefitDescription { get; set; }

        public override string ToString()
        {
            return $"D~{InvoiceNumber}~{InvoiceDate}~{VoucherNumber}~{VoucherDate.FormatDate()}~{GrossAmount.FormatTwoDecimals()}~{DiscountAmount}~{NetAmount.FormatTwoDecimals()}~{Concept}~{BenefitDescription}";
        }
    }
}
