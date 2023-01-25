namespace Library.Core.Models.Artifacts.Strategies.Solution.Update
{
    public interface ISolutionUpdateStrategy
    {
        int Order { get; }
        bool CanHandle(ProjectModel model);

        void Update(SolutionModel previous, SolutionModel next);
    }
}
