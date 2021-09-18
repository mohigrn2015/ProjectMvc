
(function ($) {
	"use strict";
	/*
	var wind = $(window);
	var jQwind = jQuery(window);
	var jQdoc = jQuery(document);
	 
	 */


		/*=============================================*/
		/*------------- [_Owl_Carousel] ---------------*/
		/*=============================================*/

		/*------------- [_home_carousel] --------------*/
		function home_carousel() {
			var owl = $(".home-carousel");
			owl.owlCarousel({
				loop: true,
				margin: 0,
				nav: true,
				dots: false,
				animateOut: 'fadeOut',
				animateIn: 'fadeIn',
				active: true,
				autoplay: false,
				smartSpeed: 1000,
				autoplayTimeout: 8000,
				navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
				responsive: {
					0: {
						items: 1
					},
					425: {
						items: 1
					},
					768: {
						items: 1
					},
					1024: {
						items: 1
					},
					1440: {
						items: 1
					}
				}
			});
		}
		home_carousel();

}(jQuery));