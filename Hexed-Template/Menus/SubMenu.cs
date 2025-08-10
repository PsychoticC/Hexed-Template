using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldAPI.ButtonAPI;
using WorldAPI.ButtonAPI.Groups;

namespace Hexed_Template.Menus
{
    internal class SubMenu
    {
        public static void InitSubMenu()
        {
            var p = new VRCPage("SubMenu"); // Creates submenu page
            MenuCreation.MainGrp.AddButton("SubMenu1", "Open SubMenu", () => p.OpenMenu()); // Makes button on main page to open submenu


            var CBG = new CollapsibleButtonGroup(p, "Collapsible Button Group"); // Can use collapsible groups to :3

            CBG.AddLable("Main Lable", "Lower Text Stuff"); // js a lable, can also have action to it
        }
    }
}
