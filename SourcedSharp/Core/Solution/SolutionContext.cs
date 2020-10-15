using System;
using Microsoft.Extensions.DependencyInjection;
using SourcedSharp.Core.MessageBroker;

namespace SourcedSharp.Core.Solution
{
    public class SolutionContext
    {
        public IServiceProvider ServiceProvider;

        public SolutionContext(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public CommandRegistrant<TCommandHandler> With<TCommandHandler>()
        {
            ICommandBus commandBus = ServiceProvider.GetService<ICommandBus>();
            return new CommandRegistrant<TCommandHandler>(commandBus);
        }
    }

    public class CommandRegistrant<TCommandHandler>
    {
        private ICommandBus CommandBus;
        public CommandRegistrant(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }

        public CommandRegistrant<TCommandHandler> Handle<TCommand>()
        {
            RegisterCommandHandler<TCommand>();
            return this;
        }


        public void RegisterCommandHandler<TCommand>()
        {
            var commandHandlerType = typeof(TCommandHandler);
            CommandBus.RegisterHandlerFor<TCommand>(commandHandlerType);
        }
    }
}