using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransformationTest.Models
{
    public class Header
    {
        public string? RecordType { get; set; }
        public string? CheckNumber { get; set; }
        public string? BankId { get; set; }
        public string? AccountId { get; set; }
        public string? CheckDate { get; set; }
        public string? PayeeId { get; set; }
        public string? PayeeName1 { get; set; }
        public string? PayeeName2 { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Address4 { get; set; }
        public string? Address5 { get; set; }
        public string? CheckAmount { get; set; }
        public string? PayorId { get; set; }
        public string? AmountString { get; set; }
        public string? TemplateId { get; set; }
    }
}
