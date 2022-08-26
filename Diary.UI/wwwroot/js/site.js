



$(document).ready(function () {
    "use strict";


    $(".sidebar-toggle").on("click", function () {
        $(".sidebar").toggleClass("toggled").one("transitionend", function () {
            setTimeout(function () {
                window.dispatchEvent(new Event("resize"))
            }, 100);
        });

        if ($(".sidebar").hasClass('toggled')) {
            $(".main").animate({
                marginLeft: '0px'
            }, 400);
        } else {
            $(".main").animate({
                marginLeft: '225px'
            }, 400);

        }



    });

    $(".sidebar-item").on('click', function () {
        $('.collapse').collapse('hide');
    });

    var e = $(".sidebar .active");
    if (e.length && e.parent(".collapse").length) {
        var l = e.parent(".collapse");
        l.prev("a").attr("aria-expanded", !0), l.addClass("show")
    }

    fnScrollbar();
    function fnScrollbar() {

        var wdheight = $(window).height();
        $(".sidebar-content .sidebar-nav").css("height", wdheight + "px");
        $(".sidebar-content .sidebar-nav").perfectScrollbar();
    }


    $(window).resize(function () {
        fnScrollbar();
    });

    feather.replace();

    $(".spnShow").on('click', function () {
        $(this).closest('.showcode').toggleClass("active");
    });
    $("#loaderbody").addClass('hide');

    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
    var ShowModel = $("#Add");
    $('button[data-toggle]').click(function () {
        $('.modal-content .modal-body').empty();
       
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            ShowModel.html(data);
            ShowModel.find('.modal').modal({ show: true })
        });

    });
});

showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}