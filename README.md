# OData.NetFramework

The general overview about OData Rest API using Entity Framework, Repository and Unit of Work Pattern along with Autofac

#OData.Business: 
This will hold our domain classes.

#OData.InternalDataService: 
This will be our internal communication channel or data service.

#OData.IOC: 
This will be used for Dependency Injection.

#OData.ORM: 
This will be used for Entity Framework related operation.

# Issue and resolution
Recently updated the OData packages and while doing so received error as
"Multiple types were found that match the controller named 'metadata'"
This error was only specific to metadata while the rest of the api was working fine

So, to fix the metadata error, updated the method GetEdmModel() inside WebApiConfig.cs
Namespace = "ODataRestApiWithEntityFramework.Controllers"
And then ran ran the clean build. But, the error didn't go.

So as a brute force solution, I close the solution and delete all the bin/obj files
from every individual projects, reopened the solution and the error has gone.

If you face this issue perhaps these above resolution might help

Thanks,
Sunny


