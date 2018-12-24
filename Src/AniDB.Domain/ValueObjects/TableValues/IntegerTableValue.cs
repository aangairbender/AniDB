﻿using System;
using System.Collections.Generic;
using AniDB.Domain.Infrastructure;

namespace AniDB.Domain.ValueObjects.TableValues
{
    public class IntegerTableValue : TableValue<int>
    {
        public IntegerTableValue(int value) : base(value) { }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override void FromString(string value)
        {
            Value = Convert.ToInt32(value);
        }
    }
}
