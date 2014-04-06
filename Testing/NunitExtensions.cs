using System;
using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;
using NUnit.Framework;

namespace Common.Testing
{
    public static class NunitExtensions
    {
        [DebuggerStepThrough]
        public static void ShouldNotBeNull<T>(this T item)
        {
            Assert.That(item, Is.Not.Null);
        }

        [DebuggerStepThrough]
        public static void ShouldBeNull<T>(this T item)
        {
            Assert.That(item, Is.Null);
        }

        [DebuggerStepThrough]
        public static void ShouldBeGreaterThan<T>(this T item, T comparison)
        {
            Assert.That(item, Is.GreaterThan(comparison));
        }

        [DebuggerStepThrough]
        public static void ShouldBeFalse(this bool item)
        {
            Assert.That(item, Is.False);
        }

        [DebuggerStepThrough]
        public static void ShouldBeFalse(this bool item, string extendAssertionExceptionMessage)
        {
            Assert.That(item, Is.False, extendAssertionExceptionMessage);
        }

        [DebuggerStepThrough]
        public static void ShouldBeTrue(this bool item)
        {
            Assert.That(item, Is.True);
        }

        [DebuggerStepThrough]
        public static void ShouldBeTrue(this bool item, string extendAssertionExceptionMessage)
        {
            Assert.That(item, Is.True, extendAssertionExceptionMessage);
        }

       [DebuggerStepThrough]
        public static void ShouldEqual<T>(this T item, T comparison)
        {
            Assert.That(item, Is.EqualTo(comparison));
        }

       [DebuggerStepThrough]
       public static void ShouldEqual<T>(this T item, T comparison, string extendAssertionExceptionMessage)
        {
            Assert.That(item, Is.EqualTo(comparison), extendAssertionExceptionMessage);
        }

        [DebuggerStepThrough]
        public static void ShouldNotEqual<T>(this T item, T comparison)
        {
            Assert.That(item, Is.Not.EqualTo(comparison));
        }

        [DebuggerStepThrough]
        public static void ShouldContain(this string item, string part)
        {
            Assert.That(item, Contains.Substring(part));
        }

        [DebuggerStepThrough]
        public static void ShouldBeEmpty(this IEnumerable item)
        {
            Assert.That(item, Is.Empty);
        }

        [DebuggerStepThrough]
        public static void ShouldBeEmpty(this string item)
        {
            Assert.That(item, Is.Empty);
        }

        [DebuggerStepThrough]
        public static void ShouldNotBeEmpty(this string item)
        {
            Assert.That(item, Is.Not.Empty);
        }

        [DebuggerStepThrough]
        public static void ShouldBeCountZero(this IList item)
        {
            Assert.That(item.Count, Is.EqualTo(0));
 
        }

        [DebuggerStepThrough]
        public static void ShouldCountEqual(this IList item, int comparisonCount)
        {
            Assert.That(item.Count, Is.EqualTo(comparisonCount));

        }

        [DebuggerStepThrough]
        public static void ShouldCountGreaterThan(this IList item, int comparisonCount)
        {
            Assert.That(item.Count, Is.GreaterThan(comparisonCount));
        }

        [DebuggerStepThrough]
        public static void ShouldContain(this IEnumerable item, object contained)
        {
            Assert.That(item, Contains.Item(contained));
        }

        [DebuggerStepThrough]
        public static void ShouldNotContain(this IEnumerable item, object contained)
        {
            Assert.That(item, Has.No.EqualTo(contained));
        }

        [DebuggerStepThrough]
        public static void ShouldContain(this IList item, object contained)
        {
            Assert.That(item.Contains(contained));            
        }

        [DebuggerStepThrough]
        public static void ShouldNotContain(this IList item, object contained)
        {
            Assert.That(!item.Contains(contained));
        }

        [DebuggerStepThrough]
        public static void ShouldBeAnInstanceOf<TargetType>(this object item)
        {
            Assert.That(item, Is.InstanceOf(typeof(TargetType)));
        }

        [DebuggerStepThrough]
        public static void ShouldBeAnInstanceOf<TargetType>(this object item, Expression<Func<TargetType, bool>> additionalAssertion)
        {
            item.ShouldBeAnInstanceOf<TargetType>();

            var lambda = additionalAssertion.ToString();
            var actualAssertion = additionalAssertion.Compile();            
            Assert.That(actualAssertion((TargetType)item), Is.True, "failed assertion: " + lambda);
        }
    }
}
