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
using System.Windows.Shapes;

namespace ProgressBarAndCancel {
    /// <summary>
    /// ProgressWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ProgressWindow : Window {

        BackgroundWorker _BackgroundWorker = null;
        public bool Complete { get; private set; }
        public bool Close { get; private set; }


        public ProgressWindow(BackgroundWorker bw) {
            InitializeComponent();

            _BackgroundWorker = bw;
            ProgressViewModel progVM = new ProgressViewModel();
            DataContext = progVM;
            Complete = false;
            Close = false;

            _BackgroundWorker.WorkerSupportsCancellation = true; // バックグラウンド処理をキャンセルできるようにする
            _BackgroundWorker.WorkerReportsProgress = true; // 進捗状況の報告をできるようにする
            _BackgroundWorker.RunWorkerCompleted += _BackgroundWorker_RunWorkerCompleted;
            _BackgroundWorker.RunWorkerAsync(progVM);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) {
            if (_BackgroundWorker.IsBusy) {
                _BackgroundWorker.CancelAsync();
            }
        }
        
        /// <summary>
        /// バックグラウンド操作の完了時、キャンセル時、またはバックグラウンド操作によって例外が発生したときに発生する
        /// イベントハンドラー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                //Cancelled
                Complete = false;
                Close = true;

            } else if (e.Error != null) {
                //Exception Thrown
                Complete = false;
                Close = true;

            } else {
                //Completed
                Complete = true;
                Close = true;
            }
            Close();
        }

        protected override void OnClosing(CancelEventArgs e) {
            if (!Close)
                e.Cancel = true;
        }

    }
}
