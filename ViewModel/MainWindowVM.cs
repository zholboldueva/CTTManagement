using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CTTManagement.ViewModel
{
    public class MainWindowVM : BindableBase
    {
        public MainWindowVM()
        {

        }

        public void getInfo(DataGridCell selectedCell)
        {
           
            string columnName = selectedCell.Column.Header.ToString();
            string content = selectedCell.ToString();

        }
        public ObservableCollection<InfoVM> SelectedSourceInfo { get; }
    }

    public class InfoVM:BindableBase
    {
        public string SelectedCellsHeader { get; set; }
        public string SelectedCellsContent { get; set; }
        public string SelectedCellsInfo { get; set; }

    }

}
