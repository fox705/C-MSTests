using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    public static class CustomAsserts
    {

        public static void IsInRange(this Assert assert,
            int actual,
            int expectedMinValue,
            int expectedMaxValue
        )
        {

            if (actual < expectedMinValue || actual > expectedMaxValue)
            {
                throw new AssertFailedException($"{actual} is not in Range of {expectedMinValue} -- {expectedMaxValue}");
            }

        }

        public static void NotNullOrWhiteSpaceItem(this CollectionAssert collectionAssert, 
                                                   ICollection<string> collection )
        {
            foreach (var item in collection)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    throw new AssertFailedException("One or more null items.");
                }

            }
        }

        public static void AllItemsSatisfy<T>(this CollectionAssert collectionAssert, ICollection<T> collection,
            Predicate<T> predicatete)
        {
            foreach (var item in collection)
            {
                if (!predicatete(item))
                {
                    throw new AssertFailedException("All items are not satisfy");
                }

            }

        }

        public static void OneItemSatisfy<T>(this CollectionAssert collectionAssert, ICollection<T> collection,
            Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return;
                }

            }

            throw new AssertFailedException("No item satisfy.");

        }

        public static void All<T>(this CollectionAssert collectionAssert,
            ICollection<T> collection,
            Action<T> assert)
        {
            foreach (var item in collection)
            {
                assert(item);
            }

        }

        public static void IsNullOrWhiteSpace(this StringAssert stringAssert, string actual)
        {
            if (string.IsNullOrWhiteSpace(actual))
            {
                throw new AssertFailedException("Item is null or whitespace");
            }
        }


    }
}