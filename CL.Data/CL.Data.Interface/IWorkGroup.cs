using System;
using System.Collections.Generic;

namespace CL.Data.Interface
{
    public interface IWorkGroup
    {
        /// <summary>
        /// 新增
        /// </summary>
        int Add(CL.Data.Model.WorkGroup model);

        /// <summary>
        /// 更新
        /// </summary>
        int Update(CL.Data.Model.WorkGroup model);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<CL.Data.Model.WorkGroup> GetAll();

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.WorkGroup Get(Guid id);

        /// <summary>
        /// 删除
        /// </summary>
        int Delete(Guid id);

        /// <summary>
        /// 查询记录条数
        /// </summary>
        long GetCount();
    }
}
