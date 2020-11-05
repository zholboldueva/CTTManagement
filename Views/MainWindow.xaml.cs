using CTTManagement.ViewModel;
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
            DataContext = new MainWindowVM();
        }

       

        private void TopControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (FormVTop.IsSelected) TestCasesBottom.IsSelected = true;
            else if (TestCasesTop.IsSelected) FormVBottom.IsSelected = true;
        }


        private void ControlBottom_Loaded(object sender, RoutedEventArgs e)
        {
            if (FormVBottom.IsSelected) TestCasesTop.IsSelected = true;
            else if (TestCasesBottom.IsSelected) FormVTop.IsSelected = true;
        }



    }
}
