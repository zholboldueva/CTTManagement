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

namespace CTTManagement.Views
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
