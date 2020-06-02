$(function () {
    // year
    $(".yyyy").datetimepicker(getYearParam());

    // year month
    $(".yyyyMM").datetimepicker(getYearMonthParam());

    // year month day
    $(".yyyyMMdd").datetimepicker(getYearMonthDayParam());

    // year month day Hour Minute Second
    $(".yyyyMMddHHmmss").datetimepicker(getYearMonthDayHourMinuteSecondParam());

    // Hour Minute Second
    $(".HHmmss").datetimepicker(getHourMinuteSecondParam());
});

// year object
function getYearParam() {
    return {
        format: "YYYY",
        useCurrent: false
    }
}

// year month object
function getYearMonthParam() {
    return {
        format: "YYYY-MM",
        useCurrent: false
    }
}

// year month day object
function getYearMonthDayParam() {
    return {
        format: "YYYY-MM-DD",
        useCurrent: false
    }
}

// year month day Hour Minute Second
function getYearMonthDayHourMinuteSecondParam() {
    return {
        format: "YYYY-MM-DD HH:mm:ss"
    }
}

// Hour Minute Second
function getHourMinuteSecondParam() {
    return {
        format: "HH:mm:ss"
    }
}
