using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLetApp;

namespace TestLetAppTest
{
    [TestClass]
    public class TestLetAppTest
    {
        [TestMethod]
        public void TestWhenItemsListIsNull()
        {
            Testlet testlet = new Testlet("1", null);
            var result = testlet.Randomize();
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestFirstTwoItemPretest_WhenPretestIsAtFirstPostion_InTheList()
        {
            List<Item> testLetItems = new List<Item>()
            {
            new Item{ItemId = "1", ItemType = ItemTypeEnum.Pretest},
            new Item{ItemId = "2", ItemType = ItemTypeEnum.Pretest},
            new Item{ItemId = "3", ItemType = ItemTypeEnum.Pretest},
            new Item{ItemId = "4", ItemType = ItemTypeEnum.Pretest},
            new Item{ItemId = "5", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "6", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "7", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "8", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "9", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "10", ItemType = ItemTypeEnum.Operational},
            };
            Testlet testlet = new Testlet("1", testLetItems);
            var result = testlet.Randomize();
            var filterPretest = result?.Where(x => x.ItemType == ItemTypeEnum.Pretest)?.Take(2).ToList();
            Assert.IsNotNull(filterPretest);
            Assert.IsTrue(filterPretest.Count == 2);
            Assert.IsTrue(filterPretest.All(x => x.ItemType == ItemTypeEnum.Pretest));
            Assert.IsTrue(testLetItems.All(x=> result.Contains(x)));
            //Test Randomness
            var inputids = string.Join(",", testLetItems.Select(x => x.ItemId));
            var resultids = string.Join(",", result.Select(x => x.ItemId));
            Assert.AreNotEqual(inputids, resultids);
        }

        [TestMethod]
        public void TestFirst_TwoItemPretest_WhenPretest_IsNotAtFirstPosition_InTheList()
        {
            List<Item> testLetItems = new List<Item>()
            {
            new Item{ItemId = "5", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "6", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "7", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "8", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "9", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "10", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "1", ItemType = ItemTypeEnum.Pretest},
            new Item{ItemId = "2", ItemType = ItemTypeEnum.Pretest},
            new Item{ItemId = "3", ItemType = ItemTypeEnum.Pretest},
            new Item{ItemId = "4", ItemType = ItemTypeEnum.Pretest},
            };
            Testlet testlet = new Testlet("1", testLetItems);
            var result = testlet.Randomize();
            var filterPretest = result?.Where(x => x.ItemType == ItemTypeEnum.Pretest)?.Take(2).ToList();
            Assert.IsNotNull(filterPretest);
            Assert.IsTrue(filterPretest.Count == 2);
            Assert.IsTrue(filterPretest.All(x => x.ItemType == ItemTypeEnum.Pretest));
            Assert.IsTrue(testLetItems.All(x => result.Contains(x)));
            //Test Randomness
            var inputids = string.Join(",", testLetItems.Select(x => x.ItemId));
            var resultids = string.Join(",", result.Select(x => x.ItemId));
            Assert.AreNotEqual(inputids, resultids);
        }
        [TestMethod]
        public void TestFirst_TwoItemPretest_WhenPretest_IsInMiddlePosition_InTheList()
        {
            List<Item> testLetItems = new List<Item>()
            {
            new Item{ItemId = "5", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "6", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "7", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "1", ItemType = ItemTypeEnum.Pretest},
            new Item{ItemId = "2", ItemType = ItemTypeEnum.Pretest},
            new Item{ItemId = "3", ItemType = ItemTypeEnum.Pretest},
            new Item{ItemId = "4", ItemType = ItemTypeEnum.Pretest},
            new Item{ItemId = "8", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "9", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "10", ItemType = ItemTypeEnum.Operational},
            };
            Testlet testlet = new Testlet("1", testLetItems);
            var result = testlet.Randomize();
            var filterPretest = result?.Where(x => x.ItemType == ItemTypeEnum.Pretest)?.Take(2).ToList();
            Assert.IsNotNull(filterPretest);
            Assert.IsTrue(filterPretest.Count == 2);
            Assert.IsTrue(filterPretest.All(x => x.ItemType == ItemTypeEnum.Pretest));
            Assert.IsTrue(testLetItems.All(x => result.Contains(x)));
            //Test Randomness
            var inputids = string.Join(",", testLetItems.Select(x => x.ItemId));
            var resultids = string.Join(",", result.Select(x => x.ItemId));
            Assert.AreNotEqual(inputids, resultids);
        }

        [TestMethod]
        public void TestWhenThereIs_PretestItemsNotExists_ShouldNotBreak()
        {
            List<Item> testLetItems = new List<Item>()
            {
            new Item{ItemId = "5", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "6", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "7", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "1", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "2", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "3", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "4", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "8", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "9", ItemType = ItemTypeEnum.Operational},
            new Item{ItemId = "10", ItemType = ItemTypeEnum.Operational},
            };
            Testlet testlet = new Testlet("1", testLetItems);
            var result = testlet.Randomize();
            var filterPretest = result?.Where(x => x.ItemType == ItemTypeEnum.Pretest)?.Take(2).ToList();
            Assert.IsTrue(filterPretest.Count == 0);
            Assert.IsTrue(testLetItems.All(x => result.Contains(x)));
            //Test Randomness
            var inputids = string.Join(",", testLetItems.Select(x => x.ItemId));
            var resultids = string.Join(",", result.Select(x => x.ItemId));
            Assert.AreNotEqual(inputids, resultids);
        }

    }
}
