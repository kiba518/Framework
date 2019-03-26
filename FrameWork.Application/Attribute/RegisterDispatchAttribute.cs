using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameWork.Application.Attributes
{
    /// <summary>
    /// Represents that the instances of the decorated interfaces
    /// can be registered in a message dispatcher.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class RegisterDispatchAttribute : Attribute
    {
    }
}
