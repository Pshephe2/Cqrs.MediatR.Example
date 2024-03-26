using Cqrs.MediatR.Example.Data;
using MediatR;

namespace Cqrs.MediatR.Example.Notifications
{
    public record ProductAddedNotification(Product Product) : INotification;

    public class EmailHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDataFactory _fakeDataFactory;

        public EmailHandler(FakeDataFactory fakeDataFactory) => _fakeDataFactory = fakeDataFactory;

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataFactory.EventOccured(notification.Product, "Email sent");
            await Task.CompletedTask;
        }
    }

    public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDataFactory _fakeDataFactory;

        public CacheInvalidationHandler(FakeDataFactory fakeDataFactory) => _fakeDataFactory = fakeDataFactory;

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataFactory.EventOccured(notification.Product, "Cache Invalidated");
            await Task.CompletedTask;
        }
    }
}
