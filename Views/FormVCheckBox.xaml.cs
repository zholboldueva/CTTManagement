using CTTManagement.ViewModel;
using System.Collections.Generic;
using System.Windows.Controls;


namespace CTTManagement.Views
{
    /// <summary>
    /// Interaktionslogik für FormVCheckBox.xaml
    /// </summary>
    /// 
   
    public partial class FormVCheckBox : UserControl
    {

        public FormVCheckBox()
        {
            InitializeComponent();
             // InitializeObservableData();
        }

      
        public void InitializeObservableData()
        {
            CheckBoxData dataGridAccess = new CheckBoxData();
            FormVCheckBox1.ItemsSource = dataGridAccess.getFormVTableColumnNames();
        }
    }

   
}
