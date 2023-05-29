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
                var xEquatableType = x.GetType().GetInterfaces()
                    .Where(xInter => xInter.IsGenericType)
                    .Where(xInter => xInter.GetGenericTypeDefinition() 
                        == typeof(IEquatable<>));

                if (xEquatableType.Count() > 0 ) {
                    return x.Equals(y);
                } else {  
                    switch (x) {
                        case IEnumerable<object> xEnumerable:
                            var yEnumerable = (IEnumerable<object>)y;
                            return EnumerableComparison(xEnumerable, yEnumerable);
                        default:
                            return GenericComparision(x, y);
                    }

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
