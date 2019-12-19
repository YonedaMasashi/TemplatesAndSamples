using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBarAndCancel.Proc {
    class DummyProcess {

        public void Execute() {
            System.Threading.Thread.Sleep(500);
        }
    }
}
