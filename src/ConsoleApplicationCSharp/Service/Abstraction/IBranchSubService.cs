using FluentResults;

namespace ConsoleApplicationCSharp.Service;

public interface IBranchSubService
{
    Task<Result> ExecuteAsync(CancellationToken cancellationToken);
}
