﻿using System;
using Npgsql;
using NpgsqlTypes;

namespace Greatbone.Core
{
    /// <summary>
    /// A wrapper of db parameter collection.
    /// </summary>
    public class DbParameters : ISink<DbParameters>
    {
        static string[] Defaults = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24" };

        readonly NpgsqlParameterCollection coll;

        internal DbParameters(NpgsqlParameterCollection coll)
        {
            this.coll = coll;
        }

        int index; // current parameter index

        internal void Clear()
        {
            coll.Clear();
            index = 0;
        }

        public DbParameters Put(string name, bool v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Boolean)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, short v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Smallint)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, int v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Integer)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, long v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Bigint)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, decimal v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Money)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, Number v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Numeric)
            {
                Value = v.Decimal
            });
            return this;
        }

        public DbParameters Put(string name, DateTime v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Timestamp)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, char[] v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Varchar, v.Length)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, string v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Varchar, v.Length)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put(string name, byte[] v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Bytea, v.Length)
            {
                Value = v
            });
            return this;
        }

        public DbParameters Put<T>(string name, T v, ushort x = 0xffff) where T : IPersist
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            if (v == null)
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb) { Value = DBNull.Value });
            }
            else
            {
                JStrBuild jsb = new JStrBuild();
                jsb.PutObj(v, x);
                string strv = jsb.ToString();
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb)
                {
                    Value = strv
                });
            }
            return this;
        }

        public DbParameters Put(string name, JObj v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            if (v == null)
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb) { Value = DBNull.Value });
            }
            else
            {
                JStrBuild jsb = new JStrBuild();
                v.Save(jsb);
                string strv = jsb.ToString();
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb) { Value = strv });
            }
            return this;
        }

        public DbParameters Put(string name, JArr v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            if (v == null)
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb) { Value = DBNull.Value });
            }
            else
            {
                JStrBuild jsb = new JStrBuild();
                v.Save(jsb);
                string strv = jsb.ToString();
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb) { Value = strv });
            }
            return this;
        }

        public DbParameters Put(string name, short[] v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Array | NpgsqlDbType.Smallint)
            {
                Value = (v != null) ? (object)v : DBNull.Value
            });
            return this;
        }

        public DbParameters Put(string name, int[] v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Array | NpgsqlDbType.Integer)
            {
                Value = (v != null) ? (object)v : DBNull.Value
            });
            return this;
        }

        public DbParameters Put(string name, long[] v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Array | NpgsqlDbType.Bigint)
            {
                Value = (v != null) ? (object)v : DBNull.Value
            });
            return this;
        }

        public DbParameters Put(string name, string[] v)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Array | NpgsqlDbType.Text)
            {
                Value = (v != null) ? (object)v : DBNull.Value
            });
            return this;
        }

        public DbParameters Put<T>(string name, T[] v, ushort x = 0xffff) where T : IPersist
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            if (v == null)
            {
                coll.Add(new NpgsqlParameter(name, NpgsqlDbType.Jsonb) { Value = DBNull.Value });
            }
            else
            {
                JStrBuild jsb = new JStrBuild();
                jsb.PutArr(v, x);
                string strv = jsb.ToString();
                coll.Add(new NpgsqlParameter(Defaults[index++], NpgsqlDbType.Jsonb)
                {
                    Value = strv
                });
            }
            return this;
        }

        public DbParameters PutNull(string name)
        {
            if (name == null)
            {
                name = Defaults[index++];
            }
            coll.AddWithValue(name, DBNull.Value);
            return this;
        }

    }
}