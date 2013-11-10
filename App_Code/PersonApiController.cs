using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

/// <summary>
/// Summary description for PeopleController
/// </summary>
/// 
[PluginController("People")]
public class PersonApiController : UmbracoAuthorizedJsonController
{
    public Person PostSave(Person person) {
        if (person.Id > 0)
            DatabaseContext.Database.Update(person);
        else
            DatabaseContext.Database.Save(person);

        return person;
    }

    public int DeleteById(int id) {
        var db = UmbracoContext.Application.DatabaseContext.Database;
        return db.Delete<Person>(id);     
    }

    public int GetDrunk(int id)
    {
        var db = UmbracoContext.Application.DatabaseContext.Database;
        return db.Update<Person>("SET isDrunk = @0 WHERE id = @1", true, id); 
    }

    public int GetSober(int id)
    {
        var db = UmbracoContext.Application.DatabaseContext.Database;
        return db.Update<Person>("SET isDrunk = @0 WHERE id = @1", false, id);
    }

    public Person GetById(int id) {
        var db = UmbracoContext.Application.DatabaseContext.Database;
        var query = new Sql().Select("*").From("people").Where<Person>(x => x.Id == id);

        return db.Fetch<Person>(query).FirstOrDefault();
    }

    public IEnumerable<Person> GetAll()
    {
        var db = UmbracoContext.Application.DatabaseContext.Database;
        var query = new Sql().Select("*").From("people");

        return db.Fetch<Person>(query);
    }
}