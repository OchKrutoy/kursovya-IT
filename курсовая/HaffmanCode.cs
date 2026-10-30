using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace курсовая
{
    internal class HaffmanCode
    {
        public Node Root { get; private set; }
        public Dictionary<char, string> Codes { get; private set; }

        public Dictionary<char, int> CountFrequencies(string text)
        {
            var freq = new Dictionary<char, int>();
            foreach (char c in text)
            {
                if (freq.ContainsKey(c))
                    freq[c]++;
                else
                    freq[c] = 1;
            }
            return freq;
        }

        public void BuildTree(Dictionary<char, int> frequencies)
        {
            var nodes = new List<Node>();
            foreach (var kv in frequencies)
                nodes.Add(new Node(kv.Key, kv.Value));

            if (nodes.Count == 1)
            {
                nodes.Add(new Node('\0', 0));
            }

            while (nodes.Count > 1)
            {
                nodes.Sort((a, b) => a.Frequency.CompareTo(b.Frequency));

                var left = nodes[0];
                var right = nodes[1];
                nodes.RemoveRange(0, 2);
                nodes.Add(new Node(left, right));
            }

            Root = nodes[0];
            Codes = new Dictionary<char, string>();
            BuildCodes(Root, "", Codes);
        }

        private void BuildCodes(Node node, string code, Dictionary<char, string> codes)
        {
            if (node.IsLeaf)
            {
                codes[node.Symbol] = code.Length == 0 ? "0" : code;
                return;
            }
            BuildCodes(node.Left, code + "0", codes);
            BuildCodes(node.Right, code + "1", codes);
        }

        public string Encode(string text)
        {
            var sb = new StringBuilder();
            foreach (char c in text)
            {
                if (Codes.ContainsKey(c))
                    sb.Append(Codes[c]);
            }
            return sb.ToString(); 
        }

        public string Decode(string bits)
        {
            var sb = new StringBuilder();
            Node current = Root;
            foreach (char bit in bits)
            {
                current = (bit == '0') ? current.Left : current.Right;
                if (current.IsLeaf)
                {
                    sb.Append(current.Symbol);
                    current = Root;
                }
            }
            return sb.ToString();
        }

        public int GetEncodedSizeBits(Dictionary<char, int> frequencies)
        {
            int total = 0;
            foreach (var kv in frequencies)
            {
                if (Codes.ContainsKey(kv.Key))
                    total += kv.Value * Codes[kv.Key].Length;
            }
            return total;
        }

        public List<FA> BuildTable(Dictionary<char, int> frequencies)
        {
            var list = new List<FA>();
            foreach (var kv in frequencies)
            {
                list.Add(new FA
                {
                    Symbol = kv.Key,
                    Frequency = kv.Value,
                    Code = Codes.ContainsKey(kv.Key) ? Codes[kv.Key] : ""
                });
            }
            return list;
        }

        public void SaveToBinaryFile(string bitsString, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(bitsString.Length);

                byte currentByte = 0;
                int bitCount = 0;

                foreach (char bit in bitsString)
                {
                    currentByte = (byte)(currentByte << 1);
                    if (bit == '1')
                        currentByte = (byte)(currentByte | 1);

                    bitCount++;

                    if (bitCount == 8) 
                    {
                        writer.Write(currentByte);
                        currentByte = 0;
                        bitCount = 0;
                    }
                }
                if (bitCount > 0)
                {
                    currentByte = (byte)(currentByte << (8 - bitCount));
                    writer.Write(currentByte);
                }
            }
        }

        public string LoadFromBinaryFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                int totalBits = reader.ReadInt32();
                StringBuilder sb = new StringBuilder();

                while (sb.Length < totalBits)
                {
                    byte b = reader.ReadByte();
                    for (int i = 7; i >= 0; i--)
                    {
                        if (sb.Length >= totalBits) break; 

                        if ((b & (1 << i)) != 0)
                            sb.Append('1');
                        else
                            sb.Append('0');
                    }
                }
                return sb.ToString();
            }
        }
    }
}