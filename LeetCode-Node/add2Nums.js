/**
 * Definition for singly-linked list.
 * function ListNode(val) {
 *     this.val = val;
 *     this.next = null;
 * }
 */
/**
 * @param {ListNode} l1
 * @param {ListNode} l2
 * @return {ListNode}
 */

var addTwoNumbers = function (l1, l2) {
    var remain = 0;
    var result = [];
    var l1p, l2p;
    while (l1 || l2 || remain == 0) {
        l1p = l1 ? (l1.val ? l1.val : 0) : 0;
        l2p = l2 ? (l2.val ? l2.val : 0) : 0;        
        var r = l1p + l2p + remain;
        if (r >= 10) {
            remain = 1;
            r -= 10;
        }
        else remain = 0;
        result.push(r);

        if(l1) l1 = l1.next;
        if(l2) l2 = l2.next;
        if (!l1 && !l2 & remain == 0) break;
    }
    return result;
};

module.exports = addTwoNumbers;