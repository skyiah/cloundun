﻿using System;
using System.Collections.Generic;

namespace Greatbone.Core
{
    /// <summary>
    /// A reader that reads serialized content.
    /// </summary>
    public interface IInput
    {
        //
        // property reading

        bool Get(string name, ref bool value);

        bool Get(string name, ref short value);

        bool Get(string name, ref int value);

        bool Get(string name, ref long value);

        bool Get(string name, ref decimal value);

        bool Get(string name, ref DateTime value);

        bool Get(string name, ref char[] value);

        bool Get(string name, ref string value);

        bool Get<T>(string name, ref T value) where T : IDat, new();

        bool Get(string name, ref byte[] value);

        bool Get<T>(string name, ref List<T> value);

        bool Get<T>(string name, ref Dictionary<string, T> value);
    }
}