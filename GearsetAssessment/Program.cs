using System;
using System.IO;

namespace GearsetAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "output.pdf";
            string inputPath = args[0];

            using FileStream inputFileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new StreamReader(inputFileStream);

            using FileStream outputFileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            using PdfBuilder pdfBuilder = new PdfBuilder(outputFileStream);

            string line = String.Empty;
            while ((line = streamReader.ReadLine()) != null)
            {
                CommandParser.ExtractMethod(line, pdfBuilder)();
            }
        }
    }
}
