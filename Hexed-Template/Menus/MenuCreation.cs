using Hexed_Template.Extensions;
using HexedTools.HookUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WorldAPI.ButtonAPI;
using WorldAPI.ButtonAPI.Groups;

namespace Hexed_Template.Menus
{
    internal class MenuCreation
    {
        static VRCPage MainPage;
        public static ButtonGroup MainGrp;

        public static IEnumerator MakeMenus()
        {
            MainPage = new VRCPage("Cheat Template");
            new Tab(MainPage, "Open Cheat Template"); // Creates a Tab, first tab by default. If wanted anywhere else change TabIndex.
            yield return new WaitForSeconds(2.0f);

            MainGrp = new ButtonGroup(MainPage, "Main"); // Creates ButtonGroup on the Root Page of the cheat

            // Below will be an example of Buttons, Half Buttons, Toggles and Half Toggles.

            MainGrp.AddButton("Click Me!", "Im a ToolTip", () =>
            {
                // Epic Delegate
                CLogs.Log("Clicked1");
            });

            // Duo buttons, half and sexy
            MainGrp.AddDuoButtons("Button 1", "Button 1 Tooltip", () =>
            {
                CLogs.Log("DuoButton 1 clicked!");
            }, "Button 2", "Button 2 Tooltip", () =>
            {
                CLogs.Log("DuoButton 2 Clicked!");
            });

            // 3 buttons, half and more sexy
            MainGrp.AddGrpOfButtons("Button 1", "Button 1 Tooltip", () =>
            {
                CLogs.Log("GrpButton 1 Clicked");
            }, "Button 2", "Button 2 Tooltip", () =>
            {
                CLogs.Log("GrpButton 2 Clicked");
            }, "Button 3", "Button 3 Tooltip", () =>
            {
                CLogs.Log("GrpButton 3 Clicked");
            });

            // Basic toggle
            MainGrp.AddToggle("Toggle 1", (sigmaBool) =>
            {
                if (sigmaBool)
                {
                    CLogs.Log("Enabled Toggle");
                }
                else
                {
                    CLogs.Log("Disabled Toggle");
                }
            });
            
            // Two half toggles
            MainGrp.AddGrpToggles("Toggle 1", "Turn Off Toggle 1", "Turn On Toggle 1", (epic) =>
            {
                if (epic)
                {
                    CLogs.Log("Enabled GrpToggle 1");
                }
                else
                {
                    CLogs.Log("Disabled GrpToggle 1");
                }
            }, "Toggle 2", "Turn Off Toggle 2", "Turn On Toggle 2", (epic2) =>
            {
                if (epic2)
                {
                    CLogs.Log("Enabled GrpToggle 2");
                }
                else
                {
                    CLogs.Log("Disabled GrpToggle 2");
                }
            });

            SubMenu.InitSubMenu(); // Calling submenu creation

        }

        public static IEnumerator WaitForQM()
        {
            while (GameObject.Find("Canvas_QuickMenu(Clone)") == null) yield return null;
            yield return null;

            MakeMenus().Start();
        }
    }
}
