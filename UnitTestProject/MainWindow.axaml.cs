using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UnitTestProject
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
