//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using HEDS.AppServiceInterface.GeneralFunctions;
//using HEDS.AppServiceInterface.BasicDataMaintenance;
//using HEDS.AppServiceInterface.NumberEbomDesign;
//using HEDS.AppServiceInterface.NumberEbomDesign.Command;
//using HEDS.AppServiceInterface.QueryManage;
//using HEDS.AppServiceInterface.SubLineTaskManage;

//namespace HEDS.WCFService
//{
//    public class HandlerSwitcherHepler
//    {
//        public static IEnumerable<Type> GetKnownTypes()
//        {
//            System.Collections.Generic.List<System.Type> knownTypes =
//              new System.Collections.Generic.List<System.Type>();

//            knownTypes.Add(typeof(GfPartReportExportCommand));
//            knownTypes.Add(typeof(GfExportDetailTableCommand));
//            //knownTypes.Add(typeof(DownloadDrawingCommand));
//            //knownTypes.Add(typeof(CheckImportedPartExcelCommand));
//            //knownTypes.Add(typeof(CheckImportedBomExcelCommand));
//            knownTypes.Add(typeof(GfPartVerCompareCommand));
//            knownTypes.Add(typeof(GfExportExcelCommand));
//            //knownTypes.Add(typeof(GfPartReportExportCommand));
//            //knownTypes.Add(typeof(UnFoldDeleteDrawingCommand));
//            //knownTypes.Add(typeof(UnFoldDownloadingDrawingCommand));
//            //knownTypes.Add(typeof(ExportRandomFileInfo));
//            knownTypes.Add(typeof(WorkNoCompareCommand));
//            //knownTypes.Add(typeof(GfPartReportExportCommand));
//            //knownTypes.Add(typeof(AutoLogSearch));
//            knownTypes.Add(typeof(GfPartBomViewChangeOrderCommand));
//            knownTypes.Add(typeof(GfWorkNoViewChangeOrderCommand));
//            knownTypes.Add(typeof(ExportRandomFileInfoCommand));

//            knownTypes.Add(typeof(VersionCompareCommand));
//            knownTypes.Add(typeof(ViewSublineReportCommand));
            
//            return knownTypes;
//        }
//    }
//}