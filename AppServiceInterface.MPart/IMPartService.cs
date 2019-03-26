using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameWork.Application.Command;
 

namespace AppService.MPart
{
    public interface IMPartService
    {
        /// <summary>
        /// 执行Command
        /// </summary> 
        void ExcuteCommand(AddMPartCommand command);
        /// <summary>
        /// 查询MPart
        /// </summary>
        /// <param name="inputDTO"></param>
        /// <returns></returns>
        MPartResultDTO GetMPartSearch(MPartParamDTO inputDTO);

        void ReturnExceptionSearch();
    }
}
