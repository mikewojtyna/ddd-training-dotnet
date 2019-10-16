namespace BuildMySoftware.DDDTraining.SharedKernel
{
    public interface IEventPublisher
    {
        void publishEvent(object domainEvent);
    }
}