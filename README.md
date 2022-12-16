# Building Multi-Tenant Applications Using ASP.NET 6

### Run / Debug
``` 
docker-compose up
```

### API Urls

- Auth API: http://localhost:8000/swagger/index.html
- Tenant API: http://localhost:7000/swagger/index.html

### Requirements
- .NET Core 6 Runtime 
-  Docker & Docker Compose 
-  SQL Server
-  Swaggwer

### Users

```bash
CompanyId: 1 
Email: testcompany1@gmail.com 
----------
CompanyId: 2 
Email: testcompany2@gmail.com 
----------
CompanyId: 3 
Email: testcompany3@gmail.com 

Password for all accounts: 123456789!!
```