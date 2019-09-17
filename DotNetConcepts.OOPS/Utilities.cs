using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotNetConcepts.OOPS
{
    public static class Utilities
    {
        public static IList<ItemType> SortAsLinkedList<IdType, ItemType>(this IEnumerable<ItemType> list, Func<ItemType, IdType> GetId, Func<ItemType, IdType> GetNextId) where IdType : IComparable
        {
            try
            {
                var result = new List<ItemType>();
                ItemType lastItem = default(ItemType);
                var dic = new Dictionary<IdType, ItemType>();
                bool lastItemExists = false;
                list.ToList().ForEach(item =>
                {
                    var nextId = GetNextId(item);

                    if (nextId == null)
                    {
                        result.Add(item);
                        lastItem = item;
                        lastItemExists = true;
                    }
                    else
                    {
                        dic.Add(GetNextId(item), item);
                    }
                });

                if (lastItemExists)
                {
                    bool nextItemExists = true;
                    var previousItem = lastItem;
                    while (nextItemExists)
                    {
                        ItemType nextItem;
                        var test = dic.TryGetValue(GetId(previousItem), out nextItem);

                        if (nextItem != null)
                        {
                            result.Add(nextItem);
                            previousItem = nextItem;
                        }
                        else
                        {
                            nextItemExists = false;
                        }
                    }
                }

                result.Reverse();
                return result;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
    public class CustomComparer<IdType, ItemType> : IComparer<ItemType>
    {
        private readonly Func<ItemType, IdType> _getId;
        private readonly Func<ItemType, IdType> _getNextId;

        public CustomComparer(Func<ItemType, IdType> GetId, Func<ItemType, IdType> GetNextId)
        {
            _getId = GetId;
            _getNextId = GetNextId;
        }
        public int Compare(ItemType a, ItemType b)
        {
            var item1Id = _getId(a);
            var item1NextId = _getNextId(a);

            var item2Id = _getId(b);
            var item2NextId = _getNextId(b);

            if (item1NextId == null)
                return 1;

            if (item2NextId == null)
                return -1;

            if (item1NextId.ToString() == item2Id.ToString())
                return -1;

            if (item1Id.ToString() == item2NextId.ToString())
                return 1;

            return 0;
        }
    }
    public static class UtiliesTests
    {
        private static List<LinkedListItem<string>> DefaultScrambledList
        {
            get
            {
                return new List<LinkedListItem<string>>()
                {
                    new LinkedListItem<string>("b", "c"),
                    new LinkedListItem<string>("a", "b"),
                    new LinkedListItem<string>("d", null),
                    new LinkedListItem<string>("c", "d"),
                };
            }
        }

        [Fact]
        public static void ShouldSortLinkedList()
        {
            var scrambled = DefaultScrambledList;
            var sorted = scrambled.SortAsLinkedList<string, LinkedListItem<string>>(x => x.Id, x => x.NextId);

            Assert.Equal("a", sorted[0].Id);
            Assert.Equal("b", sorted[1].Id);
            Assert.Equal("c", sorted[2].Id);
            Assert.Equal("d", sorted[2].Id);
            Assert.Equal("e", sorted[2].Id);
        }

        [Fact]
        public static void ShouldThrowWhenMissingANode()
        {
            // Get a list without the last node
            var scrambled = DefaultScrambledList
                .Where(x => x.Id != "d")
                .ToList();

            Assert.Throws<ArgumentException>(() =>
            {
                var sorted = scrambled.SortAsLinkedList<string, LinkedListItem<string>>(x => x.Id, x => x.NextId);
            });
        }


        [Fact]
        public static void ShouldThrowWhenNodeReferencesNodeThatDoesntExist()
        {
            // Get a list without the last node
            var scrambled = DefaultScrambledList;
            scrambled[0].NextId = "x";

            Assert.Throws<ArgumentException>(() =>
            {
                var sorted = scrambled.SortAsLinkedList<string, LinkedListItem<string>>(x => x.Id, x => x.NextId);
            });
        }

        [Fact]
        public static void ShouldThrowWhenMultipleNodesReferenceTheSameNode()
        {
            // Get a list without the last node
            var scrambled = DefaultScrambledList;
            scrambled[1].NextId = "d";

            Assert.Throws<ArgumentException>(() =>
            {
                var sorted = scrambled.SortAsLinkedList<string, LinkedListItem<string>>(x => x.Id, x => x.NextId);
            });
        }

        /// <summary>
        /// This class exists for the sole purpose of testing the utility methods
        /// </summary>
        /// <typeparam name="IdType"></typeparam>
        public class LinkedListItem<IdType>
        {
            public IdType Id { get; set; }
            public IdType NextId { get; set; }

            public LinkedListItem(IdType id, IdType nextId)
            {
                Id = id;
                NextId = nextId;
            }
        }
    }
}
