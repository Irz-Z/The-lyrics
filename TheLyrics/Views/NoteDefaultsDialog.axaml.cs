using Avalonia.Controls;
using Avalonia.Interactivity;
using TheLyrics.App.ViewModels;
using TheLyrics.Core.Util;

namespace TheLyrics.App.Views {
    public partial class NoteDefaultsDialog : Window {
        internal readonly NoteDefaultsViewModel ViewModel;
        public NoteDefaultsDialog() {
            InitializeComponent();
            DataContext = ViewModel = new NoteDefaultsViewModel();
        }

        void OnSavePortamentoPreset(object sender, RoutedEventArgs e) {
            var dialog = new TypeInDialog() {
                Title = ThemeManager.GetString("notedefaults.preset.namenew"),
                onFinish = name => ViewModel.SavePortamentoPreset(name),
            };
            dialog.ShowDialog(this);
        }

        void OnRemovePortamentoPreset(object sender, RoutedEventArgs e) {
            ViewModel.RemoveAppliedPortamentoPreset();
        }

        void OnSaveVibratoPreset(object sender, RoutedEventArgs e) {
            var dialog = new TypeInDialog() {
                Title = ThemeManager.GetString("notedefaults.preset.namenew"),
                onFinish = name => ViewModel.SaveVibratoPreset(name),
            };
            dialog.ShowDialog(this);
        }

        void OnRemoveVibratoPreset(object sender, RoutedEventArgs e) {
            ViewModel.RemoveAppliedVibratoPreset();
        }

        void OnReset(object sender, RoutedEventArgs e) {
            NotePresets.Reset();
            ViewModel.ResetSettings();
        }
    }
}
