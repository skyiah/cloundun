using System;
using System.Collections.Generic;

namespace Greatbone.Core
{
    /// <summary>
    /// An object data model.
    /// </summary>
    public class Obj : ISource
    {
        const int InitialCapacity = 16;

        readonly Roll<Member> pairs;

        public Obj(int capacity = InitialCapacity)
        {
            pairs = new Roll<Member>(16);
        }

        internal void Add(string name)
        {
            Member e = new Member()
            {
                Key = name
            };
            pairs.Add(e);
        }

        internal void Add(string name, Obj v)
        {
            Member e = new Member(v)
            {
                Key = name
            };
            pairs.Add(e);
        }

        internal void Add(string name, Arr v)
        {
            Member e = new Member(v)
            {
                Key = name
            };
            pairs.Add(e);
        }

        internal void Add(string name, string v)
        {
            Member e = new Member(v)
            {
                Key = name
            };
            pairs.Add(e);
        }

        internal void Add(string name, byte[] v)
        {
            Member e = new Member(v)
            {
                Key = name
            };
            pairs.Add(e);
        }

        internal void Add(string name, bool v)
        {
            Member e = new Member(v)
            {
                Key = name
            };
            pairs.Add(e);
        }

        internal void Add(string name, Number v)
        {
            Member e = new Member(v)
            {
                Key = name
            };
            pairs.Add(e);
        }

        public int Count => pairs.Count;

        public Member this[int index] => pairs[index];

        public Member this[string name] => pairs[name];

        //
        // SOURCE
        //

        public bool Got(string name, ref bool v)
        {
            Member pair;
            if (pairs.TryGet(name, out pair))
            {
                v = (bool)pair;
                return true;
            }
            return false;
        }

        public bool Got(string name, ref short v)
        {
            Member pair;
            if (pairs.TryGet(name, out pair))
            {
                v = (short)pair;
                return true;
            }
            return false;
        }

        public bool Got(string name, ref int v)
        {
            Member pair;
            if (pairs.TryGet(name, out pair))
            {
                v = (int)pair;
                return true;
            }
            return false;
        }

        public bool Got(string name, ref long v)
        {
            Member pair;
            if (pairs.TryGet(name, out pair))
            {
                v = (short)pair;
                return true;
            }
            return false;
        }

        public bool Got(string name, ref decimal v)
        {
            Member pair;
            if (pairs.TryGet(name, out pair))
            {
                v = (decimal)pair;
                return true;
            }
            return false;
        }

        public bool Got(string name, ref DateTime v)
        {
            Member pair;
            if (pairs.TryGet(name, out pair))
            {
                v = (DateTime)pair;
                return true;
            }
            return false;
        }

        public bool Got(string name, ref string v)
        {
            Member pair;
            if (pairs.TryGet(name, out pair))
            {
                v = (string)pair;
                return true;
            }
            return false;
        }

        public bool Got<T>(string name, ref T v) where T : IPersist, new()
        {
            Member pair;
            if (pairs.TryGet(name, out pair))
            {
                T val = new T();
                val.Load((Obj)pair);
                v = val;
                return true;
            }
            return false;
        }

        public bool Got<T>(string name, ref List<T> v) where T : IPersist, new()
        {
            Member pair;
            if (pairs.TryGet(name, out pair))
            {
                Arr ma = pair;
                List<T> lst = null;
                for (int i = 0; i < ma.Count; i++)
                {
                    Obj el = ma[i];
                    T val = new T();
                    val.Load(el);
                    if (lst == null) lst = new List<T>(16);
                    lst.Add(val);
                }
                v = lst;
                return true;
            }
            return false;
        }

        public bool Got(string name, ref byte[] v)
        {
            Member pair;
            if (pairs.TryGet(name, out pair))
            {
                v = (byte[])pair;
                return true;
            }
            return false;
        }

        public bool Got(string name, ref Obj v)
        {
            Member pair;
            if (pairs.TryGet(name, out pair))
            {
                v = (Obj)pair;
                return true;
            }
            return false;
        }

        public bool Got(string name, ref Arr v)
        {
            Member pair;
            if (pairs.TryGet(name, out pair))
            {
                v = (Arr)pair;
                return true;
            }
            return false;
        }

    }
}