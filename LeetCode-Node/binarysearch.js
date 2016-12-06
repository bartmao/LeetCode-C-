function binarysearch(arr, target) {
    var l = 0, r = arr.length - 1;
    while (l <= r) {
        var m = Math.floor((l + r) / 2);
        if (arr[m] > target) r = m - 1;
        else if (arr[m] < target) l = m + 1;
        else return m;
    }
    return -1;
}

module.exports = binarysearch;