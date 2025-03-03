using ShineData.Shine.Files;

namespace ShineSuite.Common.Manager;

public class ShineFileManager
{
    private static readonly Lazy<ShineFileManager> _instance = new(() => new ShineFileManager());
    public static ShineFileManager Instance => _instance.Value;

    public BaseShineFile<AbStateEntry> AbState { get; set; }
    public BaseShineFile<AbstateMemoryEntry> AbstateMemory { get; set; }
    public BaseShineFile<SubAbStateEntry> SubAbState { get; set; }
    public BaseShineFile<AbStateViewEntry> AbStateView { get; set; }
    public BaseShineFile<ItemActionEntry> ItemAction { get; set; }
    public BaseShineFile<ItemActionConditionEntry> ItemActionCondition { get; set; }
    public BaseShineFile<ItemActionEffectEntry> ItemActionEffect { get; set; }
    public BaseShineFile<ItemActionEffectDescEntry> ItemActionEffectDesc { get; set; }
    public BaseShineFile<ActiveSkillEntry> ActiveSkill { get; set; }
    public BaseShineFile<ActiveSkillInfoServerEntry> ActiveSkillInfoServer { get; set; }
    public BaseShineFile<ActiveSkillViewEntry> ActiveSkillView { get; set; }

    private ShineFileManager() { }
}