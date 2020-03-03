# hangfire-docker

### Hangfire on ASP.NET Core and PostgreSQL on Docker

  

To see the results. Go to project’s root folder and run

```
$ docker-compose up --build
```

The docker-compose will build all images and run them. 
Next, you can go to [http://localhost:5300/hangfire/](http://localhost:5300/hangfire/)

PostgreSQL database will be at port 5432. In case we want to look any data in Postgre we use the adminer(Database management) image. 
So we can go to [[http://localhost:8080/](http://localhost:8080/)] and login using:

server: 'db';
user: 'postgres';
pass: 'postgres';
databse: 'hangfire-db';
