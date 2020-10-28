using System;
using System.Collections.Generic;
using System.Text;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace GearsetAssessment
{
    class PdfBuilder : IDisposable
    {
        private readonly PdfWriter writer;
        private readonly PdfDocument pdfDocument;
        public Document document { get; }
        private PdfFont font;
        private TextAlignment alignment;
        private readonly float INDENT_SIZE;
        private int indentLevel = 0;
        private float fontSize;

        public PdfBuilder(string destination)
        {
            writer = new PdfWriter(destination);
            pdfDocument = new PdfDocument(writer);
            document = new Document(pdfDocument);

            INDENT_SIZE = 48f;
            alignment = TextAlignment.LEFT;
            font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
        }

        public void Write(string text)
        {
            Paragraph content = new Paragraph();

            content
                .SetMarginLeft(INDENT_SIZE * indentLevel)
                .SetTextAlignment(alignment)
                .SetFont(font)
                .Add(new Text(text));

            document.Add(content);
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

        public PdfBuilder Justify()
        {
            alignment = TextAlignment.JUSTIFIED;

            return this;
        }

        public PdfBuilder Left()
        {
            alignment = TextAlignment.LEFT;

            return this;
        }

        public PdfBuilder Right()
        {
            alignment = TextAlignment.RIGHT;

            return this;
        }

        public PdfBuilder Indent(int level)
        {
            indentLevel += level;

            return this;
        }

        public void Dispose()
        {
            document.Close();
        }
    }
}
