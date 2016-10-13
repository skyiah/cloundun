﻿using System;
using Greatbone.Core;

namespace Greatbone
{
    public class IfSelfAttribute : IfAttribute
    {
        public override bool Check(WebContext wc)
        {
            return true;
        }

        public override bool Check(WebContext wc, string var)
        {
            return true;
        }
    }
}