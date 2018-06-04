# ASP .NET Core API Multi Tenant Example Project 
**Description**
This is a sample implementation for using multiple Tenants within an ASP .NET Core API Project.
Using:
* EF Core
* Middleware to identify Tenants
* One global DB (MT_Global)
* One DB per Tenant (in this example: MT_TenantOne and MT_TenantTwo)

**Example Usage**
* Make a GET request to `http://localhost:5000/api/values`
* Set a http header for the request named `X-Tenant-Guid` to either `43ce6f06-a472-461f-b990-3a25c7f44b7a` (TenantOne) or ` 199b625e-6ac6-4757-a38f-9a0391866469` (TenantTwo)

**Example Content of MT_Global (Table: Tenants)**

| GUID  | ConnectionString  | Name |
|---|---|---|
| 43ce6f06-a472-461f-b990-3a25c7f44b7a|Server=(localdb)\mssqllocaldb;Database=MT_TenantOne;Trusted_Connection=true;MultipleActiveResultSets=true|TenantOne|
|199b625e-6ac6-4757-a38f-9a0391866469|Server=(localdb)\mssqllocaldb;Database=MT_TenantTwo;Trusted_Connection=true;MultipleActiveResultSets=true|TenantTwo |


**Example Content of MT_TenantOne (Table: TenantConfig)**

|Id|Config|
|---|---|
|1|This is the config for TenantOne....|
