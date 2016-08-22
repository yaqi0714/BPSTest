﻿using System;
using System.Collections.Generic;

namespace CL.Data.Interface
{
    public interface IUsersInfo
    {
        /// <summary>
        /// 新增
        /// </summary>
        int Add(CL.Data.Model.UsersInfo model);

        /// <summary>
        /// 更新
        /// </summary>
        int Update(CL.Data.Model.UsersInfo model);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<CL.Data.Model.UsersInfo> GetAll();

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.UsersInfo Get(Guid userid);

        /// <summary>
        /// 删除
        /// </summary>
        int Delete(Guid userid);

        /// <summary>
        /// 查询记录条数
        /// </summary>
        long GetCount();
    }
}
