using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameWork.Application.Attributes;

namespace FrameWork.Application.Command
{
    /// <summary>
    /// Represents that the implemented classes are command handlers.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command to be handled.</typeparam>
    [RegisterDispatch]
    public interface ICommandHandler<TCommand> : IHandler<TCommand>
        where TCommand : ICommand
    {

    }
}
