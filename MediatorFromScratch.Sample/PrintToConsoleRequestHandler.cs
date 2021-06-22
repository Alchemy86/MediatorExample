using System;
using System.Threading.Tasks;

namespace MediatorFromScratch.Sample
{
    public class PrintToConsoleRequestHandler : IHandler<PrintToConsoleRequest, bool>
    {
        public Task<bool> HandleAsync(PrintToConsoleRequest request)
        {
            Console.WriteLine(request.Text);
            return Task.FromResult(true);
        }
    }
}
