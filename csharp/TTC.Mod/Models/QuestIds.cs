using System.Security.Cryptography;
using System.Text;

namespace TTC.Mod.Models;

/// <summary>
/// Deterministic ID generation for Kolya trader, quests, conditions, and rewards.
/// IDs are stable across builds for save compatibility.
/// </summary>
public static class QuestIds
{
    public const string KolyaTraderId = "a1b2c3d4e5f6a7b8c9d0e1f2";

    public static string QuestId(string seed) =>
        HashToMongoId(seed);

    public static string QuestId(string theme, int tier) =>
        HashToMongoId($"ttc_quest_{theme}_t{tier}");

    public static string ConditionId(string questSeed, int index) =>
        HashToMongoId($"{questSeed}_cond_{index}");

    public static string RewardId(string questSeed, int index) =>
        HashToMongoId($"{questSeed}_reward_{index}");

    public static string StartConditionId(string questSeed, int index) =>
        HashToMongoId($"{questSeed}_start_{index}");

    public static string AssortItemId(string theme, string kind) =>
        HashToMongoId($"ttc_assort_{theme}_{kind}");

    public static string CrateTemplateId(string barterSeed) =>
        HashToMongoId($"ttc_crate_{barterSeed}");

    private static string HashToMongoId(string input)
    {
        var hash = MD5.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(hash)[..24].ToLowerInvariant();
    }
}
