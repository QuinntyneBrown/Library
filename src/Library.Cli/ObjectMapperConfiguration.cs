using Library.Cli.Commands;
using Library.Core;
using Library.Core.Models;
using Nelibur.ObjectMapper;
using System.Runtime.CompilerServices;

namespace Library.Cli;

public static class ObjectMapperConfiguration
{
    [ModuleInitializer]
    public static void Configure()
    {
        TinyMapper.Bind<Default.DefaultRequest, SolutionReferenceModel>();
        TinyMapper.Bind<AddProjectRequestHandler.AddProjectRequest, ProjectReferenceModel>();
        TinyMapper.Bind<CreateWebApi.Request, WebApiProjectReferenceModel>();
    }
}