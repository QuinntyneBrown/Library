// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Library.Cli.Commands;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddCliServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(SolutionCreateRequest));

        services.AddLogging();
    }

}

