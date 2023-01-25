using Library.Cli.Commands;
using Library.Core;
using Library.Core.Models.Artifacts;
using Nelibur.ObjectMapper;
using System.Runtime.CompilerServices;

namespace Library.Cli;

public static class ObjectMapperConfiguration
{
    [ModuleInitializer]
    public static void Configure()
    {
        TinyMapper.Bind<DefaultRequest, SolutionReferenceModel>();
        TinyMapper.Bind<AddProjectRequest, ProjectReferenceModel>();
    }
}