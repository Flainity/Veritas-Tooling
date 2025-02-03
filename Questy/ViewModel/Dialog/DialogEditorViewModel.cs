using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Questy.Message;
using ShineData.Shine.Structure.Dialog;

namespace Questy.ViewModel.Dialog;

public partial class DialogEditorViewModel : ObservableObject, IRecipient<DialogSelectionChangedMessage>
{
    [ObservableProperty] private QuestDialog? _selectedDialog;
    [ObservableProperty] private FlowDocument _formattedDialog = new();
    
    public DialogEditorViewModel()
    {
        WeakReferenceMessenger.Default.Register(this);
    }

    public void Receive(DialogSelectionChangedMessage message)
    {
        SelectedDialog = message.Value;
        FormatText();
    }
    
    private void FormatText()
    {
        var document = new FlowDocument();
        var paragraph = new Paragraph();
        string pattern = @"\[(.*?)\]";
        var matches = Regex.Matches(SelectedDialog.Dialog, pattern);

        int lastIndex = 0;
        foreach (Match match in matches)
        {
            // Add text before the match
            if (match.Index > lastIndex)
            {
                paragraph.Inlines.Add(new Run(SelectedDialog.Dialog.Substring(lastIndex, match.Index - lastIndex)));
            }

            // Add the matched text with formatting, including the brackets
            var boldRun = new Run(match.Value)
            {
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.RoyalBlue
            };
            paragraph.Inlines.Add(boldRun);

            lastIndex = match.Index + match.Length;
        }

        // Add remaining text
        if (lastIndex < SelectedDialog.Dialog.Length)
        {
            paragraph.Inlines.Add(new Run(SelectedDialog.Dialog.Substring(lastIndex)));
        }

        document.Blocks.Add(paragraph);
        FormattedDialog = document;
    }
}