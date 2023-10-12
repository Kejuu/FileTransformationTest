using FileTransformationTest.Logic;
using FileTransformationTest.Models;

var textFileHandler = new TextFileHandler();
var patchTextFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\CHEQUE_ap.TXT");
var textFileRows = textFileHandler.TextFileReader(patchTextFile);

var patchExcel = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Mapping_Anguilla.xlsx");
var excelHandler = new ExcelHandler(patchExcel);
var headerParams = excelHandler.GetParams("A4:C20");

var header = new Header();
var headerText = textFileRows[0];
header.RecordType = GetHeaderValue("RecordType", headerParams, headerText);
header.CheckNumber = GetHeaderValue("CheckNumber", headerParams, headerText);
header.BankId = GetHeaderValue("BankId", headerParams, headerText);
header.AccountId = GetHeaderValue("AccountId", headerParams, headerText);
header.CheckDate = GetHeaderValue("CheckDate", headerParams, headerText);
header.PayeeId = GetHeaderValue("PayeeId", headerParams, headerText);
header.PayeeName1 = GetHeaderValue("PayeeName1", headerParams, headerText);
header.PayeeName2 = GetHeaderValue("PayeeName2", headerParams, headerText);
header.Address1 = GetHeaderValue("Address1", headerParams, headerText);
header.Address2 = GetHeaderValue("Address2", headerParams, headerText);
header.Address3 = GetHeaderValue("Address3", headerParams, headerText);
header.Address4 = GetHeaderValue("Address4", headerParams, headerText);
header.Address5 = GetHeaderValue("Address5", headerParams, headerText);
header.CheckAmount = GetHeaderValue("CheckAmount", headerParams, headerText);
header.PayorId = GetHeaderValue("PayorId", headerParams, headerText);
header.AmountString = GetHeaderValue("AmountString", headerParams, headerText);
header.TemplateId = GetHeaderValue("TemplateId", headerParams, headerText);

var detailsParams = excelHandler.GetParams("E4:G17");
var details = new Details();
var detailsText = textFileRows[1];
details.RecordType = GetHeaderValue("RecordType", detailsParams, detailsText);
details.CheckNumber = GetHeaderValue("CheckNumber", detailsParams, detailsText);
details.BankId = GetHeaderValue("BankId", detailsParams, detailsText);
details.BankAccountNo = GetHeaderValue("BankAccountNo", detailsParams, detailsText);
details.CheckDate = GetHeaderValue("CheckDate", detailsParams, detailsText);
details.InvoiceNumber = GetHeaderValue("InvoiceNumber", detailsParams, detailsText);
details.InvoiceDate = GetHeaderValue("InvoiceDate", detailsParams, detailsText);
details.VoucherNumber = GetHeaderValue("VoucherNumber", detailsParams, detailsText);
details.VoucherDate = GetHeaderValue("VoucherDate", detailsParams, detailsText);
details.GrossAmount = GetHeaderValue("GrossAmount", detailsParams, detailsText);
details.DiscountAmount = GetHeaderValue("DiscountAmount", detailsParams, detailsText);
details.NetAmount = GetHeaderValue("NetAmount", detailsParams, detailsText);
details.Concept = GetHeaderValue("Concept", detailsParams, detailsText);
details.BenefitDescription = GetHeaderValue("BenefitDescription", detailsParams, detailsText);


string GetHeaderValue(string field, IEnumerable<Parameters> parameters, string row)
{
    var param = parameters.FirstOrDefault(parameter => parameter.Field.ToLower() == field.ToLower());
    if (param == null) {  return ""; }
    if (param.Start + param.Length > row.Length) { return row.Substring(param.Start).Trim(); }
    return row.Substring(param.Start, param.Length).Trim();
}
Console.WriteLine();
