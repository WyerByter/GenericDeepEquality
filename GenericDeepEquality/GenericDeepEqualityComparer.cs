using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericDeepEquality {
    public class GenericDeepEqualityComparer : IEqualityComparer<object> {
        public new bool Equals(object x, object y) {
            if (x == null || y == null) {
                return x == null && y == null;
            } else if (x.GetType() != y.GetType()) {
                return false;
            } else {
                switch (x) {
                    case IEnumerable<object> xEnumerable:
                        var yEnumerable = (IEnumerable<object>)y;
                        return EnumerableComparison(xEnumerable, yEnumerable);
                    case bool xValue:
                        return ValueEqual(xValue, (bool)y);
                    case byte xValue:
                        return ValueEqual(xValue, (byte)y);
                    case sbyte xValue:
                        return ValueEqual(xValue, (sbyte)y);
                    case char xValue:
                        return ValueEqual(xValue, (char)y);
                    case decimal xValue:
                        return ValueEqual(xValue, (decimal)y);
                    case double xValue:
                        return ValueEqual(xValue, (double)y);
                    case float xValue:
                        return ValueEqual(xValue, (float)y);
                    case int xValue:
                        return ValueEqual(xValue, (int)y);
                    case uint xValue:
                        return ValueEqual(xValue, (uint)y);
                    case long xValue:
                        return ValueEqual(xValue, (long)y);
                    case ulong xValue:
                        return ValueEqual(xValue, (ulong)y);
                    case short xValue:
                        return ValueEqual(xValue, (short)y);
                    case ushort xValue:
                        return ValueEqual(xValue, (ushort)y);
                    case string xValue:
                        return ValueEqual(xValue, (string)y);
                    case Guid xValue:
                        return ValueEqual(xValue, (Guid)y);
                    default:
                        return GenericComparision(x, y);
                }
            }
        }

        public int GetHashCode(object obj) {
            return obj.GetHashCode();
        }

        private static bool ValueEqual<T>(T x, T y) {
            return x.Equals(y);
        }

        private bool EnumerableComparison(
            IEnumerable<object> x,
            IEnumerable<object> y) {
            var equal = false;

            if (x == null || y == null) {
                equal = x == null && y == null;
            } else {
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

        private bool GenericComparision(object x, object y) {
            var equal = true;

            if (x == null || y == null) {
                equal = x == null && y == null;
            } else {

                foreach (var propertyInfo in x.GetType().GetProperties()) {
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

                if (equal) {
                    foreach (var fieldInfo in x.GetType().GetFields()) {
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
