using FluentResults;

namespace Test1.Service;

public interface IBranchSubService
{
    Task<Result> ExecuteAsync(CancellationToken cancellationToken);
}