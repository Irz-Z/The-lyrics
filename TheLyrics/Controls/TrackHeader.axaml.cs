using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using TheLyrics.App.ViewModels;
using TheLyrics.Core;
using TheLyrics.Core.Ustx;
using ReactiveUI;

namespace TheLyrics.App.Controls {
    public partial class TrackHeader : UserControl, IDisposable {
        public static readonly DirectProperty<TrackHeader, double> TrackHeightProperty =
            AvaloniaProperty.RegisterDirect<TrackHeader, double>(
                nameof(TrackHeight),
                o => o.TrackHeight,
                (o, v) => o.TrackHeight = v);
        public static readonly DirectProperty<TrackHeader, Point> OffsetProperty =
            AvaloniaProperty.RegisterDirect<TrackHeader, Point>(
                nameof(Offset),
                o => o.Offset,
                (o, v) => o.Offset = v);
        public static readonly DirectProperty<TrackHeader, int> TrackNoProperty =
            AvaloniaProperty.RegisterDirect<TrackHeader, int>(
                nameof(TrackNo),
                o => o.TrackNo,
                (o, v) => o.TrackNo = v);

        public double TrackHeight {
            get => trackHeight;
            set => SetAndRaise(TrackHeightProperty, ref trackHeight, value);
        }
        public Point Offset {
            get => offset;
            set => SetAndRaise(OffsetProperty, ref offset, value);
        }
        public int TrackNo {
            get => trackNo;
            set => SetAndRaise(TrackNoProperty, ref trackNo, value);
        }

        private double trackHeight;
        private Point offset;
        private int trackNo;

        public TrackHeaderViewModel? ViewModel;

        private List<IDisposable> unbinds = new List<IDisposable>();

        private UTrack? track;

        public TrackHeader() {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change) {
            base.OnPropertyChanged(change);
            if (change.Property == OffsetProperty ||
                change.Property == TrackNoProperty ||
                change.Property == TrackHeightProperty) {
                SetPosition();
            }
        }

        internal void Bind(UTrack track, TrackHeaderCanvas canvas) {
            this.track = track;
            unbinds.Add(this.Bind(TrackHeightProperty, canvas.GetObservable(TrackHeaderCanvas.TrackHeightProperty)));
            unbinds.Add(this.Bind(HeightProperty, canvas.GetObservable(TrackHeaderCanvas.TrackHeightProperty)));
            unbinds.Add(this.Bind(OffsetProperty, canvas.WhenAnyValue(x => x.TrackOffset, trackOffset => new Point(0, -trackOffset * TrackHeight))));
            SetPosition();
        }

        private void SetPosition() {
            Canvas.SetLeft(this, 0);
            Canvas.SetTop(this, Offset.Y + (track?.TrackNo ?? 0) * trackHeight);
        }

        void TrackNameButtonClicked(object sender, RoutedEventArgs args) {
            ViewModel?.Rename();
            args.Handled = true;
        }

        // Singer button methods removed for The Lyrics vocal training app
        // void SingerButtonClicked(object sender, RoutedEventArgs args) { ... }
        // void SingerButtonContextRequested(object sender, ContextRequestedEventArgs args) { ... }

        // Phonemizer button methods removed for The Lyrics vocal training app  
        // void PhonemizerButtonClicked(object sender, RoutedEventArgs args) { ... }
        // void PhonemizerButtonContextRequested(object sender, ContextRequestedEventArgs args) { ... }

        // Renderer button methods removed for The Lyrics vocal training app
        // void RendererButtonClicked(object sender, RoutedEventArgs args) { ... }
        // void RendererButtonContextRequested(object sender, ContextRequestedEventArgs args) { ... }

        void VolumeFaderPointerPressed(object sender, PointerPressedEventArgs args) {
            if (args.GetCurrentPoint((Visual?)sender).Properties.IsRightButtonPressed && ViewModel != null) {
                ViewModel.Volume = 0;
                args.Handled = true;
            }
        }

        void PanFaderPointerPressed(object sender, PointerPressedEventArgs args) {
            if (args.GetCurrentPoint((Visual?)sender).Properties.IsRightButtonPressed && ViewModel != null) {
                ViewModel.Pan = 0;
                args.Handled = true;
            }
        }

        void VolumeFaderContextRequested(object sender, ContextRequestedEventArgs args) {
            if (ViewModel != null) {
                ViewModel.Volume = 0;
            }
            args.Handled = true;
        }

        void PanFaderContextRequested(object sender, ContextRequestedEventArgs args) {
            if (ViewModel != null) {
                ViewModel.Pan = 0;
            }
            args.Handled = true;
        }

        // Track settings button method removed for The Lyrics vocal training app
        // void TrackSettingsButtonClicked(object sender, RoutedEventArgs args) { ... }

        void VolumePointerPressed(object sender, PointerPressedEventArgs args) {
            // Text editing removed - simplified volume control for vocal training app
            if (args.ClickCount == 2 && ViewModel != null) {
                ViewModel.Volume = 0; // Reset to 0 on double click
                args.Handled = true;
            }
        }
        void PanPointerPressed(object sender, PointerPressedEventArgs args) {
            // Text editing removed - simplified pan control for vocal training app  
            if (args.ClickCount == 2 && ViewModel != null) {
                ViewModel.Pan = 0; // Reset to 0 on double click
                args.Handled = true;
            }
        }
        
        // TextBox methods removed for simplified vocal training interface
        // void VolumeOrPanTextBoxKeyDown(object sender, KeyEventArgs args) { ... }
        // void VolumeOrPanTextBoxLostFocus(object sender, RoutedEventArgs args) { ... }
        void VolumeOrPanSliderValueChanged(object sender, RangeBaseValueChangedEventArgs args) {
            // TextBox updates removed - simplified for vocal training app
        }

        // TextBox activation method removed for simplified vocal training interface
        // void ActivateVolumeOrPanTextBox(TextBox textBox, string text) { ... }
        
        // TextBox input handling method removed for simplified vocal training interface  
        // private void FinishVolumeOrPanInput(object sender, bool commit) { ... }

        public void Dispose() {
            unbinds.ForEach(u => u.Dispose());
            unbinds.Clear();
        }
    }
}
