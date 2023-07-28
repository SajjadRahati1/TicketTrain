//برای تنظیم اسکرول های فانکشن
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (window.innerWidth <= 575) {
        if (document.documentElement.scrollTop > 100) {
            scrollDownPhone();
        } else {
            scrollUpPhone();
        }
    }
    
}
function scrollDownPhone() {
    $(".show-small").addClass("down-scroll")
}
function scrollUpPhone() {
    $(".show-small").removeClass("down-scroll");

}
function showLoginModal() {
    $("#login-modal").modal("show");
}
$('.modal .close').on('click', function () {
    $($(this).parents('.modal')).modal('toggle')
})

$("input").on("click", function () {
    let thisInput = this;

    //for data picker
    $(".date-div.active").removeClass("active");
    let datepickera = $($(thisInput).parent()[0]).children(".date-div")
    datepickera.addClass("active");
});
/*$(document).on('input', "input", function () {*/
//$("input").on("input", function () {
//    alert("testtttt");
//})
$(".input-group").on("blur", function () {
    let thisInput = this;

    //for data picker
    let datepickera = $($(thisInput).parent()[0]).children(".date-div")
    datepickera.removeClass("active");
});

$(document).on("dblclick", function () {

    $(".date-div.active").removeClass("active");
})
$(document).on('click', '.date-div.pwt-datepicker-input-element .table-days td', function () {
    if ($(this).hasClass("selected")) {
        $(".date-div.active").removeClass("active");
    }
});
$(document).on('click', 'body', function (e) {
    //if (!$(e.target).hasClass("date-div") && !$(e.target).parents(".date-div").length && $(e.target).not("input.date-input").length)
    if (
        !$('.date-div.active').find($(e.target)).length &&
        $(e.target).not("input.date-input").length &&
        !$(e.target).parents('.datepicker-persian').length 
    )
        $(".date-div.active").removeClass("active");
})
/*ایجاد همه سلکت ها به صورت سلکت 2*/

$(document).ready(function () {
    $('.input-group:not(.mini-select) .select2').select2();

    let $miniSelects;
    $miniSelects = $('.input-group.mini-select .select2').select2();
    if (!$miniSelects.length)
        return;
    $miniSelects.data().select2.$dropdown.addClass("mini-select2");

    for (var i = 0; i < $miniSelects.length; i++) {
        $($miniSelects[i]).data().select2.$dropdown.addClass("mini-select2")
    }
});
$(document).on('click', '.input-group-start-end .btn.input-change', function () {
   let parent_btn_change = $(this).parent('.input-group-start-end')[0];

    //let startVal = $($(parent_btn_change).children(".input-group")[0]).children('select')[0];
    //let endVal = $($(parent_btn_change).children(".input-group")[1]).children('select')[0];
    
    let startVal = $($(".input-group-start-end select")[0]).val();
    let endVal = $($(".input-group-start-end select")[1]).val();

    $($(".input-group-start-end select")[0]).val(endVal).change();
    $($(".input-group-start-end select")[1]).val(startVal).change();

});
