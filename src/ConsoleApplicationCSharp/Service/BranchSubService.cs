using FluentResults;
using System;
using System.Threading.Tasks;

namespace ConsoleApplicationCSharp.Service;

public class BranchSubService : IBranchSubService
{
    public async Task<Result> ExecuteAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("BranchSubService execution started.");
        await Task.Delay(30000, cancellationToken);
        Console.WriteLine("BranchSubService execution finished.");

        return Result.Ok();
    }
}
