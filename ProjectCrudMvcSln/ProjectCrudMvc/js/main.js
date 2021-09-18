;
(function ($) {
    "use strict";

    function menu_fixed() {
        var menusfixed = $('.Appily_header');

        function menu_scroll_fixed(e) {
            var windowTop = $(window).scrollTop();
            var adRecl = "fixedMenu";
            if (windowTop > 0) {
                e.addClass(adRecl);
            } else {
                e.removeClass(adRecl);
            }
        }
        menu_scroll_fixed(menusfixed);

        $(window).scroll(function () {
            menu_scroll_fixed(menusfixed);
        });
    }
    menu_fixed();

    /*-------------------------------------------------------------------------------
        Dropdown Menu
    -------------------------------------------------------------------------------*/
    function active_dropdown() {
        if ($(window).width() < 992) {
            $('.Appily_header_menu ul li.nav-item > a.dropdown-toggle').on('click', function (event) {
                event.preventDefault();
                $(this).parent().find('.dropdown-menu').first().toggle(500);
                $(this).parent().siblings().find('.dropdown-menu').hide(500);
            });
        }
    }
    active_dropdown();

    /*-------------------------------------------------------------------------------
       Wow js
    -------------------------------------------------------------------------------*/
    function wowAnimation() {
        new WOW({
            offset: 100,
            mobile: true
        }).init();
    }
    wowAnimation();


    /*-------------------------------------------------------------------------------
       appscreenshot slider
    -------------------------------------------------------------------------------*/
    function Appscreenshot() {
        $('.app_Screenshot_slider').slick({
            slidesToShow: 1,
            slidesToScroll: 1,
            speed: 2000,
            arrows: false,
            dots: false,
            autoplay: true,
            infinite: true,
            centerMode: true,
            centerPadding: '0px',
            responsive: [{
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1,
                        infinite: true,
                        dots: false
                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                }
            ]

        });
    }
    Appscreenshot();

    /*-------------------------------------------------------------------------------
        dropdown menu smooth
    -------------------------------------------------------------------------------*/
    function drop_down() {
        $(".dropdown-menu .dropdown-item").on("click", function () {
            $(".dropdown-menu .dropdown-item").removeClass("active");
            $(this).addClass("active");
        });
    }
    drop_down();

    $('#ctn-preloader').fadeOut(); // will first fade out the loading animation
    $('#preloader').delay(350).fadeOut('slow'); // will fade out the white DIV that covers the website.
    $('body').delay(350).css({
        'overflow': 'visible'
    });



})(jQuery);