using System.Text.RegularExpressions;
using ShineData.Shine.Files;

namespace ShineSuite.Module.Skill.Helper;

public partial class DescriptionVariableHelper
{
    public static string ReplaceVariables(string input, ActiveSkillEntry activeSkillEntry,
        ActiveSkillInfoServerEntry activeSkillInfoServerEntry, ActiveSkillViewEntry activeSkillViewEntry)
    {
        var regex = VariableRegex();
        var matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            var placeholder = match.Groups[1].Value;
            var replacement = string.Empty;

            switch (placeholder)
            {
                case "minDamage":
                    replacement = activeSkillEntry.MinimumDamage.ToString();
                    break;
                case "maxDamage":
                    replacement = activeSkillEntry.MaximumDamage.ToString();
                    break;
                case "minMagicDamage":
                    replacement = activeSkillEntry.MinimumMagicDamage.ToString();
                    break;
                case "maxMagicDamage":
                    replacement = activeSkillEntry.MaximumMagicDamage.ToString();
                    break;
                case "targetCount":
                    replacement = activeSkillEntry.TargetCount.ToString();
                    break;
                default:
                    replacement = match.Value;
                    break;
            }
            
            input = input.Replace(match.Value, replacement);
        }

        return input;
    }

    [GeneratedRegex("{(\\w+)}")]
    private static partial Regex VariableRegex();
}