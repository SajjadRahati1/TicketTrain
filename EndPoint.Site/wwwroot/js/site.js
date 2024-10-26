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
function addCitiesOptions(vals) {
    let val = null;
    let result = ""
    for (var i = 0; i < vals.length; i++) {
        val = vals[i]
        result +=
            `<option value='${val.cityId}' val-icon='la-map-marker'>
                <div class='d-flex flex-column gap-3 justify'>
                    <i class='la la-map-marker'>
                    <div>
                        <p class='p-0 m-0 mb-2'>${val.cityName}</p>
                        <p class='p-0 m-0 mb-2 text-muted'>${val.stateName}</p>
                    </div>
                </div>
            </option>`
    }
    return result;
}




//const requestIndexDF = indexedDB.open('DFIndex', 1);
//requestIndexDF.onerror = (event) => {
//    console.error(`Database error: ${event.target.errorCode}`);
//};

//requestIndexDF.onsuccess = (event) => {
//    // add implementation here
//};
//// create the Contacts object store and indexes
//requestIndexDF.onupgradeneeded = (event) => {
//    let db = event.target.result;

//    // create the Contacts object store 
//    // with auto-increment id
//    let store = db.createObjectStore('Flights', {
//        autoIncrement: true
//    });

//    // create an index on the email property
//    //let index = store.createIndex('email', 'email', {
//    //    unique: true
//    //});
//};
//function insertDFIndex(db, flight) {
//    // create a new transaction
//    const txn = db.transaction('Flights', 'readwrite');

//    // get the Contacts object store
//    const store = txn.objectStore('Flights');
//    //
//    let query = store.put(contact);

//    // handle success case
//    query.onsuccess = function (event) {
//        console.log(event);
//    };

//    // handle the error case
//    query.onerror = function (event) {
//        console.log(event.target.errorCode);
//    }

//    // close the database once the 
//    // transaction completes
//    txn.oncomplete = function () {
//        db.close();
//    };
//}