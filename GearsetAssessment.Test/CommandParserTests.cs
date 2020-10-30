using Moq;
using Xunit;

namespace GearsetAssessment.Test
{
    public class CommandParserTests
    {
        public Mock<IPdfBuilder> MockedBuilder;

        public CommandParserTests()
        {
            MockedBuilder = new Mock<IPdfBuilder>();
        }
        
        [Fact]
        public void Paragraph()
        {
            CommandParser.ExtractMethod(".paragraph", MockedBuilder.Object)();
            MockedBuilder.Verify(mock => mock.Paragraph(), Times.Once());
        }

        [Fact]
        public void Normal()
        {
            CommandParser.ExtractMethod(".normal", MockedBuilder.Object)();
            MockedBuilder.Verify(mock => mock.Normal(), Times.Once());
        }


        [Fact]
        public void Large()
        {
            CommandParser.ExtractMethod(".large", MockedBuilder.Object)();
            MockedBuilder.Verify(mock => mock.Large(), Times.Once());
        }


        [Fact]
        public void Regular()
        {
            CommandParser.ExtractMethod(".regular", MockedBuilder.Object)();
            MockedBuilder.Verify(mock => mock.Regular(), Times.Once());
        }
                
        [Fact]
        public void Bold()
        {
            CommandParser.ExtractMethod(".bold", MockedBuilder.Object)();
            MockedBuilder.Verify(mock => mock.Bold(), Times.Once());
        }


        [Fact]
        public void Italic()
        {
            CommandParser.ExtractMethod(".italic", MockedBuilder.Object)();
            MockedBuilder.Verify(mock => mock.Italic(), Times.Once());
        }

        [Fact]
        public void Fill()
        {
            CommandParser.ExtractMethod(".fill", MockedBuilder.Object)();
            MockedBuilder.Verify(mock => mock.Justify(), Times.Once());
        }

        [Fact]
        public void NoFill()
        {
            CommandParser.ExtractMethod(".nofill", MockedBuilder.Object)();
            MockedBuilder.Verify(mock => mock.Left(), Times.Once());
        }


        [Fact]
        public void Indent()
        {
            CommandParser.ExtractMethod(".indent 2", MockedBuilder.Object)();
            MockedBuilder.Verify(mock => mock.Indent(2f), Times.Once());
        }

        [Fact]
        public void Text()
        {
            CommandParser.ExtractMethod("test string", MockedBuilder.Object)();
            MockedBuilder.Verify(mock => mock.AddText("test string"), Times.Once());
        }

        [Fact]
        public void ShouldThrowErrorIfCommandNotRecognized()
        {
            Assert.Throws<CommandNotFoundException>(() =>
            {
                CommandParser.ExtractMethod(".thiscommand does not exist", MockedBuilder.Object)();
            });
        }
    }
}
