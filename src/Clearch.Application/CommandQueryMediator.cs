using System;
using System.Threading.Tasks;
using Clearch.Application.Abstractions.Commands;
using Clearch.Application.Abstractions.Queries;
using MediatR;

namespace Clearch.Application
{
    internal class CommandQueryMediator : ICommandSender, IQueryProcessor
    {
        private readonly IMediator mediator;
        public CommandQueryMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query)
        {
            return this.mediator.Send(query);
        }

        public Task SendAsync(ICommand command)
        {
            return this.mediator.Send(command);
        }

        public Task<TResult> SendAsync<TResult>(ICommand<TResult> command)
        {
            return this.mediator.Send(command);
        }
    }
}
