function ListNode(val) {
    this.val = val;
    this.next = null;
}

ListNode.getNode = function(arr) {
    var p = new ListNode();
    var head = p;
    for (var i = 0; i < arr.length; ++i) {
        p.val = arr[i];
        if (i != arr.length - 1) p.next = new ListNode();
        p = p.next;
    }

    return head;
}

module.exports = ListNode;