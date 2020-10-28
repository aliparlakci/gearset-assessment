using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
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
        private Paragraph currentParagraph;
        private PdfFont font;
        private TextAlignment alignment;
        private readonly float INDENT_SIZE;
        private readonly float FONT_SIZE_MULTIPLIER;
        private float fontSize;
        private float indentation;

        public PdfBuilder(FileStream destination)
        {
            currentParagraph = new Paragraph();

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

        public PdfBuilder Paragraph()
        {
            // Write the latest paragraph to document
            // create a new paragraph
            WriteParagraphToDocument();

            currentParagraph = new Paragraph();

            return this;
        }

        public void AddText(string text)
        {
            Text content = new Text(text);
            content
                .SetTextAlignment(alignment)
                .SetFont(font)
                .SetFontSize(fontSize);

            currentParagraph.Add(content);
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
            // Alignment is defined for per paragraph.
            // If alignment is changed, we need to go onto a new paragraph
            Paragraph();

            alignment = TextAlignment.JUSTIFIED;

            return this;
        }

        public PdfBuilder Left()
        {
            // Alignment is defined for per paragraph.
            // If alignment is changed, we need to go onto a new paragraph
            Paragraph();

            alignment = TextAlignment.LEFT;

            return this;
        }

        public PdfBuilder Right()
        {
            // Alignment is defined for per paragraph.
            // If alignment is changed, we need to go onto a new paragraph
            Paragraph();

            alignment = TextAlignment.RIGHT;

            return this;
        }

        public PdfBuilder Indent(int level)
        {

            // Indentation is defined for per paragraph.
            // If indentation is changed, we need to go onto a new paragraph
            Paragraph();

            indentation += INDENT_SIZE * level;

            return this;
        }

        private void WriteParagraphToDocument()
        {
            currentParagraph
                .SetMarginLeft(indentation)
                .SetTextAlignment(alignment);

            if (!currentParagraph.IsEmpty())
            {
                document.Add(currentParagraph);
            }
        }

        public void Dispose()
        {
            WriteParagraphToDocument();
            document.Close();
        }
    }
}
