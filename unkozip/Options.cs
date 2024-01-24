using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unkozip
{
    internal class Options
    {
        [Value(0,MetaName ="Zipファイル名")]
        public string Source { get; set; }
        [Option('o',"out", Required =false, HelpText ="解凍先ディレクトリ")]
        public string Output { get; set; }
        [Option("mcp",Required =false,Default =65001,HelpText ="解凍に使用する文字コードのコードポイント(数値)")]
        public int CodePoint { get; set; }

        [Option('c',"code", Required = false, HelpText = "解凍に使用する文字コードの名前")]
        public string CodeName { get; set; }
    }
}
