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

        var texts = new string[2];
        texts[0] = header.ToString();
        texts[1] = details.ToString();

        var textFileHandler = new TextFileHandler();
        textFileHandler.TextFileWriter(texts);
    }
}