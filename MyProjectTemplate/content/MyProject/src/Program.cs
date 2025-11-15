namespace MyProject;

using System;
using CommandLine;

public static class Program
{
    private static readonly string s_dashes = new string('=', 64);

    private static readonly string s_usage = $@"
    carlos_diaz | @dfirence
    {s_dashes}
    Usage:
      myproject [options]

    Options:
      --help         Show this help message
    ";

    private static void ShowHelp()
    {
        Console.WriteLine(s_usage);
        Environment.Exit(0);
    }

    public class Options
    {
        // Define CLI options
        [Option("help", HelpText = "Display help information.")]
        public bool Help { get; set; }
    }

    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            ShowHelp();
        }

        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(opts =>
            {
                if (opts.Help)
                {
                    ShowHelp();
                }
                else
                {
                    Console.WriteLine("No name provided. Use --help for usage.");
                }
            })
            .WithNotParsed(_ =>
            {
                ShowHelp();
            });
    }
}
