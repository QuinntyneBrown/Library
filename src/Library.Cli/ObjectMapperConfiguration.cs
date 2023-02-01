// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Library.Cli.Commands;
using Library.Core.Models.Artifacts;
using Nelibur.ObjectMapper;
using System.Runtime.CompilerServices;

namespace Library.Cli;

public static class ObjectMapperConfiguration
{
    [ModuleInitializer]
    public static void Configure()
    {
        TinyMapper.Bind<SolutionCreateRequest, SolutionReferenceModel>();
    }
}
