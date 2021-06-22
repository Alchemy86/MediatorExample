namespace MediatorFromScratch.Sample
{
    public class PrintToConsoleRequest : IRequest<bool>
    {
        public string Text { get; init; }
    }
}