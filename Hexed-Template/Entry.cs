using BestHTTP;
using CoreRuntime.Interfaces;
using CoreRuntime.Manager;
using Hexed_Template.Extensions;
using Hexed_Template.Hooks;
using Hexed_Template.Menus;
using HexedTools;

namespace Hexed_Template
{
    public class Entry : HexedMod
    {
        public override void OnEntry(string[] args)
        {
            MonoManager.PatchUpdate(typeof(VRCApplication).GetMethod(nameof(VRCApplication.Update))); // Hooking Update for OnUpdate stuff

            PatchableClass.LoadAllPatches();

            CLogs.Log("Template Cheat Loaded :p");
            MenuCreation.WaitForQM().Start(); // Startin Coroutine to wait for qm stuff
        }

        public override void OnApplicationQuit()
        {
            // Like Update, you gotta find a OnQuit method to hook, otherwise this wont work.
        }

        public override void OnUpdate()
        {
            // Put stuff you need here
        }
    }
}
