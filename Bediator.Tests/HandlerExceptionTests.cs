using System;
using Bediator.Tests.Exceptions;
using Bediator.Tests.Handlers;
using Bediator.Tests.Interfaces;
using Bediator.Tests.Messages;
using Bediator.Tests.Services;
using Xunit;

namespace Bediator.Tests
{
    public class HandlerExceptionTests
    {
        [Fact]
        public async void HandlerShouldThrowSpecificException()
        {
            var bdiator = new BDiator(new HandlerProvider());
            bdiator.Subscribe<IEventHandler<IEvent>, IEvent>();

            ExceptionHandlerException exception =
                await Assert.ThrowsAsync<ExceptionHandlerException>(async () =>
                    await bdiator.HandleAsync(new ExceptionEvent()));

            Assert.Equal(exception.Message, "Handler has thrown exception!");
        }

        [Fact]
        public async void NoHandlerRegisteredException()
        {
            var bdiator = new BDiator(new HandlerProvider());
            bdiator.Subscribe<IEventHandler<IEvent>, IEvent>();

            ApplicationException exception =
                await Assert.ThrowsAsync<ApplicationException>(async () =>
                    await bdiator.HandleAsync(new UnregisteredEvent()));
            Assert.Equal($"Handler for type {typeof(UnregisteredEventHandler)} not implemented!", exception.Message);
        }

        [Fact]
        public async void WrongHandlerRegisteredException()
        {
            var bdiator = new BDiator(new HandlerProvider());
            bdiator.Subscribe<IMessageHandler<IMessage>, IMessage>();

            ApplicationException exception =
                await Assert.ThrowsAsync<ApplicationException>(async () =>
                    await bdiator.HandleAsync(new UnregisteredEvent()));
            Assert.Equal($"There was no handler registered for message type {typeof(UnregisteredEvent)}",
                exception.Message);
        }

        [Fact]
        public async void MessageNullException()
        {
            var bdiator = new BDiator(new HandlerProvider());
            bdiator.Subscribe<IMessageHandler<IMessage>, IMessage>();

            ArgumentNullException exception =
                await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                    await bdiator.HandleAsync<UnregisteredEvent>(null));
        }

        [Fact]
        public async void FaultyHandlerTest()
        {
            var bdiator = new BDiator(new HandlerProvider());
            bdiator.Subscribe<IFaultyHandler<IEvent>, IEvent>();

            ApplicationException exception =
                await Assert.ThrowsAsync<ApplicationException>(async () =>
                    await bdiator.HandleAsync(new FaultyEvent()));

            Assert.Equal($"Handler {typeof(TestFaultyHandler)} should have a 'Handle' method!", exception.Message);
        }
    }
}