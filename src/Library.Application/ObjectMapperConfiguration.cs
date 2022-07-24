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
            TinyMapper.Bind<Default.Request, CreateLibraryOptions>();
        }
    }
}
