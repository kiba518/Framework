using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameWork.Application.Command
{
    /// <summary>
    /// Represents that the implemented classes are message handlers.
    /// </summary>
    /// <typeparam name="T">The type of the message to be handled.</typeparam>
    public interface IHandler<T>
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message to be handled.</param>
        bool Handle(T message);
    }
}
