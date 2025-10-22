using System.Text;
using System.Text.RegularExpressions;

namespace TTC.Mod.Utils;

public static partial class Jsonc
{
    private static readonly Regex MultiLineComment = new(@"/\*.*?\*/", RegexOptions.Singleline | RegexOptions.Compiled);
    private static readonly Regex SingleLineComment = new(@"//.*?$", RegexOptions.Multiline | RegexOptions.Compiled);
    private static readonly Regex TrailingCommas = new(@",(\s*[}\]])", RegexOptions.Compiled);

    public static string Strip(string jsonc)
    {
        if (string.IsNullOrWhiteSpace(jsonc)) return "{}";
        // Remove comments
        var noComments = MultiLineComment.Replace(jsonc, string.Empty);
        noComments = SingleLineComment.Replace(noComments, string.Empty);
        // Remove trailing commas before } or ]
        var noTrailing = TrailingCommas.Replace(noComments, "$1");
        return noTrailing;
    }
}
