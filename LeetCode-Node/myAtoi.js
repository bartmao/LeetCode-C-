/**
 * 8. String to Integer (atoi)
 * @param {string} str
 * @return {number}
 */
var myAtoi = function(str) {
    var num = parseInt(str);
    return Number.isNaN(num)?0:num;
};