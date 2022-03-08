using ExtendedFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtendedFrameworkTest2
{
    class AppDomainAssembly : IAppDomainAssembly
    {
        public CrossAppDomainDelegate StartCallBackDelegate => () => {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form0 frmMain = new Form0();
            Application.Run(frmMain);
        };

        public CrossAppDomainDelegate CloseCallBackDelegate => () => {
        };
    }
}
