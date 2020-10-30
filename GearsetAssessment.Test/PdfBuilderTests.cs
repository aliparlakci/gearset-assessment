using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.Layout.Properties;

namespace GearsetAssessment.Test
{
    public class PdfBuilderTests : IDisposable
    {
        public MemoryStream stream;
        public PdfBuilder builder;
        public PdfBuilderTests()
        {
            stream = new MemoryStream();
            builder = new PdfBuilder(stream);
        }

        public void Dispose()
        {
            builder.Dispose();
            stream.Dispose();
        }

        [Fact]
        public void AddText()
        {
            string testString = "Ali";

            builder.AddText(testString);

            Paragraph paragraph = builder.GetParagraph();
            Text textContent = (Text)paragraph.GetChildren()[0];

            Assert.Equal(testString, textContent.GetText());
        }

        [Fact]
        public void Bold()
        {
            string testString = "Ali";

            builder.Bold().AddText(testString);

            Paragraph paragraph = builder.GetParagraph();
            Text textContent = (Text)paragraph.GetChildren()[0];

            PdfType1Font font = textContent.GetProperty<PdfType1Font>(20);

            Assert.Equal("Helvetica-Bold", font.GetFontProgram().GetFontNames().ToString());
        }

        [Fact]
        public void Italic()
        {
            string testString = "Ali";

            builder.Italic().AddText(testString);

            Paragraph paragraph = builder.GetParagraph();
            Text textContent = (Text)paragraph.GetChildren()[0];

            PdfType1Font font = textContent.GetProperty<PdfType1Font>(20);

            Assert.Equal("Helvetica-Oblique", font.GetFontProgram().GetFontNames().ToString());
        }

        [Fact]
        public void Regular()
        {
            string testString = "Ali";

            builder.Regular().AddText(testString);

            Paragraph paragraph = builder.GetParagraph();
            Text textContent = (Text)paragraph.GetChildren()[0];

            PdfType1Font font = textContent.GetProperty<PdfType1Font>(20);

            Assert.Equal("Helvetica", font.GetFontProgram().GetFontNames().ToString());
        }

        [Fact]
        public void Normal()
        {
            string testString = "Ali";

            builder.Normal().AddText(testString);

            Paragraph paragraph = builder.GetParagraph();
            Text textContent = (Text)paragraph.GetChildren()[0];

            UnitValue fontSize = textContent.GetProperty<UnitValue>(24);

            Assert.Equal(12f, fontSize.GetValue());
        }

        [Fact]
        public void Large()
        {
            string testString = "Ali";

            builder.Large().AddText(testString);

            Paragraph paragraph = builder.GetParagraph();
            Text textContent = (Text)paragraph.GetChildren()[0];

            UnitValue fontSize = textContent.GetProperty<UnitValue>(24);

            Assert.Equal(24f, fontSize.GetValue());
        }

        [Fact]
        public void Left()
        {
            string testString = "Ali";

            builder.Left().AddText(testString);

            Paragraph paragraph = builder.GetParagraph();

            TextAlignment alignment = paragraph.GetProperty<TextAlignment>(70);

            Assert.Equal(TextAlignment.LEFT, alignment);
        }

        [Fact]
        public void Right()
        {
            string testString = "Ali";

            builder.Right().AddText(testString);

            Paragraph paragraph = builder.GetParagraph();

            TextAlignment alignment = paragraph.GetProperty<TextAlignment>(70);

            Assert.Equal(TextAlignment.RIGHT, alignment);
        }

        [Fact]
        public void Justify()
        {
            string testString = "Ali";

            builder.Justify().AddText(testString);

            Paragraph paragraph = builder.GetParagraph();

            TextAlignment alignment = paragraph.GetProperty<TextAlignment>(70);

            Assert.Equal(TextAlignment.JUSTIFIED, alignment);
        }

        [Fact]
        public void Indent()
        {
            string testString = "Ali";
            UnitValue indent;
            Paragraph paragraph;

            builder.Indent(2).AddText(testString);
            paragraph = builder.GetParagraph();
            indent = paragraph.GetProperty<UnitValue>(44);
            Assert.Equal(2*48f, indent.GetValue());

            builder.Indent(-2).AddText(testString);
            paragraph = builder.GetParagraph();
            indent = paragraph.GetProperty<UnitValue>(44);
            Assert.Equal(0, indent.GetValue());
        }
    }
}
