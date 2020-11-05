using CTTManagement.DataModel.FormV;
using CTTManagement.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

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
            DataGridFormVAccess dataGridAccess = new DataGridFormVAccess();
            FormVData = dataGridAccess.CreateDataGridView();
            //InitializeObservableData();
        }

        public ObservableCollection<FormVModel> FormVData { get; set; }
        public void InitializeObservableData()
        {
            DataGridFormVAccess dataGridAccess = new DataGridFormVAccess();
            DataGridXAML.ItemsSource = dataGridAccess.CreateDataGridView();
        }


        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridCell selectedCell = sender as DataGridCell;
            string columnName=selectedCell.Column.Header.ToString();
            string content=selectedCell.ToString();
        }
    }

   
}
