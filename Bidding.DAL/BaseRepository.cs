﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bidding.IDAL;

namespace Bidding.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T :class
    {
        protected BiddingDBContext bContext = ContextFactory.GetCurrentContext();

        public T Add(T entity)
        {
            bContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            bContext.SaveChanges();
            return entity;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return bContext.Set<T>().Count(predicate);
        }

        public bool Update(T entity)
        {
            bContext.Set<T>().Attach(entity);
            bContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return bContext.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            bContext.Set<T>().Attach(entity);
            bContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return bContext.SaveChanges() > 0;
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return bContext.Set<T>().Any(anyLambda);
        }

        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T _entity = bContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var _list = bContext.Set<T>().Where(whereLamdba);
            _list = OrderBy(_list, orderName, isAsc);
            return _list;
        }

        public IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var _list = bContext.Set<T>().Where<T>(whereLamdba);
            totalRecord = _list.Count();
            _list = OrderBy(_list, orderName, isAsc).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            return _list;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="source">原IQueryable</param>
        /// <param name="propertyName">排序属性名</param>
        /// <param name="isAsc">是否正序</param>
        /// <returns>排序后的IQueryable<T></returns>
        private IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc)
        {
            if (source == null) throw new ArgumentNullException("source", "不能为空");
            if (string.IsNullOrEmpty(propertyName)) return source;
            var _parameter = Expression.Parameter(source.ElementType);
            var _property = Expression.Property(_parameter, propertyName);
            if (_property == null) throw new ArgumentNullException("propertyName", "属性不存在");
            var _lambda = Expression.Lambda(_property, _parameter);
            var _methodName = isAsc ? "OrderBy" : "OrderByDescending";
            var _resultExpression = Expression.Call(typeof(Queryable), _methodName, new Type[] { source.ElementType, _property.Type }, source.Expression, Expression.Quote(_lambda));
            return source.Provider.CreateQuery<T>(_resultExpression);
        }

    }
}
