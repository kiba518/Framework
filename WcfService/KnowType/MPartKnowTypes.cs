using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using AppService.MPart;
using AppService.Base;
using FrameWork.Application.Command;

namespace WcfService.KnowType
{
    public class MPartKnowType
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            System.Collections.Generic.List<System.Type> knownTypes =
                new System.Collections.Generic.List<System.Type>();
            // Add any types to include here.
            knownTypes.Add(typeof(MPartParamDTO));
            knownTypes.Add(typeof(MPartResultDTO));
            knownTypes.Add(typeof(Base_MPart));

            knownTypes.Add(typeof(ICommand));
            knownTypes.Add(typeof(AddMPartCommand)); 
            return knownTypes;
        }
    }
}