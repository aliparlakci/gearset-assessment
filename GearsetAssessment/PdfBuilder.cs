using System;
using System.Collections.Generic;
using System.Text;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace GearsetAssessment
{
    class PdfBuilder : IDisposable
    {
        private readonly PdfWriter writer;
        private readonly PdfDocument pdfDocument;
        private readonly Document document;

        private PdfFont font;

        public PdfBuilder(string destination)
        {
            writer = new PdfWriter(destination);
            pdfDocument = new PdfDocument(writer);
            document = new Document(pdfDocument);
        }

        public PdfBuilder Write(string text)
        {
            Paragraph content = new Paragraph(text);
            content.SetFont(font);

            document.Add(content);

            return this;
        }

        public PdfBuilder Regular()
        {
            font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            return this;
        }

        public PdfBuilder Italic()
        {
            font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);

            return this;
        }

        public PdfBuilder Bold()
        {
            font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            return this;
        }

        public void Dispose()
        {
            document.Close();
        }
    }
}
