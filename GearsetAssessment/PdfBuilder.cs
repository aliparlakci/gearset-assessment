using System;
using System.IO;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace GearsetAssessment
{
    public class PdfBuilder : IDisposable
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

        public PdfBuilder(Stream destination)
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

        public PdfBuilder Paragraph()
        {
            // Do not try to add paragraph to document
            // if no paragraph has been created, yet
            if (currentParagraph != null)
            {
                // Add the previous paragraph to document
                WriteParagraphToDocument();
            }

            currentParagraph = new Paragraph();

            return this;
        }

        public PdfBuilder AddText(string text)
        {
            Text content = new Text(text);
            content
                .SetFont(font)
                .SetFontSize(fontSize);

            // If Paragraph() has not been called for at least once
            // create a new Paragraph
            if (currentParagraph == null)
            {
                currentParagraph = new Paragraph();
            }
            currentParagraph.Add(content);
            return this;
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

            alignment = TextAlignment.JUSTIFIED;

            return this;
        }

        public PdfBuilder Left()
        {
            // Alignment is defined for per paragraph.
            // If alignment is changed, we need to go onto a new paragraph

            alignment = TextAlignment.LEFT;

            return this;
        }

        public PdfBuilder Right()
        {
            // Alignment is defined for per paragraph.
            // If alignment is changed, we need to go onto a new paragraph

            alignment = TextAlignment.RIGHT;

            return this;
        }

        public PdfBuilder Indent(float level)
        {
            // Indentation is defined for per paragraph.
            // If indentation is changed, we need to go onto a new paragraph
            Paragraph();

            indentation += INDENT_SIZE * level;
            currentParagraph.SetMarginLeft(indentation);

            return this;
        }

        public Paragraph GetParagraph()
        {
            ApplyStylingToParagraph();
            return currentParagraph;
        }

        private void WriteParagraphToDocument()
        {
            ApplyStylingToParagraph();
            document.Add(currentParagraph);
        }

        private void ApplyStylingToParagraph()
        {
            currentParagraph
                .SetMarginLeft(indentation)
                .SetTextAlignment(alignment);
        }

        public void Dispose()
        {
            WriteParagraphToDocument();
            document.Close();
        }
    }
}
