using System;
using System.IO;
using System.Text;

namespace GearsetAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            string dest = "C:\\Users\\Ali\\Desktop\\pdf.pdf";
            string inputPath = "C:\\Users\\Ali\\Desktop\\input.txt";

            using FileStream inputFileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new StreamReader(inputFileStream);

            using FileStream outputFileStream = new FileStream(dest, FileMode.Create, FileAccess.Write);

            string line = String.Empty;

            using PdfBuilder pdfBuilder = new PdfBuilder(outputFileStream);

            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.StartsWith(".paragraph"))
                {
                    pdfBuilder.Paragraph();
                }
                if (line.StartsWith(".normal"))
                {
                    pdfBuilder.Normal();
                }
                if (line.StartsWith(".large"))
                {
                    pdfBuilder.Large();
                }
                if (line.StartsWith(".regular"))
                {
                    pdfBuilder.Regular();
                }
                if (line.StartsWith(".bold"))
                {
                    pdfBuilder.Bold();
                }
                if (line.StartsWith(".italic"))
                {
                    pdfBuilder.Italic();
                }
                if (line.StartsWith(".fill"))
                {
                    pdfBuilder.Justify();
                }
                if (line.StartsWith(".nofill"))
                {
                    pdfBuilder.Left();
                }
                if (line.StartsWith(".indent"))
                {
                    var indent = line.Split(" ")[1];
                    pdfBuilder.Indent(Int32.Parse(indent));
                }
                if (!line.StartsWith("."))
                {
                    pdfBuilder.AddText(line);
                }
            }

        }
    }
}
