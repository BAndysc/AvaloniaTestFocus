using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using Avalonia.Threading;

namespace FocusTest
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            new MainWindow().ShowDialog(this);
        }
        
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            DispatcherTimer.RunOnce(() =>
            {
                FocusManager.Instance.Focus(this.FindControl<TextBox>("TextBox"), NavigationMethod.Pointer);
                //this.FindControl<TextBox>("TextBox").Focus();
            }, TimeSpan.FromMilliseconds(50));
        }
    }
}