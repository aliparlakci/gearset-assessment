using System;
using System.Collections.Generic;
using System.Text;
using iText.Layout.Element;

namespace GearsetAssessment
{
    public interface IPdfBuilder : IDisposable
    {
        public IPdfBuilder Paragraph();
        public IPdfBuilder AddText(string text);
        public IPdfBuilder Normal();
        public IPdfBuilder Large();
        public IPdfBuilder Regular();
        public IPdfBuilder Italic();
        public IPdfBuilder Bold();
        public IPdfBuilder Justify();
        public IPdfBuilder Left();
        public IPdfBuilder Right();
        public IPdfBuilder Indent(float level);
        public Paragraph GetParagraph();
    }
}
