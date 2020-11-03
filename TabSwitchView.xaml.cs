using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CTTManagement
{
    /// <summary>
    /// Interaktionslogik für TabSwitchView.xaml
    /// </summary>
    public partial class TabSwitchView : UserControl
    {
        public TabSwitchView()
        {
            InitializeComponent();
        }
        private void FormVViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (FormVTop.IsSelected) TestCasesBottom.IsSelected = true;
        }
        private void TestCasesViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (TestCasesTop.IsSelected) FormVBottom.IsSelected = true;
        }

        private void FormVViewControlBottom_Loaded(object sender, RoutedEventArgs e)
        {
            if (FormVBottom.IsSelected) TestCasesTop.IsSelected = true;
        }

        private void TestCasesViewControlBottom_Loaded(object sender, RoutedEventArgs e)
        {
            if (TestCasesBottom.IsSelected) FormVTop.IsSelected = true;
        }

    }
}
