﻿using Greatbone.Core;

namespace Greatbone.Sample
{
	///
	/// /fame/-/
	///
	public class FameVarHub : WebVarHub
	{
		public FameVarHub(WebBuild cfg) : base(cfg)
		{
		}


		public override void @default(WebContext wc, string x)
		{
			throw new System.NotImplementedException();
		}
	}
}