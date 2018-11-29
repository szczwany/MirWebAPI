using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ConsoleApp1
{
    public class Content
    {
        private readonly Dictionary<string, string> _values;

        public Content(string a, string d1, string d2, string d3, string d4, string s, string t, string p, string f = "undefined")
        {
            _values = new Dictionary<string, string>
            {
                { "a", a },
                { "d1", d1 },
                { "d2", d2 },
                { "d3", d3 },
                { "d4", d4 },
                { "s", s },
                { "t", t },
                { "p", p },
                { "f", f }
            };
        }

        public FormUrlEncodedContent GetContent()
        {
            return new FormUrlEncodedContent(_values);
        }
    }
}
