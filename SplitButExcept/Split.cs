using System.Collections.Generic;

namespace SplitButExcept
{
    public class Split
    {
        public Split(char delimiter, char except, string input)
        {
            _delimiter = delimiter;
            _except = except;
            _input = input;
        }

        private readonly char _delimiter;
        private readonly char _except;
        private readonly string _input;

        public string[] Result()
        {
            var parts = _input.Split(',');
            var result = new List<string>();
            var groupPart = new List<string>();
            foreach (var part in parts)
            {
                if (ExceptStart(part))
                {
                    groupPart.Add(TrimExcept(part));
                    continue;
                }
                if (ExceptEnd(part))
                {
                    groupPart.Add(TrimExcept(part));
                    result.Add(string.Join(_delimiter.ToString(), groupPart));
                    continue;
                }
                result.Add(part);
            }
            return result.ToArray();
        }

        private bool ExceptStart(string str) => str.StartsWith(_except.ToString());
        private bool ExceptEnd(string str) => str.EndsWith(_except.ToString());

        private string TrimExcept(string input)
        {
            if (ExceptStart(input)) return input.TrimStart(_except);
            if (ExceptEnd(input)) return input.TrimEnd(_except);
            return input;
        }
    }
}
