using GenericDeepEquality;
using System;
using Xunit;

namespace Tests
{
    public class GenericDeepEqualityTest
    {
        [Fact]
        public void EqualsBoolTrue()
        {
            bool x = true;
            bool y = true;
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsBoolFalse()
        {
            bool x = true;
            bool y = false;
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsByteTrue()
        {
            byte x = 3;
            byte y = 3;
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsByteFalse()
        {
            byte x = 3;
            byte y = 4;
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsSByteTrue()
        {
            sbyte x = 3;
            sbyte y = 3;
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsSByteFalse()
        {
            sbyte x = 3;
            sbyte y = 4;
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsCharTrue()
        {
            char x = 'a';
            char y = 'a';
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsCharFalse()
        {
            char x = 'a';
            char y = 'A';
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsDecimalTrue()
        {
            decimal x = 3.4m;
            decimal y = 3.4m;
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsDecimalFalse()
        {
            decimal x = 3.4m;
            decimal y = 4.9m;
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsDoubleTrue()
        {
            double x = 3.2;
            double y = 3.2;
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsDoubleFalse()
        {
            double x = 3.2;
            double y = 4.7;
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsFloatTrue()
        {
            float x = 3.2f;
            float y = 3.2f;
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsFloatFalse()
        {
            float x = 3.2f;
            float y = 4.7f;
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsIntTrue()
        {
            int x = 3;
            int y = 3;
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsIntFalse()
        {
            int x = 3;
            int y = 4;
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsUIntTrue()
        {
            uint x = 3;
            uint y = 3;
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsUIntFalse()
        {
            uint x = 3;
            uint y = 4;
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsLongTrue()
        {
            long x = 3;
            long y = 3;
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsLongFalse()
        {
            long x = 3;
            long y = 4;
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsULongTrue()
        {
            ulong x = 3;
            ulong y = 3;
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsULongFalse()
        {
            ulong x = 3;
            ulong y = 4;
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsShortTrue()
        {
            short x = 3;
            short y = 3;
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsShortFalse()
        {
            short x = 3;
            short y = 4;
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsUShortTrue()
        {
            ushort x = 3;
            ushort y = 3;
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsUShortFalse()
        {
            ushort x = 3;
            ushort y = 4;
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsStringTrue()
        {
            string x = "Right String";
            string y = "Right String";
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsStringFalse()
        {
            string x = "Right String";
            string y = "Wrong String";
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        private struct TestStruct
        {
            public int iNumber;
            public string sWord;
        }

        [Fact]
        public void EqualsStructTrue()
        {
            TestStruct x = new TestStruct {iNumber = 3, sWord = "Struct Test"};
            TestStruct y = new TestStruct {iNumber = 3, sWord = "Struct Test"};
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsStructFalse()
        {
            TestStruct x = new TestStruct {iNumber = 3, sWord = "Struct Test"};
            TestStruct y = new TestStruct {iNumber = 3, sWord = "Wrong Struct Test"};
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        private class TestClass
        {
            public int iNumber;
            public string sWord;
        }

        [Fact]
        public void EqualsClassTrue()
        {
            TestClass x = new TestClass {iNumber = 3, sWord = "Class Test"};
            TestClass y = new TestClass {iNumber = 3, sWord = "Class Test"};
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsClassFalse()
        {
            TestClass x = new TestClass {iNumber = 3, sWord = "Class Test"};
            TestClass y = new TestClass {iNumber = 3, sWord = "Wrong Class Test"};
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsDateTimeTrue()
        {
            DateTime x = DateTime.Parse("12/7/2019");
            DateTime y = DateTime.Parse("12/7/2019");
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsDateTimeFalse()
        {
            DateTime x = DateTime.Parse("12/7/2019");
            DateTime y = DateTime.Parse("12/7/2029");
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsGuidTrue()
        {
            Guid x = Guid.NewGuid();
            Guid y = new Guid(x.ToByteArray());
            var comparer = new GenericDeepEqualityComparer();

            Assert.True(comparer.Equals(x, y));
        }

        [Fact]
        public void EqualsGuidFalse()
        {
            Guid x = Guid.NewGuid();
            Guid y = Guid.NewGuid();
            var comparer = new GenericDeepEqualityComparer();

            Assert.False(comparer.Equals(x, y));
        }
    }
}
