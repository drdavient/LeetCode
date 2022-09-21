// See https://aka.ms/new-console-template for more information




// [[1,2],[3,5],[6,7],[8,10],[12,16]]
// [4,8]
// new InsertInterval57().Insert(new int[][] { new int[] { 1, 2 }, new int[] { 3, 5 } , new int[] { 6, 7 }, new int[] { 8, 10 }, new int[] { 12, 16 }   }, new[] { 4, 8 });


// [[1,3],[6,9]]
// [2,5]
// new InsertInterval57().Insert(new int[][] { new int[] { 1, 3}},   new[] { 2, 7 });


// [[1,5]]
// [6,8]

// new InsertInterval57().Insert(new int[][] { new int[] { 1, 5}},   new[] { 6, 8 });
//
//
// [[1,5]]
// [0,0]

// new InsertInterval57().Insert(new int[][] { new int[] { 1, 5}},   new[] {0, 0});

// Reverse LinkedList
// [1,2,3,4,5]

// ListNode node = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))); 
//  new ReverseLinkedList206().ReverseList(node);

/// new SetMatrixZeroes73().SetZeroesO1(new []{new []{0,1}});
//new SetMatrixZeroes73().SetZeroesOOne(new[] {new [] {1,1,1}, new[] {1,0,1}, new [] {1,1,1}});

// var matrix  = new[] {new []{1,2,3,4},new[] {5,0,7,8},new[] {0,10,11,12},new[] {13,14,15,0}};
//    new SetMatrixZeroes73() .SetZeroesOOne(matrix);
// Console.Write(matrix);

//Console.Write(LengthOfLongestSubstring3.Substring("aabaab!bb"));
//MergeKSortedLists23.MergeKLists("[[1,4,5]]");

using NUnit.Framework;

Assert.AreEqual(9, TGFindTotal.find_total(new[] {15,25,35}));
Assert.AreEqual(10, TGFindTotal.find_total(new[] {8,8}));