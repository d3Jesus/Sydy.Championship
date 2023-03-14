# Sydy Championship

## Introduction
Sydy Championship is a development project as part of the evaluation during the application process for the C# Backend Developer Vacancy at Sydy.

## Table of Contents

- [Aims](#aim)
- [Built With](#built-with)
- [Endpoints](#endpoints)
    - [Taem](#team)
    - [Championship](#championship)
- [How to use](#how-to-use)
    - [Connection String](#connection-string)
    - [Database](#database)
- [Author](#author)

## Aims
The project aims to develop an API that could manage the registered teams (create, read, update, delete) and perform championships. In these championships, the score is made randomly and at the end of each, the following must be presented:

* The champion
* The second place
* The third place

And, the score obteined in each match based on the result:

* Defeat = 0
* Tie = 1
* Winner = 3

## Built with

* [.Net Core v6.0.301](https://dotnet.microsoft.com/en-us/download)
* [Entity Framework Core v7.0.3](https://docs.microsoft.com/en-us/ef/core/get-started/overview/install)
* [SQL Server](https://www.postgresql.org/)

## Endpoints
### Team

* GET: /api/Team
    - Get all registered teams.

    - RESPONSE
    ```
    {
        "responseData": [
            {
                "id": 1,
                "name": "Barcelona"
            },
            {
                "id": 2,
                "name": "Man City"
            },
            {
                "id": 3,
                "name": "Man United"
            },
            {
                "id": 4,
                "name": "Juventos"
            }
        ],
        "succeeded": true,
        "message": ""
    }
    ```

* GET: /api/Team/{id}
    - Get registered team by ID.

    ```
    {
        "responseData": [
            {
                "id": 1,
                "name": "Barcelona"
            }
        ],
        "succeeded": true,
        "message": ""
    }
    ```

* GET: /api/Team/{pageNumber}/{itemsPerPage}
    - Get registered team by ID.

    * RESPONSE
    ```
    {
        "pageNumber": 1,
        "itemsPerPage": 2,
        "totalPages": 2,
        "items": [
            {
            "id": 1,
            "name": "Barcelona"
            },
            {
            "id": 2,
            "name": "Man City"
            }
        ]
    }
    ```

* POST: /api/Team

    - Register new team.
    ```
    {
        "name": "Juventus"
    }
    ```

* PUT: /api/Team
    - Update existing team.
    ```
    {
        "id": 4,
        "name": "Juventos"
    }
    ```

    - RESPONSE
    ```
    {
        "responseData": {
            "id": 4,
            "name": "Juventus"
        },
        "succeeded": true,
        "message": "Team updated!"
    }
    ```

* DELETE: /api/Team/{id}
    - Delete team by it's id as parameter.

    - RESPONSE
    ```
    {
        "responseData": false,
        "succeeded": false,
        "message": "Team deleted successfuly."
    }
    ```

### Championship
* GET: /api/Championship

    * Get all matches. Use this if you want to implement your own pagination actions.

    - RESPONSE
    ```
    {
        "responseData": [
        {
            "name": "Serie A",
            "year": 2023,
            "champion": "Barcelona",
            "vice": "Juventus",
            "thirdPlace": "Man City",
            "matchesResult": [
                {
                "teams": "Barcelona x Man City",
                "results": "7 x 9",
                "date": "2023-03-13T16:57:44.0248147"
                },
                {
                "teams": "Barcelona x Man United",
                "results": "1 x 0",
                "date": "2023-03-13T16:57:44.0883165"
                },
                {
                "teams": "Barcelona x Juventus",
                "results": "9 x 8",
                "date": "2023-03-13T16:57:44.0936021"
                },
                {
                "teams": "Man City x Man United",
                "results": "1 x 3",
                "date": "2023-03-13T16:57:44.0978405"
                },
                {
                "teams": "Man City x Juventus",
                "results": "0 x 10",
                "date": "2023-03-13T16:57:44.1038302"
                },
                {
                "teams": "Man United x Juventus",
                "results": "6 x 9",
                "date": "2023-03-13T16:57:44.1081344"
                }
            ]
            }
        ],
        "succeeded": true,
        "message": ""
    }
    ```

* POST: /api/Championship

    * Register a new championship
    ```
    {
        "name": "Serie A"
    }
    ```

    * RESPONSE
    ```
    {
        "responseData": null,
        "succeeded": true,
        "message": "Championship created successfuly and starded!"
        }
    ```

* GET: /api/Championship/{championshipName}
    * Filter the championships and get by name

    - RESPONSE
    ```
    {
        "responseData": [
        {
            "name": "Serie A",
            "year": 2023,
            "champion": "Barcelona",
            "vice": "Juventus",
            "thirdPlace": "Man City",
            "matchesResult": [
                {
                "teams": "Barcelona x Man City",
                "results": "7 x 9",
                "date": "2023-03-13T16:57:44.0248147"
                },
                {
                "teams": "Barcelona x Man United",
                "results": "1 x 0",
                "date": "2023-03-13T16:57:44.0883165"
                },
                {
                "teams": "Barcelona x Juventus",
                "results": "9 x 8",
                "date": "2023-03-13T16:57:44.0936021"
                },
                {
                "teams": "Man City x Man United",
                "results": "1 x 3",
                "date": "2023-03-13T16:57:44.0978405"
                },
                {
                "teams": "Man City x Juventus",
                "results": "0 x 10",
                "date": "2023-03-13T16:57:44.1038302"
                },
                {
                "teams": "Man United x Juventus",
                "results": "6 x 9",
                "date": "2023-03-13T16:57:44.1081344"
                }
            ]
            }
        ],
        "succeeded": true,
        "message": ""
    }
    ```

* GET: /api/Championship/{championshipYear}
    * Filter the championships and get by year

    - RESPONSE
    ```
    {
        "responseData": [
        {
            "name": "Serie A",
            "year": 2023,
            "champion": "Barcelona",
            "vice": "Juventus",
            "thirdPlace": "Man City",
            "matchesResult": [
                {
                "teams": "Barcelona x Man City",
                "results": "7 x 9",
                "date": "2023-03-13T16:57:44.0248147"
                },
                {
                "teams": "Barcelona x Man United",
                "results": "1 x 0",
                "date": "2023-03-13T16:57:44.0883165"
                },
                {
                "teams": "Barcelona x Juventus",
                "results": "9 x 8",
                "date": "2023-03-13T16:57:44.0936021"
                },
                {
                "teams": "Man City x Man United",
                "results": "1 x 3",
                "date": "2023-03-13T16:57:44.0978405"
                },
                {
                "teams": "Man City x Juventus",
                "results": "0 x 10",
                "date": "2023-03-13T16:57:44.1038302"
                },
                {
                "teams": "Man United x Juventus",
                "results": "6 x 9",
                "date": "2023-03-13T16:57:44.1081344"
                }
            ]
            }
        ],
        "succeeded": true,
        "message": ""
    }
    ```

* GET: /api/Championship/{championshipName}/{championshipYear}
    * Filter the championships and get by name and year

    - RESPONSE
    ```
    {
        "responseData": [
        {
            "name": "Serie A",
            "year": 2023,
            "champion": "Barcelona",
            "vice": "Juventus",
            "thirdPlace": "Man City",
            "matchesResult": [
                {
                "teams": "Barcelona x Man City",
                "results": "7 x 9",
                "date": "2023-03-13T16:57:44.0248147"
                },
                {
                "teams": "Barcelona x Man United",
                "results": "1 x 0",
                "date": "2023-03-13T16:57:44.0883165"
                },
                {
                "teams": "Barcelona x Juventus",
                "results": "9 x 8",
                "date": "2023-03-13T16:57:44.0936021"
                },
                {
                "teams": "Man City x Man United",
                "results": "1 x 3",
                "date": "2023-03-13T16:57:44.0978405"
                },
                {
                "teams": "Man City x Juventus",
                "results": "0 x 10",
                "date": "2023-03-13T16:57:44.1038302"
                },
                {
                "teams": "Man United x Juventus",
                "results": "6 x 9",
                "date": "2023-03-13T16:57:44.1081344"
                }
            ]
            }
        ],
        "succeeded": true,
        "message": ""
    }
    ```
* GET: /api/Championship/{pageNumber}/{itemsPerPage}
    - Get registered championships with pagination.

    * RESPONSE
    ```
    {
        "pageNumber": 1,
        "itemsPerPage": 1,
        "totalPages": 1,
        "items": [
            {
                "name": "Serie A",
                "year": 2023,
                "champion": "Barcelona",
                "vice": "Juventus",
                "thirdPlace": "Man City",
                "matchesResult": [
                    {
                        "teams": "Barcelona x Man City",
                        "results": "7 x 9",
                        "date": "2023-03-13T16:57:44.0248147"
                    },
                    {
                        "teams": "Barcelona x Man United",
                        "results": "1 x 0",
                        "date": "2023-03-13T16:57:44.0883165"
                    },
                    {
                        "teams": "Barcelona x Juventus",
                        "results": "9 x 8",
                        "date": "2023-03-13T16:57:44.0936021"
                    },
                    {
                        "teams": "Man City x Man United",
                        "results": "1 x 3",
                        "date": "2023-03-13T16:57:44.0978405"
                    },
                    {
                        "teams": "Man City x Juventus",
                        "results": "0 x 10",
                        "date": "2023-03-13T16:57:44.1038302"
                    },
                    {
                        "teams": "Man United x Juventus",
                        "results": "6 x 9",
                        "date": "2023-03-13T16:57:44.1081344"
                    }
                ]
            }
        ]
    }
    ```

* GET: /api/Championship/{championshipName}/{championshipYear}/{pageNumber}/{itemsPerPage}
    - Get registered championships by name and year(optional) with pagination.

    * RESPONSE
    ```
    {
        "pageNumber": 1,
        "itemsPerPage": 1,
        "totalPages": 6,
        "items": [
            {
                "name": "string",
                "year": 2023,
                "champion": "Barcelona",
                "vice": "Man City",
                "thirdPlace": "Juventos",
                "matchesResult": [
                    {
                        "teams": "Barcelona x Man City",
                        "results": "4 x 1",
                        "date": "2023-03-13T12:31:06.0198795"
                    }
                ]
            }
        ]
    }
    ```

## How to use
### Connection String

 * The connection string must be set in the environment variables. If you dont't know how to do it, [check this article.](https://docs.oracle.com/en/database/oracle/machine-learning/oml4r/1.5.1/oread/creating-and-modifying-environment-variables-on-windows.html#GUID-DD6F9982-60D5-48F6-8270-A27EC53807D0)

### Database

1. Open your terminal ou command prompt or Package Manager Console
2. Add Migrations
3. Update database
4. Run the script located in: Sydy.Championship/Sydy.Championship.Infrastructure/Data/Scripts/Sydy.Championship.DB-0.7.0.sql
5. That's all.

## Author
- [Yuran de Jesus](https://github.com/d3Jesus)