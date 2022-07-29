using Library.Application.Commands;
using Library.Core.Options;
using Nelibur.ObjectMapper;
using System.Runtime.CompilerServices;

namespace Library.Application
{
    public static class ObjectMapperConfiguration
    {
        [ModuleInitializer]
        public static void Configure()
        {
            TinyMapper.Bind<Default.Request, CreateSolutionOptions>();
            TinyMapper.Bind<AddProject.Request, AddProjectOptions>();
            TinyMapper.Bind<CreateWebApi.Request, CreateWebApiOptions>();
        }
    }
}
