/**
 * @param {string} s
 * @return {number}
 */
var lengthOfLongestSubstring = function(s) {
    var map = {};
    var max = 0, start = -1;
    for (var i = 0; i < s.length; ++i) {
        if (map[s[i]] !== undefined && map[s[i]] > start)
            start = map[s[i]];
        map[s[i]] = i;
        max = max >= (i - start) ? max : i - start;
    }
    return max;
};

module.exports = lengthOfLongestSubstring;