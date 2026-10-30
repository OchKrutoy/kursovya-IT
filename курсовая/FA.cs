using System;
using System.Collections.Generic;
using System.Text;

namespace курсовая
{
    internal class FA
    {
        public char Symbol { get; set; }
        public int Frequency { get; set; }
        public string Code { get; set; }
        public int CodeLength => Code?.Length ?? 0;
    }
}
