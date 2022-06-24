using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_BatDongSan
{
    public class Helper
    {
    }
    public sealed class MState
    {
        public static readonly SortedList<byte, MState> Values = new SortedList<byte, MState>();
        private readonly byte Value;

        public static readonly MState ACTIVE = new MState(1);
        public static readonly MState DISACTIVE = new MState(2);
        public static readonly MState DELETE = new MState(3);
        public static readonly MState ORTHER = new MState(4);

        private MState(byte state)
        {
            Value = state;
            Values.Add(Value, this);
        }

        public static implicit operator byte(MState value)
        {
            return value.Value;
        }

        public static implicit operator MState(byte state)
        {
            return Values[state];
        }
    }
}