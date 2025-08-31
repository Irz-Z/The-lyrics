using Avalonia.Controls;
using Avalonia.Interactivity;
using TheLyrics.App.ViewModels;

namespace TheLyrics.App.Views {
    public partial class PhoneticAssistant : Window {
        PhoneticAssistantViewModel viewModel;
        public PhoneticAssistant() {
            InitializeComponent();
            DataContext = viewModel = new PhoneticAssistantViewModel();
        }

        public void OnCopy(object sender, RoutedEventArgs e) {
            Clipboard?.SetTextAsync(viewModel.Phonemes);
        }
    }
}
