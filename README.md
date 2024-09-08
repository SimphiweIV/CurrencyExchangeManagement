# CurrencyExchangeManagement
## verview

The Currency Exchange API allows users to convert an amount from one currency to another using real-time exchange rates. It interacts with an external currency exchange API and utilizes Redis caching for efficient performance, along with MySQL for persisting historical exchange rates.

The project demonstrates the use of:
- .NET 6+ Web API
- Dependency Injection
- Redis Caching
- MySQL Database for storing historical rates
- Unit Testing with xUnit and Moq



Before running this project, ensure you have the following installed:

1. **.NET 6+ SDK**: [Download from here](https://dotnet.microsoft.com/download)
2. **Redis**: 
   - You can run Redis locally using [Docker](https://www.docker.com/) or [Windows Subsystem for Linux (WSL)](https://docs.microsoft.com/en-us/windows/wsl/install).
   - Alternatively, you can use [Memurai](https://www.memurai.com/) if you prefer a native Windows Redis implementation.
3. **MySQL Server**: You can install [MySQL](https://dev.mysql.com/downloads/installer/) locally or use [Docker MySQL](https://hub.docker.com/_/mysql).
4. **Postman** (optional, for testing API endpoints): [Download Postman](https://www.postman.com/)
ps://github.com/your-repo-url/CurrencyExchange.git
cd CurrencyExchange

