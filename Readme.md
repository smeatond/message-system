# Quick start

To run the application:

```
docker compose up
```

>Note: requires a `.env` file with `MONGO_INITDB_ROOT_USERNAME` AND `MONGO_INITDB_ROOT_PASSWORD` set. And update the connection string in appsettings.Development.json and appsettings.json

web: http://localhost:8080/
database: http://localhost:27017/