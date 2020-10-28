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
        private readonly float FONT_SIZE_MULTIPLIER;
        private float fontSize;
        private float indentation;

        public PdfBuilder(string destination)
        {

            FONT_SIZE_MULTIPLIER = 12;
            fontSize = 1;

            INDENT_SIZE = 48;
            indentation = 0;

            alignment = TextAlignment.LEFT;
            font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            writer = new PdfWriter(destination);
            pdfDocument = new PdfDocument(writer);
            document = new Document(pdfDocument);
        }

        public void Write(string text)
        {
            Paragraph content = new Paragraph();

            content
                .SetMarginLeft(indentation)
                .SetTextAlignment(alignment)
                .SetFont(font)
                .SetFontSize(fontSize)
                .Add(new Text(text));

            document.Add(content);
        }

        public PdfBuilder Normal()
        {
            fontSize = FONT_SIZE_MULTIPLIER * 1;

            return this;
        }

        public PdfBuilder Large()
        {
            fontSize = FONT_SIZE_MULTIPLIER * 2;

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
            indentation += INDENT_SIZE * level;

            return this;
        }

        public void Dispose()
        {
            document.Close();
        }
    }
}
