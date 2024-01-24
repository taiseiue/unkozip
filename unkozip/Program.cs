using CommandLine;
using CommandLine.Text;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace unkozip
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var options = Parser.Default.ParseArguments<Options>(args);
                options.WithNotParsed(_ =>
                {
                    var helpText = HelpText.AutoBuild(options);
                    Console.WriteLine($"引数を認識できませんでした: {helpText}");
                    Environment.Exit(255);
                });

                string source = options.Value.Source;
                string output = string.IsNullOrEmpty(options.Value.Output) ? Directory.GetCurrentDirectory() : options.Value.Output;
                Encoding encoding = string.IsNullOrEmpty(options.Value.CodeName)
                    ? Encoding.GetEncoding(options.Value.CodePoint)
                    : Encoding.GetEncoding(options.Value.CodeName);

                Console.WriteLine("Zipファイルを解凍しています...");
                ZipFile.ExtractToDirectory(source, output, encoding);
                Console.WriteLine("成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"失敗:{ex.Message}");
                Environment.Exit(255);
            }
        }
    }
}
