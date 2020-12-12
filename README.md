# SearchProducts
Blazor - Clean Arquitecture App for Products Searchs

Hi, this is a Blazor project with an API in Azure Functions and Clean Arquitecture. To Build this, you need Visual Studio (2019 preferably) and setup a Container with MongoDB a database (all files are found in /products-db-master);

Windows:
docker run -d --rm -e MONGO_INITDB_ROOT_USERNAME=productListUser -e MONGO_INITDB_ROOT_PASSWORD=productListPassword -p 27017:27017 --name mongodb-local -v C:/Users/PabloAlcaino/source/repos/ProductsSearch/products-db-master/database:/database mongo:3.6.8
docker exec mongodb-local bash -c "./database/import.sh localhost"

TODO: 
-Pagination Products
   Sets pagination on products API endpoint and page to reduce overload.
-Move MongoDBHelper Connection String 
   To a secure place like Azure Key Vault
-Fix Docker Containers Build
   There are some issues running Containers on Visual studio with windows and Azure Functions.
