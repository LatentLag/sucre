This project uses ASP.NET minimal API's.
To facilitate testing I'm added a lightweight handler.
It's not quite a controller because the minimal API maps the HTTP request and it's not quite a service because handlers return an IResult.
