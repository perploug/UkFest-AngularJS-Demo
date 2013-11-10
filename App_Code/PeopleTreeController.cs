using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;

using Umbraco.Core;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;


/// <summary>
/// Summary description for PeopleTreeController
/// </summary>

//add treecontroller
[Tree("settings", "peopleTree", "People")]
[PluginController("People")]
public class MyCustomTreeController : TreeController
{   

    
    protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
    {
        //check if we're rendering the root node's children
        if (id == Constants.System.Root.ToInvariantString())
        {
            var ctrl = new PersonApiController();
            var nodes = new TreeNodeCollection();

            foreach (var person in ctrl.GetAll())
            {
                var node = CreateTreeNode(person.Id.ToString(), queryStrings, person.Name, "icon-user", false);

                if (person.IsDrunk)
                    node.Icon = "icon-wine-glass";

                nodes.Add(node);
            
            }
            return nodes;
        }

        //this tree doesn't suport rendering more than 1 level
        throw new NotSupportedException();
    }

    
    
    protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
    {
        
        var menu = new MenuItemCollection();
        var m = new MenuItem("drink", "Drink");
        m.Icon = "wine-glass";
        menu.Items.Add(m);

        var x = new MenuItem("detox", "Detox");
        x.Icon = "medicine";
        menu.Items.Add(x);

        return menu;
    }
}