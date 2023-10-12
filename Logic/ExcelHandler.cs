using FileTransformationTest.Models;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace FileTransformationTest.Logic
{
    class ExcelHandler
    {
        private IWorkbook _workbook;

        public ExcelHandler(string filePath)
        {
            _workbook = WorkbookFactory.Create(filePath);
        }

        public IEnumerable<Parameters> GetParams(string range)
        {
            var sheet = _workbook.GetSheetAt(0);
            var cellRange = CellRangeAddress.ValueOf(range);
            var parametersList = new List<Parameters>();
            for (var i = cellRange.FirstRow; i <= cellRange.LastRow; i++)
            {
                var row = sheet.GetRow(i);
                var parameters = new Parameters();
                parameters.Field = row.GetCell(0 + cellRange.MinColumn).StringCellValue.Trim().Replace(" ", String.Empty);
                parameters.Start = Convert.ToInt32(row.GetCell(1 + cellRange.MinColumn).NumericCellValue);
                parameters.Length = Convert.ToInt32(row.GetCell(2 + cellRange.MinColumn).NumericCellValue);
                parametersList.Add(parameters);
            }
            return parametersList;
        }
        public IEnumerable<CurrencyRules> GetCurrencyRules(string range)
        {
            var sheet = _workbook.GetSheetAt(0);
            var cellRange = CellRangeAddress.ValueOf(range);
            var currencyRulesList = new List<CurrencyRules>();
            for (var i = cellRange.FirstRow; i <= cellRange.LastRow; i++)
            {
                var row = sheet.GetRow(i);
                var currencyRules = new CurrencyRules();
                currencyRules.Account = row.GetCell(0 + cellRange.MinColumn).NumericCellValue.ToString();
                currencyRules.CurrencyId = row.GetCell(2 + cellRange.MinColumn).StringCellValue.Trim();
                currencyRulesList.Add(currencyRules);
            }
            return currencyRulesList;
        }


    }
}
