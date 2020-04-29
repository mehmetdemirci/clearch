using System;
using System.Threading.Tasks;
using Clearch.Application.Abstractions;
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

        public Task<IResult<TResult>> ProcessAsync<TResult>(IQuery<TResult> query)
        {
            return this.mediator.Send(query);
        }

        public Task<IResult> SendAsync(ICommand command)
        {
            return this.mediator.Send(command);
        }

        public Task<IResult<TResult>> SendAsync<TResult>(ICommand<TResult> command)
        {
            return this.mediator.Send(command);
        }
    }
}
