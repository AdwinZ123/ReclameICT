$(window).scroll(function () {
    var scroll = $(window).scrollTop();
    if (scroll <= 75) {
        $(".scroll").addClass("scrollDown").removeClass("scroll");
    }
    else {
        $(".scrollDown").addClass("scroll").removeClass("scrollDown");
    }
});