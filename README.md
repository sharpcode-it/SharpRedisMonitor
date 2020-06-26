# CoreRedisStats
A Web application for real-time monitoring of Redis, developed in ASP.NET Core with Razor Pages, fully compatible for both on-premise and cloud instances. The dashboard is developed with Bootstrap and AdminLTE. This project was born with the aim of giving an alternative to the standard Ruby based redis-stat.

### How it works
**CoreRedisStack** uses StackExchange.Redis as client to Redis instance and retrieves information and statistics in real time by invoking the info command. Statistics are displayed in the main dashboard which currently has the following features:
- CPU status display
- Memory status duplay
- Clients status display
- Real-time operations per sec
- General informations

### Dashboard
![Alt text](/wiki/img/Dashboard.PNG?raw=true)

### How to use it
To use the application, simply edit the appsettings.json file by inserting the connection to the Redis instance.

```json
{
  "Config": {
    "Servers": [
      {
        "Name": "server_name_here",
        "Address": "server_address_here",
        "Port": 6380,
        "Password": "password_here",
        "ConnectionString": "server_connectionstring_here"
      }
    ]
  }, 
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

### StackExchange Reference
https://github.com/StackExchange/StackExchange.Redis

### Contributing
Thank you for considering to help out with the source code!
If you'd like to contribute, please fork, fix, commit and send a pull request for the maintainers to review and merge into the main code base.

**Getting started with Git and GitHub**

 * [Setting up Git for Windows and connecting to GitHub](http://help.github.com/win-set-up-git/)
 * [Forking a GitHub repository](http://help.github.com/fork-a-repo/)
 * [The simple guide to GIT guide](http://rogerdudler.github.com/git-guide/)
 * [Open an issue](https://github.com/engineering87/CoreRedisStats/issues) if you encounter a bug or have a suggestion for improvements/features

### Licensee
CoreRedisStats source code is available under MIT License, see license in the source.

### Contact
Please contact at francesco.delre.87[at]gmail.com for any details.
