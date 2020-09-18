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
using  CTTManagement.Views;

namespace CTTManagement
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public FormVView FormGridView;
        //public FormVCheckBox FormGridCheckBox;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabSwitchViewControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        //private void TableSettingsControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //FormGridView = TableSettingsControl.TabSwitchViewControl.FormVViewControl as FormVView;
        //    //FormGridCheckBox = TableSettingsControl.FormVCheckBoxControl as FormVCheckBox;

        //    //var k=FormGridView.DataGridXAML.Columns[];
        //}


    }
}
