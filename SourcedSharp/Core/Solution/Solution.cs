using System;
using Microsoft.Extensions.DependencyInjection;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.MessageBroker;
using SourcedSharp.Core.Messages.Commands;
using SourcedSharp.Core.Projections;
using SourcedSharp.Implementations.Bus.rabbitMQ;
using CommandBus = SourcedSharp.Core.MessageBroker.CommandBus;

namespace SourcedSharp.Core.Solution
{
    public class Solution
    {
        public IServiceProvider ServiceProvider;

        public SolutionContext SolutionContext => ServiceProvider.GetService<SolutionContext>();
        public ICommandBus CommandBus => ServiceProvider.GetService<ICommandBus>();
        public IQueryBus QueryBus => ServiceProvider.GetService<IQueryBus>();
        public IEventBus EventBus => ServiceProvider.GetService<IEventBus>();
        public IEventStore EventStore => ServiceProvider.GetService<IEventStore>();

        public Solution()
        {
            var eventStore = new EventStore.EventStore();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<SolutionContext>();
            serviceCollection.AddSingleton<ICommandBus>(new CommandBus(eventStore));
            serviceCollection.AddSingleton<IQueryBus>(new QueryBus());
            serviceCollection.AddSingleton<IEventBus>(new EventBus());
            serviceCollection.AddSingleton<IEventStore>(eventStore);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            ProjectorFactory.Init(EventStore);
        }
        public Solution AddContext<TContext>()
        {
            var context = Activator.CreateInstance(typeof(TContext), SolutionContext);
            return this;
        }

        public void ExecuteCommand(ICommand command)
        {
            CommandBus.ExecuteCommand(command);
        }
    }
}