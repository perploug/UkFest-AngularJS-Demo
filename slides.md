#Building in belle


##Todo
We have so much stuff to build:

- Data and services
- A tree
- A context menu
- An Editor
- Menu + actions
- Action dialogs
- Property Editor
- Property Editor Dialog



##Data and services
I've already done a bit of stuff

- Database with a collection of people
- A person class
- A basic APIController with methods for common actions


##Person Class
The data we will pass around

    [TableName("people")]
    [DataContract(Name="person", Namespace = "")]
    public class Person
    {
        [DataMember(Name="id")]
        public int Id { get; set; }
        
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        [DataMember(Name = "addresse")]
        public string Addresse { get; set; }
    
        [DataMember(Name = "email")]
        public string Email { get; set; }
    
        [DataMember(Name = "bio")]
        public string Bio { get; set; }
    
        [DataMember(Name = "isDrunk")]
        public bool IsDrunk { get; set; }
    }



##PersonApiController
Our services endpoint for our JS to access serverside data. We use a standard attribute to expose:

    [PluginController("People")]
    public class PersonApiController : UmbracoAuthorizedJsonController
    {
        ...methods
    }

Accesible via url:

    /umbraco/People/PersonApi/GetById/1


##Methods in the PersonApiController

    public IEnumerable<Person> GetAll()
    {
        var db = UmbracoContext.Application.DatabaseContext.Database;
        var query = new Sql().Select("*").From("people");

        return db.Fetch<Person>(query);
    }



##Methods in the PersonApiControl 2

    public Person PostSave(Person person) {
        if (person.Id > 0)
            DatabaseContext.Database.Update(person);
        else
            DatabaseContext.Database.Save(person);

        return person;
    }


#So what now?


##Step 1. the tree

- We will create a tree to display person list
- Talk about conventions
- default urls and their locations


##Step 2. the context menu

- Make the tree return context menu items
- prettify with icons
- More conventions talk


##Step 3. the editor

- Create a html view in the right location
- Create editing controls to modify values


##Step 4, the action dialogs

- Menu points to drink/detox views
- We need to add these views



##Step 5. the js resource

- create person.resource.js
- include in package.manifest
- map serverside methods to js methods
- makes use of $http



##Mapping url to a promise
Promises are a core part of Angular. So you say, "Do this" and when you are eventually done or fail, I'll deal with it. 

    getById: function(id){
        return $http.get("People/PersonApi/GetById?id="+id);
    },

**So you can do:** 

    personResource.getById(123).then(function(response){
        $scope.person = response.data;
    },function(err){
        alert("fail: " + err);
    });


##Step 6, tying it all together in the controllers

- Add editor controller
- Add dialog controllers
- Intergrate with the personResource service


##Step 7, Add people picker

- Add people picker property editor
- Add people tree dialog
- use Umb-Tree directive


##Step 8, sharing is caring

- You can download the entire project here:
- https://github.com/perploug/UkFest-AngularJS-Demo