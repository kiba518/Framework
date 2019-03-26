using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppService.Base;
using FrameWork.Application;

namespace AppService.MPart 
{
    public class GetMPartSearch : SearchBase
    {
        /// <summary>
        /// 执行查询 
        /// </summary>
        /// <param name="inputDTO">传入参数</param>
        /// <returns></returns>
        public MPartResultDTO DoSearch(MPartParamDTO inputDTO)
        {
            NormalLogger.LogStart(System.Reflection.MethodBase.GetCurrentMethod()); 
            if (inputDTO.PageIndex == -1)//完整显示 
            {
                MPartResultDTO ResultDTO = new MPartResultDTO();
                //完整显示查询记录数量
               
                //定义Sql语句
                string SqlQueryStr = "Select * From MDS_T_MPart Where 1=1 ";
                //完善Sql语句的条件
                SqlQueryStr += SetSqlCondition(inputDTO);
                //排序
                SqlQueryStr += "  Order by MPartNumber Desc";
                List<Base_MPart> MPartList = this.SqlQuery<Base_MPart>(SqlQueryStr).ToList();
                ResultDTO.MPartList = MPartList;
                ResultDTO.TotalCount = MPartList.Count();
                return ResultDTO;
            }
            else if (inputDTO.PageIndex > 0)//分页显示
            {
                MPartResultDTO ResultDTO = new MPartResultDTO();
                //获取Sql查询条件
                string SqlCondition = SetSqlCondition(inputDTO);
                //设置排序
                string OrderbyStr = "MPartNumber";
                //设置RowNumber分页查询Sql
                string SqlQueryStr = SetSqlRowNumber(SqlCondition, "MDS_T_MPart", OrderbyStr, inputDTO.PageIndex);

                List<Base_MPart> MPartList = this.SqlQuery<Base_MPart>(SqlQueryStr).ToList();
                ResultDTO.MPartList = MPartList;

                //设置查询总数Sql
                string SqlQueryCountStr = "Select  Count(*) From MDS_T_MPart Where 1=1 " + SqlCondition;
                List<int> Count = base.SqlQuery<int>(SqlQueryCountStr).ToList();
                ResultDTO.TotalCount = Count.First();

                return ResultDTO;
            }
            else
            {
                return null;
            }
            NormalLogger.LogEnd( System.Reflection.MethodBase.GetCurrentMethod());
        }
        /// <summary>
        /// 设置Sql条件
        /// </summary>
        /// <param name="inputDTO"></param>
        /// <returns></returns>
        public string SetSqlCondition(MPartParamDTO inputDTO)
        {
            string SqlQueryStr = "";
            if (!string.IsNullOrEmpty(inputDTO.MPartNumber))
            {
                SqlQueryStr += " And MPartNumber like '%" + inputDTO.MPartNumber + "%'";
            }
            
            if (inputDTO.CreateTimeEndPoint != null)
            {
                SqlQueryStr += " And CreateTime <='" + inputDTO.CreateTimeEndPoint + "'";
            }
            if (inputDTO.CreateTimeStartPoint != null)
            {
                SqlQueryStr += " And CreateTime >='" + inputDTO.CreateTimeStartPoint + "'";
            }
           

            return SqlQueryStr;
        }
        /// <summary>
        /// 设置RowNumber
        /// </summary>
        /// <param name="SqlCondition">查询条件</param>
        /// <param name="Table">表名</param>
        /// <param name="OrderBy">排序字段</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="NameSpace">命名空间</param>
        /// <returns></returns>
        public string SetSqlRowNumber(string SqlCondition, string Table, string OrderBy, int PageIndex )
        { 
            int PageSize = this.PageSizePaging(System.Reflection.MethodBase.GetCurrentMethod());
            string SqlStr = "Select  *  From " +
                "(SELECT  * ,ROW_NUMBER() OVER( Order By " + OrderBy + " Desc ) AS RowNumber " +
                     " FROM " + Table + " WHERE 1=1 " + SqlCondition +
                ")  AS RowNumberTableSource" +
                " WHERE RowNumber BETWEEN " + ((PageIndex - 1) * PageSize + 1).ToString() + " And " + (PageIndex * PageSize).ToString();

            return SqlStr;
        }

    }
}
