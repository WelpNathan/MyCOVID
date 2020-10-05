# MyCOVID
**MyCOVID** was my successful attempt of creating a microservice using **Docker and OpenAPI** to create an API which an MVC can connect to. This is my proudest work so far and took me a long time to research! After realising the potential of Docker, all of my future work will be containerised!

The application is based upon Sheffield Hallam's buildings and allows an administrator to contact the microservice which then would be presented to those who are on the presentation layer (MVC). It allows students and staff to see the current coronavirus cases in their building.

# How to launch
It's pretty simple! However, **I haven't made this production compatable**, things like connection strings are hardcoded into the software for simplicity. To launch it, run the following command:

`docker-compose up`

# Additional notes
Please take into consideration the following notes:
- Do not use this as a production system for your business needs, it is completely vulnerable and has no API access keys.
- Connection strings are hardwired in. **(very bad practice!)**
- The database is **SQLite** which is not a good production database for large scale querying.
- This was made as a learning attempt so this may not be stable.
- Coded in .NET Core 3.1 using MVC, WebAPI, Docker, OpenAPI, Swashbuckle.

# The future
I'd love to remake this using more modern technologies such as React.js which is far better than MVC in my opinion. For this reason, there will be no future developments for this project.

# Screenshots

![MVC View](https://github.com/WelpNathan/MyCOVID/blob/master/img/mvc.PNG?raw=true)

![OpenAPI View](https://github.com/WelpNathan/MyCOVID/blob/master/img/swag.PNG?raw=true)