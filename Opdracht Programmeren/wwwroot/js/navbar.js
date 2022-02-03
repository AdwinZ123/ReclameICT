$(window).scroll(function () {
    var scroll = $(window).scrollTop();
    if (scroll <= 850) {
        $(".scroll").addClass("scrollDown").removeClass("scroll");
    }
    else {
        $(".scrollDown").addClass("scroll").removeClass("scrollDown");
    }
});