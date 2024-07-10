using System;
using System.Collections;
using System.Collections.Generic;

namespace PayOrgUser;

public class QueryParameters
{
    public List<string> Fields { get; set;} 
    public int? Page { get; set;}
    public string Procedure { get; set;}
    public Guid? UserGuid { get; set;}
    

}
