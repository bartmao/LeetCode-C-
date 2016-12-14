/**
 * 7. Reverse Integer
 * @param {number} x
 * @return {number}
 */
var reverse = function(x) {
    var y = Math.abs(x);
    var base = 0;
    while (y >= 1) {
        base = base * 10 + y % 10;
        y = Math.floor(y / 10);
    }

    return Math.abs(base) > Math.pow(2, 31) ? 0 : (x > 0 ? base : -base);
};

module.exports = reverse;