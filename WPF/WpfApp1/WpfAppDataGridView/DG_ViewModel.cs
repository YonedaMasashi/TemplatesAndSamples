using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDataGridView {
    public class ValueList {
        public List<DG_ViewModel> DG_ViewModels { get; set; }
        public ValueList() {
            DG_ViewModels = new List<DG_ViewModel>() {
                new DG_ViewModel { Slot = 1, Data1=1, Data2=1, Execute=false},
                new DG_ViewModel { Slot = 2, Data1=1, Data2=0, Execute=false},
                new DG_ViewModel { Slot = 3, Data1=1, Data2=2, Execute=false},
            };
        }
    }

    public class DG_ViewModel : ViewModelBase {

        private long _Slot = 0;
        public long Slot {
            get {
                return _Slot;
            }
            set {
                _Slot = value;
                OnPropertyChanged("Slot");
            }
        }

        private bool _Execute = false;
        public bool Execute {
            get {
                return _Execute;
            }
            set {
                _Execute = value;
                OnPropertyChanged("Execute");
            }
        }

        private long _Data1 = 0;
        public long Data1 {
            get {
                return _Data1;
            }
            set {
                _Data1 = value;
                UpdateIsEnableExecute();
                OnPropertyChanged("Data1");
            }
        }

        private long _Data2 = 0;
        public long Data2 {
            get {
                return _Data2;
            }
            set {
                _Data2 = value;
                UpdateIsEnableExecute();
                OnPropertyChanged("Data2");
            }
        }

        private bool _IsEnableExecute = false;
        public bool IsEnableExecute {
            get {
                return _IsEnableExecute;
            }
            set {
                _IsEnableExecute = value;
                OnPropertyChanged("IsEnableExecute");
            }
        }

        void UpdateIsEnableExecute() {
            if (_Data1 != 0 && _Data2 != 0) {
                IsEnableExecute = true;
            } else {
                IsEnableExecute = false;
            }
        }
    }
}
