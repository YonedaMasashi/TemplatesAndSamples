using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBarAndCancel {

    // 進捗を表すための ViewModel
    public class ProgressViewModel : INotifyPropertyChanged {

        private int _Progress;
        public int Progress {
            get { return this._Progress; }
            set {
                this._Progress = value;
                this.NotifyProperyChanged(nameof(this.Progress));
            }
        }

        private string _ProgressText;
        public string ProgressText {
            get { return this._ProgressText; }
            set {
                this._ProgressText = value;
                this.NotifyProperyChanged(nameof(this.ProgressText));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyProperyChanged(string name) {
            this.PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(name)
            );
        }
    }
}
