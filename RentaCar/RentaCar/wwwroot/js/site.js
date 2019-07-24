// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(window).scroll(function () {
    $('nav').toggleClass('scrollednav', $(this).scrollTop() > 20);
}
);



$(function () {
    $('nav ul li a').filter(function () {
        return this.href == location.href
    }).parent().addClass('active').siblings().removeClass('active');

    $('nav ul li a').click(function () {
        $(this).parent().addClass('active').siblings().removeClass('active')
    });
});