using System.Windows;


namespace CTTManagement.Views
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowTableSettingsDialog(object sender, RoutedEventArgs e)
        {
            Window tableSettingsDialog = new Dialog();
            tableSettingsDialog.Show();
        }

        
    }
}
