app.filter('dateFormat', function () {
    return function (date) {
        var conver = date.replace(/\/Date\((-?\d+)\)\//, '$1');
        var d = new Date(parseInt(conver));
        return d;
    }
});