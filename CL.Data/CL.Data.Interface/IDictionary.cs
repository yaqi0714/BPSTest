using System;
using System.Collections.Generic;

namespace CL.Data.Interface
{
    public interface IDictionary
    {
        /// <summary>
        /// 新增
        /// </summary>
        int Add(CL.Data.Model.Dictionary model);

        /// <summary>
        /// 更新
        /// </summary>
        int Update(CL.Data.Model.Dictionary model);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<CL.Data.Model.Dictionary> GetAll();

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.Dictionary Get(Guid id);

        /// <summary>
        /// 删除
        /// </summary>
        int Delete(Guid id);

        /// <summary>
        /// 查询记录条数
        /// </summary>
        long GetCount();


        /// <summary>
        /// 查询根记录
        /// </summary>
        CL.Data.Model.Dictionary GetRoot();

        /// <summary>
        /// 查询下级记录
        /// </summary>
        List<CL.Data.Model.Dictionary> GetChilds(Guid id);

        /// <summary>
        /// 查询下级记录
        /// </summary>
        List<CL.Data.Model.Dictionary> GetChilds(string code);

        /// <summary>
        /// 查询上级记录
        /// </summary>
        CL.Data.Model.Dictionary GetParent(Guid id);

        /// <summary>
        /// 是否包含下级记录
        /// </summary>
        bool HasChilds(Guid id);

        /// <summary>
        /// 得到最大排序
        /// </summary>
        int GetMaxSort(Guid id);

        /// <summary>
        /// 更新排序
        /// </summary>
        int UpdateSort(Guid id, int sort);

        /// <summary>
        /// 根据代码查询一条记录
        /// </summary>
        CL.Data.Model.Dictionary GetByCode(string code);
    }
}
