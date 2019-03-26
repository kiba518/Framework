using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppService.MPart;
using FrameWork.Application.Command;
using Domain.MPartService;
using Domain.MPartService.ParamObject;
using AutoMapper;
using AppService.Base;
namespace AppServiceImpl.MPart
{
    public class AddMPartCommandHandler : CommandHandler<AddMPartCommand>
    {
        public AddMPartCommandHandler()
            : base()
        {
        }
        public override bool Handle(AddMPartCommand command)
        {
            MPartService service = new MPartService();
            Domain.MPartService.ParamObject.MPart addMPart = new Domain.MPartService.ParamObject.MPart();
            addMPart = MappingObject(command.MPart);
             
            service.AddMPart(addMPart);
            return true;
        }
        /// <summary>
        /// 映射函数
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public Domain.MPartService.ParamObject.MPart MappingObject(Base_MPart Source)
        {
            //建立映射关系 
            Mapper.CreateMap<Base_MPart, Domain.MPartService.ParamObject.MPart>();
         

            //映射实体
            return Mapper.Map<Base_MPart, Domain.MPartService.ParamObject.MPart>(Source);
        }
    }
}
