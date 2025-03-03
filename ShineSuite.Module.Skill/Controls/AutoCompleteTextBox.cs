using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ShineSuite.Module.Skill.Controls
{
    public class AutoCompleteTextBox : TextBox
    {
        private Popup _popup; // Popup für Vorschläge
        private ListBox _suggestionsListBox; // ListBox zur Anzeige der Vorschläge

        // DependencyProperty für die Vorschlagsquelle
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(
                nameof(Source),
                typeof(IEnumerable<string>),
                typeof(AutoCompleteTextBox),
                new PropertyMetadata(null, OnSourceChanged));

        // DependencyProperty für dynamisches Filtern
        public static readonly DependencyProperty IsDynamicFilteringEnabledProperty =
            DependencyProperty.Register(
                nameof(IsDynamicFilteringEnabled),
                typeof(bool),
                typeof(AutoCompleteTextBox),
                new PropertyMetadata(true));

        /// <summary>
        /// Datenquelle für Vorschläge (Liste der Optionen).
        /// </summary>
        public IEnumerable<string> Source
        {
            get => (IEnumerable<string>)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        /// <summary>
        /// Aktiviert oder deaktiviert dynamisches Filtern.
        /// </summary>
        public bool IsDynamicFilteringEnabled
        {
            get => (bool)GetValue(IsDynamicFilteringEnabledProperty);
            set => SetValue(IsDynamicFilteringEnabledProperty, value);
        }

        /// <summary>
        /// Konstruktor: Initialisiere die AutoComplete-TextBox.
        /// </summary>
        public AutoCompleteTextBox()
        {
            InitializePopup();
            this.TextChanged += OnTextChanged;
            this.LostFocus += (s, e) => _popup.IsOpen = false; // Popup schließen, wenn TextBox den Fokus verliert
        }

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (AutoCompleteTextBox)d;
            control.UpdateSuggestions(control.Text);
        }

        /// <summary>
        /// Initialisiere das Popup für die Vorschläge.
        /// </summary>
        private void InitializePopup()
        {
            // Popup erstellen
            _popup = new Popup
            {
                PlacementTarget = this,
                Placement = PlacementMode.Bottom,
                StaysOpen = false
            };

            // ListBox erstellen und in das Popup einfügen
            _suggestionsListBox = new ListBox
            {
                MaxHeight = 100 // Begrenze die Höhe des Vorschlagsfensters
            };

            _suggestionsListBox.MouseDoubleClick += SuggestionsListBox_MouseDoubleClick;

            // Füge die ListBox ins Popup ein und binde es an die TextBox
            _popup.Child = _suggestionsListBox;
        }

        /// <summary>
        /// Event-Handler: Vorschlag per Doppelklick übernehmen.
        /// </summary>
        private void SuggestionsListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_suggestionsListBox.SelectedItem is string selectedSuggestion)
            {
                this.Text = selectedSuggestion; // Übernehme den Vorschlag
                _popup.IsOpen = false; // Schließe das Popup
                this.CaretIndex = this.Text.Length; // Setze den Cursor ans Ende
            }
        }

        /// <summary>
        /// Event-Handler: Reagiere auf Benutzereingaben und aktualisiere Vorschläge.
        /// </summary>
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSuggestions(this.Text);
        }

        /// <summary>
        /// Aktualisiere die Vorschläge basierend auf der Benutzereingabe.
        /// </summary>
        /// <param name="input">Der aktuelle Text in der TextBox.</param>
        private void UpdateSuggestions(string input)
        {
            if (Source == null || string.IsNullOrWhiteSpace(input) && IsDynamicFilteringEnabled)
            {
                _popup.IsOpen = false;
                return;
            }

            // Filtere Vorschläge dynamisch, falls aktiviert
            var suggestions = IsDynamicFilteringEnabled
                ? Source.Where(x => x.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList()
                : Source.ToList();

            if (suggestions.Any())
            {
                _suggestionsListBox.ItemsSource = suggestions; // Vorschläge in die ListBox einfügen
                _popup.IsOpen = true;
            }
            else
            {
                _popup.IsOpen = false;
            }
        }
    }
}