using CoreRuntime.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexed_Template.Extensions
{
    public static class CoroutineExtensions
    {
        public static void Start(this IEnumerator ien)
        {
            CoroutineManager.RunCoroutine(ien);
        }
        public static void Stop(this IEnumerator ien)
        {
            CoroutineManager.StopCoroutine(ien);
        }
    }
}
