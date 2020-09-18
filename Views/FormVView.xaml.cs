using CTTManagement.DataModel.FormV;
using CTTManagement.Model;
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
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class FormVView : UserControl
    {
        public FormVView()
        {
            InitializeComponent();
            InitializeObservableData();
        }

        public void InitializeObservableData()
        {
            DataGridFormVAccess dataGridAccess = new DataGridFormVAccess();
            DataGridXAML.ItemsSource = dataGridAccess.CreateDataGridView();
            //FormVCheckBox formVCheckBox = new FormVCheckBox();
            
        }

    }

    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class FilterVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isSelected = System.Convert.ToBoolean(value);

            return isSelected ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var v = (Visibility)value;
            return v == Visibility.Hidden ? false : true;
        }
    }
}
