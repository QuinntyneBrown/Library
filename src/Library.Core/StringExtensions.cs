using static System.Linq.Enumerable;


namespace System;

public static class StringExtensions
{
    public static string Indent(this string value, int indent)
    {
        string[] values = value.Split(Environment.NewLine);

        return string.Join(Environment.NewLine, values.Select(v => string.IsNullOrEmpty(v) ? v : $"{string.Join("", Range(1, 4 * indent).Select(i => ' '))}{v}"));
    }

}
