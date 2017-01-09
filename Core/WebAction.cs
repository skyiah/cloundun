﻿using System;
using System.Reflection;

namespace Greatbone.Core
{
    ///
    /// The descriptor for an action method.
    ///
    public class WebAction : WebControl, IRollable
    {
        readonly WebFolder folder;

        readonly string name;

        readonly Action<WebActionContext> doer;

        readonly Action<WebActionContext, string> doer2;

        readonly UiAttribute ui;

        internal WebAction(WebFolder folder, MethodInfo mi, bool arg = false) : base(mi)
        {
            this.folder = folder;
            name = mi.Name;
            if (arg)
            {
                doer2 = (Action<WebActionContext, string>)mi.CreateDelegate(typeof(Action<WebActionContext, string>), folder);
            }
            else
            {
                doer = (Action<WebActionContext>)mi.CreateDelegate(typeof(Action<WebActionContext>), folder);
            }

            // initialize ui
            var uis = (UiAttribute[])mi.GetCustomAttributes(typeof(UiAttribute), false);
            if (uis.Length > 0) ui = uis[0];
        }

        public WebFolder Folder => folder;

        public bool Arg => doer2 != null;

        public string Name => name;

        public int Form => ui?.Form ?? 0;

        public string Label => ui?.Label ?? name;

        public string Icon => ui?.Icon;

        public int Dialog => ui?.Dialog ?? 0;

        public override WebService Service => folder.Service;

        public UiAttribute Ui => ui;

        internal void Do(WebActionContext ac, string arg)
        {
            ac.Action = this;
            if (Authorize(ac)) // authorize check
            {
                // pre-
                DoBefore(ac);

                // invoke the right action method
                if (Arg) doer2(ac, arg);
                else doer(ac);

                // post-
                DoAfter(ac);
            }
            ac.Action = null;
        }

        public override string ToString()
        {
            return name;
        }
    }
}