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

        public MainWindow() {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e) {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;

            var progressWindow = new ProgressWindow(backgroundWorker);
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
                BackgroundWorker worker = sender as BackgroundWorker;
                if (worker.CancellationPending == true) {
                    return;
                }

                // 進捗表示
                ProgressViewModel progressVM = e.Argument as ProgressViewModel;
                var prg = (int)(((double)i / (double)loopMax) * 100.0);
                progressVM.Progress = prg;
                progressVM.ProgressText = string.Format("{0} / {1}", i + 1, loopMax);

                // 本処理
                var proc = new DummyProcess();
                proc.Execute();
            }
        }
    }
}
