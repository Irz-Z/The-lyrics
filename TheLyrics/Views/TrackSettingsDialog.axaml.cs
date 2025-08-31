using Avalonia.Controls;
using Avalonia.Interactivity;
using TheLyrics.App.ViewModels;
using TheLyrics.Core;
using TheLyrics.Core.Ustx;

namespace TheLyrics.App.Views {
    public partial class TrackSettingsDialog : Window {

        TrackSettingsViewModel viewModel;

        public TrackSettingsDialog() : this(new UTrack(DocManager.Inst.Project)) { }

        public TrackSettingsDialog(UTrack track) {
            InitializeComponent();
            DataContext = viewModel = new TrackSettingsViewModel(track);
        }

        public void OnOkClicked(object sender, RoutedEventArgs e) {
            viewModel.Finish();
            Close();
        }
    }
}
