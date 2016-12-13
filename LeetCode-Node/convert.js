/**
 * 6. ZigZag Conversion
 * @param {string} s
 * @param {number} numRows
 * @return {string}
 */
var convert = function (s, numRows) {
    var buckets = new Array();
    for(var k = 0;k<numRows;++k) buckets[k] = new Array();

    var seq = 0;
    for (var i = 0; i < s.length; ++i) {
        buckets[seq % numRows].push(s[i]);
        if(seq < numRows)
        seq++;
    }

    var s = '';
    for (var j = 0; j < numRows; ++j) {
        s += buckets[j].join();
    }

    return s;
};

module.exports = convert;