using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using AppService.MPart;
using WcfService.KnowType;
using System.ServiceModel.Web;
using FrameWork.Application;
using AppService.Base;
using FrameWork.Application.Command;

namespace WcfService
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceKnownType("GetKnownTypes", typeof(MPartKnowType))]
    [SilverlightFaultBehavior]
    //[ServiceBehavior(   UseSynchronizationContext = false,   ConcurrencyMode = ConcurrencyMode.Single,  ReleaseServiceInstanceOnTransactionComplete = true,  InstanceContextMode = InstanceContextMode.PerCall)]
    public class MPartService : ServiceBase, IMPartService
    {

        // 在此处添加更多操作并使用 [OperationContract] 标记它们
        [OperationContract]
        public void DoWork()
        {
            NormalLogger.LogStart(System.Reflection.MethodBase.GetCurrentMethod());
            // 在此处添加操作实现
            return;
        }
        #region IMPartService 成员
        [OperationContract]
        public void ExcuteCommand(AddMPartCommand command)
        {
            string clientid = base.ArgIP;
            NormalLogger.LogStart(clientid, System.Reflection.MethodBase.GetCurrentMethod()); 
            CommandBase cmd = (CommandBase)command;
            cmd.ArgIP = ArgIP; 
            string handlerName = new AppConfigSection().GetSection(command);
            try
            {
                HandlerSwitcher.Execute(command, handlerName);
                base.SaveChanges();
                NormalLogger._LogDebug(command.ToString() + " Executed");
            }
            catch (Exception ex)
            {
                FreeDBContext(); 
                NormalLogger._LogError(command.ToString() + " Throw Error", ex);
                throw ex;
            } 
            NormalLogger.LogEnd(clientid, System.Reflection.MethodBase.GetCurrentMethod());
        }

        #region Search
        [OperationContract]
        public MPartResultDTO GetMPartSearch(MPartParamDTO inputDTO)
        {
            GetMPartSearch searcher = new GetMPartSearch();
            return searcher.DoSearch(inputDTO);
            //throw new NotImplementedException();
        }
        [WebGet()] 
        [OperationContract]
        public void ReturnExceptionSearch()
        {
            ReturnExceptionSearch searcher = new ReturnExceptionSearch();
            searcher.DoSearch();
        }
        #endregion

        #endregion



    }
}
