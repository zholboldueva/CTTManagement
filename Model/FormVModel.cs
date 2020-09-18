using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTTManagement.Model
{
    public class FormVModel : INotifyPropertyChanged
    {
        public string FormItemNo { get; set; }
        public string TitleDescrNote { get; set; }
        public string WikiPageName { get; set; }
        public string SelfCert { get; set; }
        public string Verification { get; set; }
        public string AdHoc { get; set; }
        public string ZatsKey { get; set; }
        public string ZatsValue { get; set; }
        public string ZatsTests { get; set; }
        public string TriggeredBy { get; set; }
        public string TagName { get; set; }
        public string TagValue { get; set; }
        public string InputCustomType { get; set; }
        public string InputComboType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
