namespace Library.Core;

public static class Constants
{
    public static class Templates
    {
        public const string ReadMe = nameof(ReadMe);
        public const string GlobalJson = nameof(GlobalJson);
    }

    public static class Metadata
    {
        public const string CleanArchitecture = nameof(CleanArchitecture);
        public const string Core = nameof(Core);
        public const string Infrastructure = nameof(Infrastructure);
        public const string Api = nameof(Api);
        public const string UnitTests = nameof(UnitTests);
        public const string IntegrationTest = nameof(IntegrationTest);
        public const string Testing = nameof(Testing);
        public const string NugetPackage = nameof(NugetPackage);
    }

    public static class Framework
    {
        public const string NetCore = nameof(NetCore);
        public const string NetFramework48 = nameof(NetFramework48);
    }
}
