using Microsoft.Extensions.DependencyInjection;

namespace Library.Core.Models.Syntax.Strategies.Abstractions;

public abstract class SyntaxGenerationStrategyBase<T> : ISyntaxGenerationStrategy
    where T : class
{
    protected readonly IServiceProvider _serviceProvider;

    public SyntaxGenerationStrategyBase(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public virtual bool CanHandle(object model, dynamic? context = null) => model is T;

    public virtual string Create(object model, dynamic? context = null)
    {
        using (IServiceScope scope = _serviceProvider.CreateScope())
        {
            var SyntaxGenerationStrategyFactory = scope.ServiceProvider
                .GetRequiredService<ISyntaxGenerationStrategyFactory>();
            return Create(SyntaxGenerationStrategyFactory, model as T, context);
        }
    }

    public abstract string Create(ISyntaxGenerationStrategyFactory SyntaxGenerationStrategyFactory, T model, dynamic? context = null);
    public virtual int Priority => 0;
}
