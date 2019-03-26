using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Domain.ServiceBase;

namespace WcfService
{
    public class ServiceBase : DataContextBase
    {
        /// <summary>
        /// IP
        /// </summary>
        public string ArgIP { get; set; }

        public ServiceBase()
        {
            var context = OperationContext.Current;
            var properties = context.IncomingMessageProperties;   //获取传进的消息属性   
            var endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty; //获取消息发送的远程终结点IP和端口   
            ArgIP = endpoint.Address;
        }

        internal void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}