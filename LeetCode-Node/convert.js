/**
 * 6. ZigZag Conversion
 * @param {string} s
 * @param {number} numRows
 * @return {string}
 */
var convert = function (s, numRows) {
    if(numRows == 1) return s;

    var buckets = new Array();
    for (var k = 0; k < numRows; ++k) buckets[k] = new Array();

    var N = numRows;
    var cycle = 2 * N - 2;

    for (var i = 0; i < s.length; ++i) {
        var bucketNum = i % cycle;
        if (bucketNum > N - 1) bucketNum = 2 * (N - 1) - bucketNum;

        buckets[bucketNum].push(s[i]);
    }

    var s = '';
    for (var j = 0; j < numRows; ++j) {
        s += buckets[j].join('');
    }

    return s;
};

module.exports = convert;