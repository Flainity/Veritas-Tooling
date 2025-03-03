using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using AutoCompleteTextBox.Editors;
using ShineData.Shine.Files;

namespace ShineSuite.Module.Skill.Provider;

public class AbstateProvider : ISuggestionProvider
{
    private readonly ObservableCollection<AbStateEntry> _abstates;
    
    public IEnumerable GetSuggestions(string filter)
    {
        return _abstates.Where(x => x.InxName.ToLower().Contains(filter.ToLower()));
    }
    
    public AbstateProvider(ObservableCollection<AbStateEntry> abstates)
    {
        _abstates = abstates;
    }
}