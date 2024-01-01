using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        string logFilePath = "log.txt";

        string logMessage = $"Request received for {context.Request.Path}";

        File.AppendAllText(logFilePath, $"{DateTime.Now} - {logMessage}\n");

        _logger.LogInformation(logMessage);

        await _next(context);
    }
}