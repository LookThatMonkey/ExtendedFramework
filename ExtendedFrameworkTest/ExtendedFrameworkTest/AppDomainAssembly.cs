using ExtendedFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtendedFrameworkTest
{
    class AppDomainAssembly : IAppDomainAssembly
    {
        public CrossAppDomainDelegate StartCallBackDelegate => () => {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 frmMain = new Form1();
            Application.Run(frmMain);
        };

        public CrossAppDomainDelegate CloseCallBackDelegate => () => {
        };
    }
}
