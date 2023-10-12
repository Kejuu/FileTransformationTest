using FileTransformationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransformationTest.Logic
{
    public class DetailsLogic
    {
        private ExcelHandler _excelHandler;
        private TextFileHandler _textFileHandler;
        private string _patchExcel;
        private string _patchText;
        public DetailsLogic()
        {
            _patchExcel = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Mapping_Anguilla.xlsx");
            _excelHandler = new ExcelHandler(_patchExcel);
            _textFileHandler = new TextFileHandler();
            _patchText = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\CHEQUE_ap.TXT");
        }

        public Details GetDetails()
        {
            var textFileRows = _textFileHandler.TextFileReader(_patchText);
            var detailsParams = _excelHandler.GetParams("E4:G17");
            var details = new Details();
            var detailsText = textFileRows[1];
            details.RecordType = Commons.Commons.GetHeaderValue("RecordType", detailsParams, detailsText);
            details.CheckNumber = Commons.Commons.GetHeaderValue("CheckNumber", detailsParams, detailsText);
            details.BankId = Commons.Commons.GetHeaderValue("BankId", detailsParams, detailsText);
            details.BankAccountNo = Commons.Commons.GetHeaderValue("BankAccountNo", detailsParams, detailsText);
            details.CheckDate = Commons.Commons.GetHeaderValue("CheckDate", detailsParams, detailsText);
            details.InvoiceNumber = Commons.Commons.GetHeaderValue("InvoiceNumber", detailsParams, detailsText);
            details.InvoiceDate = Commons.Commons.GetHeaderValue("InvoiceDate", detailsParams, detailsText);
            details.VoucherNumber = Commons.Commons.GetHeaderValue("VoucherNumber", detailsParams, detailsText);
            details.VoucherDate = Commons.Commons.GetHeaderValue("VoucherDate", detailsParams, detailsText);
            details.GrossAmount = Commons.Commons.GetHeaderValue("GrossAmount", detailsParams, detailsText);
            details.DiscountAmount = Commons.Commons.GetHeaderValue("DiscountAmount", detailsParams, detailsText);
            details.NetAmount = Commons.Commons.GetHeaderValue("NetAmount", detailsParams, detailsText);
            details.Concept = Commons.Commons.GetHeaderValue("Concept", detailsParams, detailsText);
            details.BenefitDescription = Commons.Commons.GetHeaderValue("BenefitDescription", detailsParams, detailsText);
            return details;
        }
    }
}
