var ListNode = require('./ListNode.js');
var palinedrome = require('./palindrome.js');
var add2Nums = require('./add2Nums.js');
var lengthOfLongestSubstring = require('./lengthOfLongestSubstring.js');
var binarySearch = require('./binarySearch.js');
var findMedianSortedArrays = require('./findMedianSortedArrays.js');

console.log(findMedianSortedArrays([5],[1,2,3,4,6,7,8,9]));


// function getNode(arr) {
//     var p = new ListNode();
//     var head = p;
//     for (var i = 0; i < arr.length; ++i) {
//         p.val = arr[i];
//         if (i != arr.length - 1) p.next = new ListNode();
//         p = p.next;
//     }

//     return head;
// }