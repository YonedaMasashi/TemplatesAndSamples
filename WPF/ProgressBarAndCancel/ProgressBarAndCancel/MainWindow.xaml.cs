using ProgressBarAndCancel.Proc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ProgressBarAndCancel {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        BackgroundWorker _BackgroundWorker = new BackgroundWorker();
        ProgressViewModel _ProgressViewModel = new ProgressViewModel();

        public MainWindow() {
            InitializeComponent();
            _BackgroundWorker.DoWork += BackgroundWorker_DoWork;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e) {
            var progressWindow = new ProgressWindow(_ProgressViewModel, _BackgroundWorker);
            progressWindow.ShowDialog();
        }

        /// <summary>
        /// RunWorkerAsync() を実行したときに呼ばれるイベントハンドラー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            int loopMax = 5;
            for (int i = 0; i < loopMax; ++i) {
                // キャンセル判定
                if (_BackgroundWorker.CancellationPending == true) {
                    return;
                }

                // 進捗表示
                var prg = (int)(((double)i / (double)loopMax) * 100.0);
                _ProgressViewModel.Progress = prg;
                _ProgressViewModel.ProgressText = string.Format("{0} / {1}", i + 1, loopMax);

                // 本処理
                var proc = new DummyProcess();
                proc.Execute();
            }
        }
    }
}
