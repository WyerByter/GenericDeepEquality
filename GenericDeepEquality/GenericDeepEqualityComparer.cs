using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericDeepEquality
{
    public class GenericDeepEqualityComparer : IEqualityComparer<object>
    {
        public new bool Equals(object x, object y)
        {
            if (x == null || y == null)
            {
                return x == null && y == null;
            }
            else if (x.GetType() != y.GetType())
            {
                return false;
            }
            else
            {
                switch (x)
                {
                    case IEnumerable<object> xEnumerable:
                        var yEnumerable = (IEnumerable<object>)y;
                        return EnumerableComparison(xEnumerable, yEnumerable);
                    case bool xBool:
                        var yBool = (bool)y;
                        return xBool == yBool;
                    case byte xByte:
                        var yByte = (byte)y;
                        return xByte == yByte;
                    case sbyte xSByte:
                        var ySByte = (sbyte)y;
                        return xSByte == ySByte;
                    case char xChar:
                        var yChar = (char)y;
                        return xChar == yChar;
                    case decimal xDecimal:
                        var yDecimal = (decimal)y;
                        return xDecimal == yDecimal;
                    case double xDouble:
                        var yDouble = (double)y;
                        return xDouble == yDouble;
                    case float xFloat:
                        var yFloat = (float)y;
                        return xFloat == yFloat;
                    case int xInt:
                        var yInt = (int)y;
                        return xInt == yInt;
                    case uint xUInt:
                        var yUInt = (uint)y;
                        return xUInt == yUInt;
                    case long xLong:
                        var yLong = (long)y;
                        return xLong == yLong;
                    case ulong xULong:
                        var yULong = (ulong)y;
                        return xULong == yULong;
                    case short xShort:
                        var yShort = (short)y;
                        return xShort == yShort;
                    case ushort xUShort:
                        var yUShort = (ushort)y;
                        return xUShort == yUShort;
                    case string xString:
                        var yString = (string)y;
                        return xString.Equals(yString);
                    case Guid xGuid:
                        var yGuid = (Guid)y;
                        return xGuid.Equals(yGuid);
                    default:
                        return GenericComparision(x, y);
                }
            }
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }

        private bool EnumerableComparison(
            IEnumerable<object> x,
            IEnumerable<object> y)
        {
            var equal = false;

            if (x == null || y == null)
            {
                equal = x == null && y == null;
            }
            else
            {
                var xList = x.ToList();
                var yList = y.ToList();

                var xNotInY = xList.Any(
                    xItem => yList.All(
                        yItem => !Equals(
                            yItem,
                            xItem)));
                var yNotInX = yList.Any(
                    yItem => xList.All(
                        xItem => !Equals(
                            xItem,
                            yItem)));

                equal = xList.Count == yList.Count
                    && (xList.Count == 0
                        || !(xNotInY || yNotInX));
            }

            return equal;
        }

        private bool GenericComparision(object x, object y)
        {
            var equal = true;

            if (x == null || y == null)
            {
                equal = x == null && y == null;
            }
            else
            {

                foreach (var propertyInfo in x.GetType().GetProperties())
                {
                    var xValue = propertyInfo.GetValue(x, null);
                    if (x.GetType() == xValue?.GetType()) {
                        continue;
                    }
                    var yValue = propertyInfo.GetValue(y, null);
                    if (Equals(xValue, yValue))
                        continue;
                    equal = false;
                    break;
                }

                if (equal)
                {
                    foreach (var fieldInfo in x.GetType().GetFields())
                    {
                        var xValue = fieldInfo.GetValue(x);
                        if (x.GetType() == xValue?.GetType()) {
                            continue;
                        }
                        var yValue = fieldInfo.GetValue(y);
                        if (Equals(xValue, yValue))
                            continue;
                        equal = false;
                        break;
                    }
                }
            }

            return equal;
        }
    }
}
