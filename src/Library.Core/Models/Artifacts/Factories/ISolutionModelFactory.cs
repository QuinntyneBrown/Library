namespace Library.Core.Models.Artifacts.Factories;

public interface ISolutionModelFactory
{
    SolutionModel CreateWebApi(WebApiProjectReferenceModel webApiProjectReferenceModel);
    SolutionModel CreateLibrary(SolutionReferenceModel solutionReferenceModel);
    SolutionModel CreateWebApi(SolutionReferenceModel solutionReferenceModel);
    SolutionModel ReHydrate(string path);
}
