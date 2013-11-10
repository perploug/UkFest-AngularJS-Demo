#Umbraco 7 samples

**Code from my UK Umbraco festival 2013, to install, simply copy the app_code and app_plugins folder to the root of your site, run the people.sql against the current database, and finally restart your website.**

##Folder structure

###App_code
Contains all serverside classes to construct the tree and the rest-endpoint in the shape of a treecontroller and an apicontroller.

**person.cs** describes the data we are passing around, mapping it to the people DB table. This is done with the embedded petapoco orm in umbraco. 

**PeopleTreeController.cs** exposes methods for the tree, and does the configuration to register it in umbracos /config/tree.config file. It contains 2 methods, 2 for returning nodes for the tree, and on for returning menu actions when requested.

**PersonApiController.cs** exposes the different methods the person.resource.cs uses in editors and dialogs to retrieve and modify person data. Its a UmbracoAuthorizedJsonController which only works for authorized umbraco users, and will only return json.

##App_plugins
Containing all the client-side code, dependencies and the package.manifest file, which registers needed dependencies on app_start, as well as included property editors. 

**/app_plugins/backoffice/peopletreee/** contains all editors for the tree "peopletree".

**/app_plugins/umbraco/peopletreee/** contains all the dialogs for the tree "peopletree". notice: this is bound to change as this is a bug. Both editors and dialogs will be in the /backoffice folder.

**/app_plugins/propertyeditors/** contains all property-editors registered by the package.manifest -in this case a personpicker.




