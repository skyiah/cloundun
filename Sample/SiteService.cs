﻿using System;
using Greatbone.Core;

namespace Greatbone.Sample
{
	///
	/// The main website service (WWW).
	///
	public class SiteService : WebService
	{
		public SiteService(WebServiceContext wsc) : base(wsc)
		{
			MountHub<SiteSpaceHub, Space>(null);

			AddSub<SiteCartSub>("cart", null);
		}

		public void Show(WebContext wc)
		{
		}

		public void Contact(WebContext wc)
		{
		}
	}
}