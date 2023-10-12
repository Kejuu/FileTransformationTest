using FileTransformationTest.Logic;
using FileTransformationTest.Models;
using FileTransformationTest.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var detailsLogic = new DetailsLogic();
        var details = detailsLogic.GetDetails();
        var headerLogic = new HeaderLogic();
        var header = headerLogic.GetHeader();

        var builder = new ConfigurationBuilder()
                        .AddJsonFile($"appsettings.json", true, true);

        var config = builder.Build();

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

        var texts = new string[2];
        texts[0] = header.ToString();
        texts[1] = details.ToString();

        var textFileHandler = new TextFileHandler();
        textFileHandler.TextFileWriter(texts);
    }
}