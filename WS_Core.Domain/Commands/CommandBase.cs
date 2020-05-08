using MediatR;

namespace WS_Core.Domain.Commands
{
    public class CommandBase<T> : IRequest<T> where T : class
    {

    }
}
