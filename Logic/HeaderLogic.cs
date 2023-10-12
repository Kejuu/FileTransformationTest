using FileTransformationTest.Models;
using FileTransformationTest.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransformationTest.Logic
{
    public class HeaderLogic
    {
        private ExcelHandler _excelHandler;
        private TextFileHandler _textFileHandler;
        private IConfigurationBuilder _configurationBuilder;
        private string _patchExcel;
        private string _patchText;
        public HeaderLogic()
        {
            _patchExcel = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Mapping_Anguilla.xlsx");
            _excelHandler = new ExcelHandler(_patchExcel);
            _textFileHandler = new TextFileHandler();
            _patchText = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\CHEQUE_ap.TXT");
            _configurationBuilder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
        }

        public Header GetHeader() 
        {
            var textFileRows = _textFileHandler.TextFileReader(_patchText);
            var headerParams = _excelHandler.GetParams("A4:C20");

            var header = new Header();
            var headerText = textFileRows[0];
            header.RecordType = Commons.Commons.GetHeaderValue("RecordType", headerParams, headerText);
            header.CheckNumber = Commons.Commons.GetHeaderValue("CheckNumber", headerParams, headerText);
            header.BankId = Commons.Commons.GetHeaderValue("BankId", headerParams, headerText);
            header.AccountId = Commons.Commons.GetHeaderValue("AccountId", headerParams, headerText);
            header.CheckDate = Commons.Commons.GetHeaderValue("CheckDate", headerParams, headerText);
            header.PayeeId = Commons.Commons.GetHeaderValue("PayeeId", headerParams, headerText);
            header.PayeeName1 = Commons.Commons.GetHeaderValue("PayeeName1", headerParams, headerText);
            header.PayeeName2 = Commons.Commons.GetHeaderValue("PayeeName2", headerParams, headerText);
            header.Address1 = Commons.Commons.GetHeaderValue("Address1", headerParams, headerText);
            header.Address2 = Commons.Commons.GetHeaderValue("Address2", headerParams, headerText);
            header.Address3 = Commons.Commons.GetHeaderValue("Address3", headerParams, headerText);
            header.Address4 = Commons.Commons.GetHeaderValue("Address4", headerParams, headerText);
            header.Address5 = Commons.Commons.GetHeaderValue("Address5", headerParams, headerText);
            header.CheckAmount = Commons.Commons.GetHeaderValue("CheckAmount", headerParams, headerText);
            header.PayorId = Commons.Commons.GetHeaderValue("PayorId", headerParams, headerText);
            header.AmountString = Commons.Commons.GetHeaderValue("AmountString", headerParams, headerText);
            header.TemplateId = Commons.Commons.GetHeaderValue("TemplateId", headerParams, headerText);
            var currencyRules = _excelHandler.GetCurrencyRules("B24:D27");
            var find = currencyRules.FirstOrDefault( currencyRule => currencyRule.Account == header.AccountId);
            if (find != null)
            {
                header.CurrencyId = find.CurrencyId;
            }

            var config = _configurationBuilder.Build();

            var checkPlusDbOptions = new DbContextOptionsBuilder<CheckPlusDbContext>()
                .UseSqlServer(config["ConnectionString"])
                .Options;

            using (var checkPlusDbContext = new CheckPlusDbContext(checkPlusDbOptions))
            {
                var bank = checkPlusDbContext.Banks.Find(header.BankId);
                header.BankName = bank.Bank_Name;
                header.Address1 = bank.Address_1;
                header.Address2 = bank.Address_2;

            }
            return header;
        }
    }
}
