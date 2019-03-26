using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
 
using FrameWork.Application.Command;


namespace AppService.Base
{
    [DataContract]
    public abstract class CommandBase : Command
    {
        #region abstract fields
        //[DataMember]
        //public abstract CommandType MyCommandType { get; set; }
        #endregion

        #region public fields
        [DataMember]
        public string UserNo { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string ArgIP { get; set; }

        #endregion

    }

    [DataContract]
    public class CommandExceptionBase : ApplicationException
    {
        [DataMember]
        public string ErrorCode;

        [DataMember]
        public string Message;

        [DataMember]
        public bool IsSccess;

        public CommandExceptionBase(string Message, string ErrorCode, bool IsSccess, Exception inner)
            : base(Message, inner)
        {
            this.Message = Message;
            this.ErrorCode = ErrorCode;
            this.IsSccess = IsSccess;
        }
    }
}
