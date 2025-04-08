using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HuffmanLib
{
    public class HuffmanNode
    {
        public char? Symbol { get; set; }
        public int Frequency { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }

        public bool IsLeaf => Symbol.HasValue;
    }
    public class HuffmanTree
    {
        public HuffmanNode Root { get; private set; }
        public Dictionary<char, string> Codes { get; private set; }

        public HuffmanTree(Dictionary<char, int> frequencies)
        {
            BuildTree(frequencies);
            Codes = new Dictionary<char, string>();
            BuildCodes(Root, "");
        }

        private void BuildTree(Dictionary<char, int> frequencies)
        {
            List<HuffmanNode> nodes = frequencies
                .Select(pair => new HuffmanNode { Symbol = pair.Key, Frequency = pair.Value })
                .ToList();

            while (nodes.Count > 1)
            {
                var ordered = nodes.OrderBy(n => n.Frequency).ToList();
                HuffmanNode left = ordered[0];
                HuffmanNode right = ordered[1];

                HuffmanNode parent = new HuffmanNode
                {
                    Frequency = left.Frequency + right.Frequency,
                    Left = left,
                    Right = right
                };

                nodes.Remove(left);
                nodes.Remove(right);
                nodes.Add(parent);
            }

            Root = nodes[0];
        }

        private void BuildCodes(HuffmanNode node, string code)
        {
            if (node == null)
                return;

            if (node.Symbol.HasValue)
                Codes[node.Symbol.Value] = code;

            BuildCodes(node.Left, code + "0");
            BuildCodes(node.Right, code + "1");
        }
    }
    public class HuffmanEncoder
    {
        public Dictionary<char, int> FrequencyTable { get; private set; }
        public HuffmanTree Tree { get; private set; }
        public string EncodedText { get; private set; }

        public void AnalyzeText(string text)
        {
            FrequencyTable = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (FrequencyTable.ContainsKey(c))
                    FrequencyTable[c]++;
                else
                    FrequencyTable[c] = 1;
            }

            Tree = new HuffmanTree(FrequencyTable);
        }

        public void EncodeText(string text)
        {
            if (Tree == null || Tree.Codes == null)
                throw new InvalidOperationException("Сначала вызовите AnalyzeText");

            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                sb.Append(Tree.Codes[c]);
            }

            EncodedText = sb.ToString();
        }

        public void SaveReport(string filePath)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Таблица Хаффмана:");
            sb.AppendLine("Символ\tЧастота\tКод");

            foreach (var pair in FrequencyTable)
            {
                string symbol = GetDisplayChar(pair.Key);
                sb.AppendLine($"{symbol}\t{pair.Value}\t{Tree.Codes[pair.Key]}");
            }

            sb.AppendLine();
            sb.AppendLine("Длина закодированного текста: " + EncodedText.Length + " бит");
            sb.AppendLine();
            sb.AppendLine("Закодированный текст:");
            sb.AppendLine(EncodedText);

            File.WriteAllText(filePath, sb.ToString());
        }

        private string GetDisplayChar(char c)
        {
            if (c == ' ') return "[пробел]";
            if (c == '\n') return "[\\n]";
            if (c == '\r') return "[\\r]";
            if (c == '\t') return "[\\t]";
            return c.ToString();
        }
    }
}
