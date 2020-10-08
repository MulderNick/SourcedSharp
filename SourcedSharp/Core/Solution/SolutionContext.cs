using System;
using SourcedSharp.Implementations.Bus;
using SourcedSharp.Implementations.Bus.rabbitMQ;

namespace SourcedSharp.Core.Solution
{
    public class SolutionContext
    {
        private CommandBus CommandBus;
        private EventBus EventBus; //?
        private QueryBus QueryBus; //?

        public CommandRegistrant<TCommandHandler> With<TCommandHandler>()
        {
            return new CommandRegistrant<TCommandHandler>(CommandBus);
        }
    }

    public class CommandRegistrant<TCommandHandler>
    {
        private CommandBus CommandBus;
        public CommandRegistrant(CommandBus commandBus)
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
            var commandProcessor = "lambdaFunction";
            //CommandBus.RegisterHandlerFor<TCommand>();
        }
    }
}