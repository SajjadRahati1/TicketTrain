let resultShow = `
<div class='modal-count-passenger'>
    <div class='type-passenger'>
        <div class='text-passenger'>
           بزرگسال
           <span class="text-muted px-2 ">(12 سال به بالا)</span>
        </div>
        <div>
            <button class='btn btn-primary text-white   btn-plus big-12' >+</button>
            <span class='count-select big-12 px-2'>1</span>
            <button class='btn btn-primary text-white   btn-minus big-12 disabled' disabled>-</button>
        </div>
    </div>
    <div class='type-passenger'>
        <div class='text-passenger'>
           کودک
           <span class="text-muted px-2 ">(2 تا 12 سال)</span>
        </div>
        <div>
            <button class='btn btn-primary text-white   btn-plus avg-2-12' >+</button>
            <span class='count-select avg-2-12 px-2'>0</span>
            <button class='btn btn-primary text-white   btn-minus avg-2-12 disabled' disabled>-</button>
        </div>
    </div>
    <div class='type-passenger'>
        <div class='text-passenger'>
           نوزاد
           <span class="text-muted px-2 ">(10 روز تا 2 سال)</span>
        </div>
        <div>
            <button class='btn btn-primary text-white   btn-plus min-2' >+</button>
            <span class='count-select min-2 px-2'>0</span>
            <button class='btn btn-primary text-white btn-minus min-2 disabled' disabled>-</button>
        </div>
    </div>
<div>
`
let bigPassenger = 1
let avgPassenger = 0
let minPassenger = 0
let checkForCloseModalPassennger = false;
$(document).on("click", '.count-passanger-input', function () {
    if (!$(this.parentElement).children('.modal-count-passenger').length) {
        $(this.parentElement).append(resultShow);
        bigPassenger  =Number($("input.count-passanger-input").attr('val-big'));
        avgPassenger  =Number($("input.count-passanger-input").attr('val-avg'));
        minPassenger  =Number($("input.count-passanger-input").attr('val-min'));
        changeBig12(0)
        changeAvg2_12(0)
        changeMin2(0)
        setTimeout(() => checkForCloseModalPassennger = true, 500);
    }
});
$(document).on('click', '.modal-count-passenger .btn', function () {
    if ($(this).hasClass("btn-plus")) {
        plusPassenger(this);
    }
    else if ($(this).hasClass('btn-minus')) {
        minusPassenger(this);
    }
})
function plusPassenger(btn) {
    if ($(btn).hasClass('big-12')) {
        changeBig12(1)
    } else if ($(btn).hasClass('avg-2-12')) {
        changeAvg2_12(1)

    } else if ($(btn).hasClass('min-2')) {
        changeMin2(1)

    }
}
function minusPassenger(btn) {
    if ($(btn).hasClass('big-12')) {
        changeBig12(-1);
    } else if ($(btn).hasClass('avg-2-12')) {
        changeAvg2_12(-1);
    } else if ($(btn).hasClass('min-2')) {
        changeMin2(-1);
    }
}
function changeBig12(value) {
    bigPassenger += (value);
    $('.count-select.big-12').text(bigPassenger);
    if (bigPassenger > 1) {
        $('.btn-minus.big-12').removeAttr('disabled')
        $('.btn-minus.big-12').removeClass('disabled')
    } else {
        $('.btn-minus.big-12').attr('disabled')
        $('.btn-minus.big-12').addClass('disabled')
    }
}
function changeAvg2_12(value) {
    avgPassenger += (value);
    $('.count-select.avg-2-12').text(avgPassenger);
    if (avgPassenger > 0) {
        $('.btn-minus.avg-2-12').removeAttr('disabled')
        $('.btn-minus.avg-2-12').removeClass('disabled')
    }
    else {
        $('.btn-minus.avg-2-12').attr('disabled')
        $('.btn-minus.avg-2-12').addClass('disabled')
    }
}
function changeMin2(value) {
    minPassenger += (value);
    $('.count-select.min-2').text(minPassenger);
    if (minPassenger > 0) {
        $('.btn-minus.min-2').removeAttr('disabled')
        $('.btn-minus.min-2').removeClass('disabled')
    } else {
        $('.btn-minus.min-2').attr('disabled')
        $('.btn-minus.min-2').addClass('disabled')
    }
}
$(document).on('click', 'body', function (e) {
    if (!checkForCloseModalPassennger)
        return;
    if (!$(e.target).hasClass("modal-count-passenger") &&
        !$(e.target).parents(".modal-count-passenger").length &&
        !$(e.target).hasClass("input.count-passanger-input") &&
        !$(e.target).parents("input.count-passanger-input").length) {
        $(".modal-count-passenger").remove();
        $("input.count-passanger-input").removeAttr('readonly')
        $("input.count-passanger-input").val((bigPassenger + minPassenger + avgPassenger) + " مسافر");
        $("input.count-passanger-input").attr('val-big', bigPassenger);
        $("input.count-passanger-input").attr('val-avg', avgPassenger);
        $("input.count-passanger-input").attr('val-min', minPassenger);
        $("input.count-passanger-input").attr('readonly','readonly')

        checkForCloseModalPassennger = false;
    }
})