namespace TTC.Mod.Models;

/// <summary>
/// Defines a single quest with its objectives, rewards, and locale text.
/// Used as input to QuestFactory.BuildFromDefinition().
/// </summary>
public record QuestDefinition
{
    /// <summary>Deterministic seed for ID generation (e.g. "ttc_quest_card_bosses_partisan").</summary>
    public required string Seed { get; init; }

    /// <summary>Seed of the prerequisite quest, or null if none.</summary>
    public string? PrerequisiteSeed { get; init; }

    /// <summary>QuestsExtended objectives (CounterCreator conditions). Empty = no objectives (instant complete).</summary>
    public List<QeObjective> Objectives { get; init; } = new();

    /// <summary>HandoverItem condition: list of card template IDs to hand over. Null = no handover.</summary>
    public HandoverObjective? Handover { get; init; }

    /// <summary>Quest locale strings.</summary>
    public required QuestLocale Locale { get; init; }

    /// <summary>Item rewards on completion.</summary>
    public List<ItemRewardDef> ItemRewards { get; init; } = new();

    /// <summary>XP reward.</summary>
    public int XpReward { get; init; }

    /// <summary>Rouble reward.</summary>
    public int RoubleReward { get; init; }

    /// <summary>Standing reward with Kolya.</summary>
    public double StandingReward { get; init; }

    /// <summary>Barter unlocked at Kolya on quest completion: trade a card for useful items.</summary>
    public BarterUnlock? BarterUnlock { get; init; }
}

/// <summary>
/// A quest objective — either QuestsExtended (tracked by QE plugin) or vanilla (tracked by SPT natively).
/// When KillTarget is set, creates a real vanilla CounterCreator condition.
/// Otherwise, creates a QE-style impossible condition intercepted by the QE plugin.
/// </summary>
public record QeObjective
{
    /// <summary>QE condition type (e.g. "KillsWhileADS", "DamageWithAR") or "Kills" for vanilla.</summary>
    public required string ConditionType { get; init; }

    /// <summary>Target value (kill count, damage amount, etc.).</summary>
    public required int Value { get; init; }

    /// <summary>Locale description shown in quest UI.</summary>
    public required string Description { get; init; }

    // ── Vanilla kill condition fields (when KillTarget is set, creates a real SPT condition) ──

    /// <summary>Enemy target type: "Savage" (scavs), "AnyPmc", "Any". When set, creates vanilla condition.</summary>
    public string? KillTarget { get; init; }

    /// <summary>Map filter: "bigmap" (Customs), "factory4_day", "interchange", "laboratory", etc.</summary>
    public List<string>? KillLocations { get; init; }

    /// <summary>Body part filter: ["Head"] for headshots.</summary>
    public List<string>? KillBodyParts { get; init; }

    /// <summary>Distance compare method: ">=" for long range, "&lt;=" for close range.</summary>
    public string? KillDistanceCompare { get; init; }

    /// <summary>Distance value in meters.</summary>
    public double? KillDistanceValue { get; init; }

    /// <summary>Whether this is a vanilla condition (true) or QE condition (false). Auto-detected from KillTarget.</summary>
    public bool IsVanilla => KillTarget != null;
}

/// <summary>
/// A HandoverItem objective requiring specific cards.
/// </summary>
public record HandoverObjective
{
    /// <summary>Card template IDs to accept.</summary>
    public required List<string> CardIds { get; init; }

    /// <summary>Number of cards required.</summary>
    public required int Count { get; init; }

    /// <summary>Whether cards must be found in raid.</summary>
    public bool FoundInRaid { get; init; } = false;

    /// <summary>Locale description.</summary>
    public required string Description { get; init; }

    /// <summary>Optional per-card display names (template ID → name). Used for individual condition locale text.</summary>
    public Dictionary<string, string>? CardNames { get; init; }
}

/// <summary>
/// All locale strings for a quest.
/// </summary>
public record QuestLocale
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required string Note { get; init; }
    public string SuccessMessage { get; init; } = "Well done, collector.";
    public string StartedMessage { get; init; } = "Get to work, friend.";
    public string AcceptMessage { get; init; } = "I'm on it.";
    public string DeclineMessage { get; init; } = "Maybe another time.";
    public string CompleteMessage { get; init; } = "Here you go, Kolya.";
}

/// <summary>
/// A barter unlocked at Kolya: trade a card for useful items.
/// </summary>
public record BarterUnlock
{
    /// <summary>Card template ID the player gives.</summary>
    public required string CardTemplateId { get; init; }

    /// <summary>Items the player receives.</summary>
    public required List<BarterRewardItem> Items { get; init; }
}

/// <summary>
/// An item received from a barter trade.
/// </summary>
public record BarterRewardItem
{
    /// <summary>SPT template ID of the item.</summary>
    public required string TemplateId { get; init; }

    /// <summary>Stack count.</summary>
    public int Count { get; init; } = 1;

    /// <summary>Optional display name override for reward crate tooltip (e.g. "Custom SVDS").</summary>
    public string? DisplayName { get; init; }

    /// <summary>Child parts (weapon mods, armor inserts, etc.) that attach to this item.</summary>
    public List<PresetPart>? Parts { get; init; }
}

/// <summary>
/// A child part that attaches to a parent item in a specific slot.
/// </summary>
public record PresetPart
{
    /// <summary>SPT template ID of the part.</summary>
    public required string TemplateId { get; init; }

    /// <summary>Slot ID on the parent item (e.g. "mod_barrel", "Soft_armor_front").</summary>
    public required string SlotId { get; init; }

    /// <summary>Nested child parts.</summary>
    public List<PresetPart>? Parts { get; init; }
}

/// <summary>
/// An item reward given on quest completion.
/// </summary>
public record ItemRewardDef
{
    /// <summary>SPT template ID of the item.</summary>
    public required string TemplateId { get; init; }

    /// <summary>Stack count.</summary>
    public int Count { get; init; } = 1;
}
