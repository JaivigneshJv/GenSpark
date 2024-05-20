# DAY 28 - Log4Net and LINQ

# Log4net in .NET Web API Project

This provides an overview of how to use log4net in a .NET Web API project.

## Installation

To use log4net in your .NET Web API project, follow these steps:

1. Install the log4net NuGet package by running the following command in the Package Manager Console:

    ```
    Install-Package log4net
    ```

2. Add the following configuration to your `app.config` or `web.config` file:

    ```xml
    <log4net>
      <appender name="RollingFile" type="log4net.Appender.FileAppender">
         <file value="app.log" />
         <layout type="log4net.Layout.PatternLayout">
            <conversionPattern value="%-5p %d{hh:mm:ss} %message%newline" />
         </layout>
      </appender>
      <root>
         <level value="ALL" />
         <appender-ref ref="RollingFile" />
      </root>
    </log4net>
    ```

3. In your code, add the following line to initialize log4net:

    ```csharp
    builder.Services.AddLogging(l => l.AddLog4Net());
    ```

4. Use log4net in your code by creating a logger instance and logging messages:

    ```csharp
     [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                _logger.LogCritical(ex.Message); //Logger
                return NotFound(ex.Message);
            }
        }

    ```

## Usage

Once log4net is configured and initialized, you can use it to log messages at different levels (e.g., Info, Debug, Error) and customize the log output format.

For more information on how to use log4net, refer to the official documentation: [log4net Documentation](https://logging.apache.org/log4net/)
