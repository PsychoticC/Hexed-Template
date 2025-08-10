using CoreRuntime.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC.UI.Elements;

namespace Hexed_Template.Hooks
{
    internal class QMHook : PatchableClass // Inherit this, itll let u patch with one call 
    {
        private static void OnQMEnable(nint instance)
        {
            CLogs.Log("QM was opened!");

            _enable(instance); // Call at end of method :p
        }
        private static void OnQMDisabled(nint instance)
        {
            CLogs.Log("QM was closed!");

            _disable(instance); // Call at end of method :p
        }

        public override void PatchableMethod()
        {
            _enable = HookManager.Detour<_Enable>(typeof(QuickMenu).GetMethod(nameof(QuickMenu.OnEnable)), new(OnQMEnable));
            _disable = HookManager.Detour<_Disable>(typeof(QuickMenu).GetMethod(nameof(QuickMenu.OnDisable)), new(OnQMDisabled));
            CLogs.Log("Hooked QM Functions!");
        }

        private delegate void _Enable(nint instance); // Use nint for Types, IntPtr also works. For value types like, int, float etc js pass that thru as is.
        private static _Enable _enable;

        private delegate void _Disable(nint instance);
        private static _Disable _disable;
    }
}
