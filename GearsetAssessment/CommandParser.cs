using System;

namespace GearsetAssessment
{
    static class CommandParser
    {
        public static Func<PdfBuilder> ExtractMethod(string command, PdfBuilder builder)
        {
            if (command.StartsWith(".paragraph"))
            {
                return builder.Paragraph;
            }
            if (command.StartsWith(".normal"))
            {
                return builder.Normal;
            }
            if (command.StartsWith(".large"))
            {
                return builder.Large;
            }
            if (command.StartsWith(".regular"))
            {
                return builder.Regular;
            }
            if (command.StartsWith(".bold"))
            {
                return builder.Bold;
            }
            if (command.StartsWith(".italic"))
            {
                return builder.Italic;
            }
            if (command.StartsWith(".fill"))
            {
                return builder.Justify;
            }
            if (command.StartsWith(".nofill"))
            {
                return builder.Left;
            }
            if (command.StartsWith(".indent"))
            {
                var indent = command.Split(" ")[1];
                return () => builder.Indent(Int32.Parse(indent));
            }
            if (!command.StartsWith("."))
            {
                return () => builder.AddText(command);
            }
            throw new CommandNotFoundException($"{command} is not found in the commands lists");
        }
    }
}