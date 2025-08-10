using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hexed_Template.Hooks
{
    internal class PatchableClass
    {
        private static int PatchCount = 0;
        public static void LoadAllPatches()
        {
            var patchableItems = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsSubclassOf(typeof(PatchableClass)) && !t.IsAbstract);

            foreach (var item in patchableItems)
            {
                var instance = (PatchableClass)Activator.CreateInstance(item);
                instance?.PatchableMethod();
                PatchCount++;
            }

            CLogs.Log($"Applied {PatchCount} Patches");
        }

        public virtual void PatchableMethod()
        {

        }
    }
}
