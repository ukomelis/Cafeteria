# Cafeteria

Cafeteria is a application that helps selling products at home cafeteria events, fares, etc.

## TODO

- [ ] - Checkout
- [ ] - Product stock insertion
- [ ] - CSS Improvements
- [ ] - Proper assertion in tests

## Built with

* .NET 6
* Entity Framework Core
* React
* Context API
* PostgreSQL
* docker / docker-compose
* NPM 8.19.3

## Installation

Run docker-compose and database migration commands in root directory of the project to build and start the docker containers for:
* API
* Database
* Website

```bash
docker-compose build
```

```bash
docker-compose up
```
```powershell
./runMigrations.ps1
```

### Known issues
* Slow Website container startup


## Usage

* Frontend - [http://localhost:4200/](http://localhost:4200/)
* API Swagger - [http://localhost:5000/swagger/](http://localhost:5000/swagger/)

## License
[MIT](https://choosealicense.com/licenses/mit/)