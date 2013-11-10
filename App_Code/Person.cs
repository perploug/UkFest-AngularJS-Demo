using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Umbraco.Core.Persistence;

/// <summary>
/// Summary description for People
/// </summary>
/// 

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