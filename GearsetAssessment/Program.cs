using System;
using System.IO;

namespace GearsetAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath;
            try
            {
                inputPath = args[0];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidArgumentException("Path to an input file is not provided");
            }
            string outputPath = "output.pdf";

            using FileStream inputFileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new StreamReader(inputFileStream);

            using FileStream outputFileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            using IPdfBuilder pdfBuilder = new PdfBuilder(outputFileStream);

            string line = String.Empty;
            while ((line = streamReader.ReadLine()) != null)
            {
                CommandParser.ExtractMethod(line, pdfBuilder)();
            }
        }
    }
}
