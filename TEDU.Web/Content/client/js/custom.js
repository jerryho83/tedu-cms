/**
 *
 * Dependencies: jQuery
 *
 */

jQuery.noConflict();

(function ($) {
    $(function () {
        $("#scroller").simplyScroll();
    });
})(jQuery);

jQuery(document).ready(function ($) {

    /*
    * Fix dropdown menu bootstrap error 
    * ------------------------------------------------- */

    $('.nav').find('li:has(ul)').addClass('dropdown');
    $('.dropdown > a').addClass('dropdown-toggle disabled');
    $('li.dropdown').children('ul.sub-menu').addClass('dropdown-menu');

    /*
    * Fix dropdown menu bootstrap error ends
    * --------------------------------------------------------- */

    $('.dropdown .sub-menu').addClass('dropdown-menu');

    $("div.holder").jPages({
        containerID: "itemContainer",
        perPage: 3,
        startPage: 1,
        startRange: 1,
        links: "blank"
    });

    jQuery('a.sidr-class-close-this-menu').click(function () {
        jQuery('div.sidr').css({
            'right': '-476px'
        });
        jQuery('body').css({
            'right': '0'
        });
    });
    jQuery('#btnLogout').off('click').on('click', function (e) {
        e.preventDefault();
        jQuery('#logoutForm').submit();
    });
});

jQuery(document).ready(function ($) {
    $('.dropdown > a').append('<b class="caret"></b>').dropdown();
    $('.dropdown .sub-menu').addClass('dropdown-menu');
});


jQuery(document).ready(function ($) {

    $("#tabnav").idTabs();

});

/* Swipe menu initial js */
jQuery(document).ready(function ($) {

    jQuery('#responsive-menu-button').sidr({
        name: 'sidr-right',
        speed: 50,
        side: 'right',
        source: '#swipe-menu-responsive'
    });
});