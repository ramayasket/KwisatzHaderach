﻿using System;
using PostSharp.Aspects;
using Kw.Common;

namespace Kw.Aspects
{
	/// <summary>
	/// Cleans up memory upon executing attributed method.
	/// </summary>
	[Serializable]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class GetTotalMemoryAttribute : MethodInterceptionAspect
	{
		public sealed override void OnInvoke(MethodInterceptionArgs args)
		{
			try
			{
				args.Proceed();
			}
			catch (Exception x)
			{
				args.ReturnValue = x;
			}
			finally
			{
				GC.GetTotalMemory(true);
			}
		}
	}
}
