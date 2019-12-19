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

        private async void BtnStart_Click(object sender, RoutedEventArgs e) {
            ProgressViewModel progressViewModel = new ProgressViewModel();

            var progressWindow = new ProgressWindow(progressViewModel, 
                (BackgroundWorker bw) => {
                    int loopMax = 5;
                    for (int i = 0; i < loopMax; ++i) {
                        if (bw.CancellationPending == true) {
                            return;
                        }
                        var prg = (int)(((double)i / (double)loopMax) * 100.0);
                        progressViewModel.Progress = prg;
                        progressViewModel.ProgressText = string.Format("{0} / {1}", i + 1, loopMax);
                        var proc = new DummyProcess();
                        proc.Execute();
                    }
                });

            progressWindow.ShowDialog();

        }
    }
}
