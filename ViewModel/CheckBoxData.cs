using CTTManagement.Model;
using CTTManagement.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CTTManagement.ViewModel
{
    public class CheckBoxData
    {
        public CheckBoxData()
        {

        }

        public ObservableCollection<CheckBoxViewModel> getFormVTableColumnNames()
        {
            ObservableCollection<CheckBoxViewModel> list = new ObservableCollection<CheckBoxViewModel>();
            
            PropertyInfo[] propertyInfos= typeof(FormVModel).GetProperties();
            int index = 0;
            foreach(var property in propertyInfos)
            {
                CheckBoxViewModel checkBox = new CheckBoxViewModel();
                checkBox.Id = index++;
                checkBox.Name = property.Name;
                checkBox.IsChecked = true;
                list.Add(checkBox);
            }
            return list; 
        }

        public List<CheckBoxViewModel> getTestCasesTableColumnNames()
        {
            List<CheckBoxViewModel> list = new List<CheckBoxViewModel>();

            PropertyInfo[] propertyInfos = typeof(ZatsTestsModel).GetProperties();
            int index = 0;
            foreach (PropertyInfo property in propertyInfos)
            {
                CheckBoxViewModel checkBox = new CheckBoxViewModel();
                checkBox.Id = index++;
                checkBox.Name = property.Name;
                checkBox.IsChecked = true;
                list.Add(checkBox);
            }
            return list;
        }
    }
}
