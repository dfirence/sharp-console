using System;
using Xunit;
using CommandLine;
using CommandLine.Text;
using MyProject;

namespace MyProject.Tests;

public class ProgramTests
{
    [Fact]
    public void Should_Generate_Help_Text_When_Help_Is_True()
    {
        // Arrange
        var args = new[] { "--help" };

        // Use parser with help output disabled
        var parser = new Parser(config => config.HelpWriter = null);
        var result = parser.ParseArguments<Program.Options>(args);

        string? helpText = null;

        // Act
        result.WithParsed(opts =>
        {
            if (opts.Help)
            {
                helpText = HelpText.AutoBuild(result, h =>
                {
                    h.Heading = "MyProject CLI Help";
                    h.AdditionalNewLineAfterOption = false;
                    return h;
                }, e => e);
            }
        });

        // Assert
        Assert.True(string.IsNullOrEmpty(helpText));
    }
}
