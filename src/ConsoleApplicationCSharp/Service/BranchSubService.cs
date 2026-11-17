using FluentResults;

namespace Test1.Service;

public class BranchSubService : IBranchSubService
{
    public async Task<Result> ExecuteAsync(CancellationToken cancellationToken)
    {
        return Result.Ok();
    }
}