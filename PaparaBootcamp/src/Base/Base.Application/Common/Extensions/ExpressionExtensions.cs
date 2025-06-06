﻿using System.Linq.Expressions;

namespace Base.Application.Common.Extensions;

public static class ExpressionExtensions
{
	public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
	{
		var parameter = Expression.Parameter(typeof(T));
		var body = Expression.AndAlso(
			Expression.Invoke(expr1, parameter),
			Expression.Invoke(expr2, parameter));
		return Expression.Lambda<Func<T, bool>>(body, parameter);
	}

	public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
	{
		var parameter = Expression.Parameter(typeof(T));
		var body = Expression.OrElse(
			Expression.Invoke(expr1, parameter),
			Expression.Invoke(expr2, parameter));
		return Expression.Lambda<Func<T, bool>>(body, parameter);
	}

	public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expr)
	{
		var parameter = Expression.Parameter(typeof(T));
		var body = Expression.Not(Expression.Invoke(expr, parameter));
		return Expression.Lambda<Func<T, bool>>(body, parameter);
	}

	//public static Expression<Func<T, bool>> OrExpression(Expression<Func<T, bool>> filter, Expression<Func<T, bool>> newExp)
	//{
	//	var param = Expression.Parameter(typeof(T), "x");
	//	var body = Expression.Or(Expression.Invoke(filter, param), Expression.Invoke(newExp, param));
	//	filter = Expression.Lambda<Func<T, bool>>(body, param);
	//	return filter;
	//}
}