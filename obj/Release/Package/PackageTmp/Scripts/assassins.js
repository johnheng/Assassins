$(document).ready(function () {
    //$("#mainButton").click(function () {
    //    $('<div class="alert alert-info" role="alert">' + new Date($.now()) + '</div>')
    //    .hide().prependTo(".jumbotron").slideDown("slow");
    //});
    $("abbr.timeago").timeago();

    $(function () {
        $(".dial").knob({
                'readOnly':true
            });
    });

    

    $("#events").click(function () {
        $(".event").slideToggle("slow");
        $("#eventsToggle").toggleClass("fa-square-o");
        $("#eventsToggle").toggleClass("fa-check-square-o");
        return false;
    })

    $("#comments").click(function () {
        $(".comment").slideToggle("slow");
        $("#commentsToggle").toggleClass("fa-square-o");
        $("#commentsToggle").toggleClass("fa-check-square-o");
        return false;
    })

    $("#join").click(function () {
        $(".join").slideToggle("slow");
        $("#joinToggle").toggleClass("fa-square-o");
        $("#joinToggle").toggleClass("fa-check-square-o");
        return false;
    })

});

$(window).load(function () {
    $(".imagecontainer").each(function () {
        var refRatio = 1;

        var imgH = $(this).children("img").height();
        var imgW = $(this).children("img").width();

        console.log(imgH + " " + imgW);

        if (imgW <= imgH) {
            $(this).addClass("portrait");
            $(this).children("img").addClass("absolute");
        } else {
            $(this).addClass("landscape");
            $(this).children("img").addClass("absolute");
        }
    })
});

$(function () {
    $('[data-toggle="popover"]').popover({ trigger: "hover" })
})

/*jQuery*/

$(function () {
    var ink, d, x, y;
    $(".ripple").click(function (e) {
        if ($(this).find(".ink").length === 0) {
            $(this).prepend("<span class='ink'></span>");
        }

        ink = $(this).find(".ink");
        ink.removeClass("animate");

        if (!ink.height() && !ink.width()) {
            d = Math.max($(this).outerWidth(), $(this).outerHeight());
            ink.css({ height: d, width: d });
        }

        x = e.pageX - $(this).offset().left - ink.width() / 2;
        y = e.pageY - $(this).offset().top - ink.height() / 2;

        ink.css({ top: y + 'px', left: x + 'px' }).addClass("animate");
    });
});

$(".dropdown-toggle").click(function () {
    $('.dropdown-toggle').dropdown();
})

    /**
 * Author: Heather Corey
 * jQuery Simple Parallax Plugin
 *
 */

    jQuery(function ($) {

        $.fn.parallax = function (options) {

            var windowHeight = $(window).height();

            // Establish default settings
            var settings = $.extend({
                speed: 0.15
            }, options);

            // Iterate over each object in collection
            return this.each(function () {

                // Save a reference to the element
                var $this = $(this);

                // Set up Scroll Handler
                $(document).scroll(function () {

                    var scrollTop = $(window).scrollTop();
                    var offset = $this.offset().top;
                    var height = $this.outerHeight();

                    // Check if above or below viewport
                    if (offset + height <= scrollTop || offset >= scrollTop + windowHeight) {
                        return;
                    }

                    var yBgPosition = Math.round((offset - scrollTop) * settings.speed);

                    // Apply the Y Background Position to Set the Parallax Effect
                    $this.css('background-position', 'center ' + yBgPosition + 'px');

                });
            });
        }
    }(jQuery));

if ($(window).width() > 375) {
    $('#headerwrap').parallax({
        speed: 0.45
    });

    $('#portfoliowrap').parallax({
        speed: 0.25
    });
}


(function () {
    var findTarget = function (target) {
        var i, toggles = document.querySelectorAll('.toggle');
        for (; target && target !== document; target = target.parentNode) {
            for (i = toggles.length; i--;) { if (toggles[i] === target) return target; }
        }
    };

    var getTarget = function (e) {
        var target = findTarget(e.target);
        if (!target) return;
        return target;
    };

    var handleClick = function (e) {
        var target = getTarget(e);
        if (!target) return;
        else e.preventDefault();
        toggleMenu(target);
    };

    var toggleMenu = function (target) {
        var icon = target.querySelector(".icon");
        icon.classList.add("transitioning");
        icon.addEventListener("webkitAnimationEnd", onAnimationEnd, false);

        function onAnimationEnd(e) {
            icon.classList.toggle("active");
            icon.classList.remove("transitioning");
            e.stopImmediatePropagation();
        }
    };

    document.addEventListener("click", handleClick, false);
})();

$(window, document, undefined).ready(function () {

    $('input').blur(function () {
        var $this = $(this);
        if ($this.val())
            $this.addClass('used');
        else
            $this.removeClass('used');
    });

    var $ripples = $('.ripples');

    $ripples.on('click.Ripples', function (e) {

        var $this = $(this);
        var $offset = $this.parent().offset();
        var $circle = $this.find('.ripplesCircle');

        var x = e.pageX - $offset.left;
        var y = e.pageY - $offset.top;

        $circle.css({
            top: y + 'px',
            left: x + 'px'
        });

        $this.addClass('is-active');

    });

    $ripples.on('animationend webkitAnimationEnd mozAnimationEnd oanimationend MSAnimationEnd', function (e) {
        $(this).removeClass('is-active');
    });

});