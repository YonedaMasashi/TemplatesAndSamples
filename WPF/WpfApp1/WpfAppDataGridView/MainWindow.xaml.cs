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

namespace WpfAppDataGridView {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            CellValue.DataContext = new ValueList();
        }

        private void Hoge_Click(object sender, RoutedEventArgs e) {
            var values = (ValueList)CellValue.DataContext;
            foreach (var elem in values.DG_ViewModels) {
                var data = elem.Execute;
            }
        }
    }
}
