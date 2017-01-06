﻿namespace Greatbone.Core
{
    ///
    /// A data object that follows certain input/ouput conventions.
    ///
    public interface IData
    {
        void Load(ISource src, byte flags = 0);

        void Dump<R>(ISink<R> snk, byte flags = 0) where R : ISink<R>;
    }
}
