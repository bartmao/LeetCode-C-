/**
 * @param {number[]} nums1
 * @param {number[]} nums2
 * @return {number}
 */
var findMedianSortedArrays = function (nums1, nums2) {
    if (nums1.length < nums2.length) {
        var t = nums2;
        nums2 = nums1;
        nums1 = t;
    }

    nums1.push(Number.MAX_VALUE);
    nums2.push(Number.MAX_VALUE);
    nums1.unshift(Number.MIN_VALUE);
    nums2.unshift(Number.MIN_VALUE);

    var p = 0, q = nums1.length - 1;
    var len = Math.floor((nums1.length + nums2.length) / 2);
    while (p <= q) {
        var l1 = Math.floor((p + q) / 2);
        var l2 = len - l1;

        if (nums1[l1 - 1] > nums2[l2]) {
            q = l1 - 1;
        }
        else if (nums2[l2 - 1] > nums1[l1]) {
            p = l1 + 1;
        }
        else {
            if ((nums1.length + nums2.length) % 2 === 0) {
                return (Math.max(nums1[l1 - 1], nums2[l2 - 1])
                    + Math.min(nums1[l1], nums2[l2])) / 2;
            }
            else {
                return Math.min(nums1[l1], nums2[l2]);
            }
        }
        // else {
        //     if ((nums1.length + nums2.length) % 2 === 0) {
        //         return (Math.max(nums1[l1 - 1] ? nums1[l1 - 1] : Number.MIN_VALUE, nums2[l2 - 1] ? nums2[l2 - 1] : Number.MIN_VALUE)
        //             + Math.min(nums1[l1]?nums1[l1]:Number.MAX_VALUE, nums2[l2]?nums2[l2]:Number.MAX_VALUE)) / 2;
        //     }
        //     else {
        //         return Math.min(nums1[l1]?nums1[l1]:Number.MAX_VALUE, nums2[l2]?nums2[l2]:Number.MAX_VALUE);
        //     }
        // }
    }


};

module.exports = findMedianSortedArrays;