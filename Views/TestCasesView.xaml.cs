using CTTManagement.DataModel.ZatsTests;
using CTTManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaktionslogik für TestCasesView.xaml
    /// </summary>
    public partial class TestCasesView : UserControl
    {
        public TestCasesView()
        {
            InitializeComponent();
            ZatsReflectionVAccess zatsDataAccess = new ZatsReflectionVAccess();
            ZatsTestData = zatsDataAccess.GetTestFiles();
            //  InitializeObservableZats();
        }

        public ObservableCollection<ZatsTestsModel> ZatsTestData { get; set; }
        public void InitializeObservableZats()
        {
            ZatsReflectionVAccess zatsDataAccess = new ZatsReflectionVAccess();
            ZatsGridXAML.ItemsSource = zatsDataAccess.GetTestFiles();
        }

    }
}
