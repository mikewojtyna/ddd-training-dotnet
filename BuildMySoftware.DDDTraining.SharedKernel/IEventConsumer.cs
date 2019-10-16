namespace BuildMySoftware.DDDTraining.SharedKernel
{
    public interface IEventConsumer
    {
        void Consume(object domainEvent);
    }
}