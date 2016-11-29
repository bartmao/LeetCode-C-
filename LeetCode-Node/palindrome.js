// Manacher
function longestPalindromicSubstring(s) {
    var ss = '#' + s.split('').join('#') + '#';

    var c = 0, max = 0, p = [];
    // for (var i = 1; i < ss.length - 1; ++i) {
    //     var mirrori = 2 * c - i;
    //     if (p[mirrori] && p[mirrori] > max - i) p[i] = max - i;
    //     else p[i] = 1;

    //     while (ss[i + p[i]] == ss[i - p[i]]) p[i]++;
    //     if (i + p[i] > max) {
    //         max = i + p[i] - 1;
    //         c = i;
    //     }
    // }

    console.log(`${ss.substr(c / 2, max - c - 1)}, start:${c / 2}, length:${max - c - 1}`);
}

module.exports = longestPalindromicSubstring;