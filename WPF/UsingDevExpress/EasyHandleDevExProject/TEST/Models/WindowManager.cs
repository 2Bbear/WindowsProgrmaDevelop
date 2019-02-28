
using DevExpress.Mvvm.ModuleInjection;
using EasyHandleDevExProject.Config;

namespace TEST.Models
{
    public class WindowManager
    {
        void ChangeRibbonRegion()
        {
            ModuleManager.DefaultManager.InjectOrNavigate(Regions.RibbonRegion, Modules.CLMModule);
        }
    }
}
