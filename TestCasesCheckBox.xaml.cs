using CTTManagement.Model;
using CTTManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaktionslogik für TestCasesCheckBox.xaml
    /// </summary>
    public partial class TestCasesCheckBox : UserControl
    {

        public TestCasesCheckBox()
        {
            InitializeComponent();
            InitializeObservableData();
        }

        public void InitializeObservableData()
        {
            CheckBoxData dataGridAccess = new CheckBoxData();
            TestCasesCheckBox1.ItemsSource = dataGridAccess.getTestCasesTableColumnNames();

        }
    }
    public class ListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((IList<CheckBoxViewModel>)value).Select(i => new { IsChecked = i.IsChecked, Name = i.Name });
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
