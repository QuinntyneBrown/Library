// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using CommandLine;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var mediator = BuildContainer().GetService<IMediator>();

ProcessArgs(mediator!, args);

static Parser _createParser() => new(options =>
{
    options.CaseSensitive = false;
    options.HelpWriter = Console.Out;
    options.IgnoreUnknownArguments = true;
});

static IServiceProvider BuildContainer()
{
    var host = Host.CreateDefaultBuilder()
        .ConfigureServices(services =>
        {
            services.AddLogging(o => o.AddConsole());

            services.AddCoreServices();

            services.AddInfrastructureServices();

            services.AddCliServices();
        }).Build();

    return host.Services;
}

static void ProcessArgs(IMediator mediator, string[] args)
{
    if (args.Length == 0 || args[0].StartsWith("-"))
    {
        args = new string[1] { "default" }.Concat(args).ToArray();
    }

    var verbs = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(type => type.GetCustomAttributes(typeof(VerbAttribute), true).Length > 0)
        .ToArray();

    _createParser().ParseArguments(args, verbs)
        .WithParsed(
          (dynamic request) => mediator.Send(request));
}

