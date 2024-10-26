//انتخاب نوع مسافرت
$(document).on("click", ".choose-travel .show-big .card .choose-type a", function () {
    let newTypeId = this.id;
    let lastTypeId = $(".choose-travel .show-big .card .choose-type a.active")[0].id;
    $(`#${lastTypeId}`).removeClass("active");
    $(this).addClass("active");

    newTypeId = newTypeId.replace('-btn', '');
    lastTypeId = lastTypeId.replace('-btn', '');
    $(`#${lastTypeId}`).addClass('d-none')
    $(`#${newTypeId}`).removeClass('d-none');


    newTypeId = newTypeId.replace('-show-big', '-img');
    lastTypeId = lastTypeId.replace('-show-big', '-img');
    $(`.${lastTypeId}`).addClass('d-none')
    $(`.${newTypeId}`).removeClass('d-none');

});


//انتخاب تاریخ :
$(document).ready(function () {

    window.to = $(".to-date").persianDatepicker({
        inline: true,
        altField: '.to-date-input',
        altFormat: 'YYYY/MM/DD',
        format: 'YYYY/MM/DD',
        initialValue: false,
        observer: true,
        minDate: new persianDate().valueOf(),
        //maxDate: new persianDate().add('day', 10).valueOf(),
        //onSelect: function (unix) {
        //    to.touched = true;
        //    if (from && from.options && from.options.maxDate != unix) {
        //        var cachedValue = from.getState().selected.unixDate;
        //        from.options = { maxDate: unix };
        //        if (from.touched) {
        //            from.setDate(cachedValue);
        //        }
        //    }
        //}
    });
    window.from = $(".from-date").persianDatepicker({
        inline: true,
        altField: '.from-date-input',
        altFormat: 'YYYY/MM/DD',
        format: 'YYYY/MM/DD',
        initialValue: false,
        observer: true,
        minDate: new persianDate().valueOf(),
        //maxDate: new persianDate().add('day', 10).valueOf(),
        onSelect: function (unix) {
            from.touched = true;
            if (to && to.options && to.options.minDate != unix) {
                var cachedValue = to.getState().selected.unixDate;
                to.options = { minDate: unix };
                if (to.touched) {
                    to.setDate(cachedValue);
                }
            }
        }
    });

});
//انتخاب تاریخ :
$(document).ready(function () {

    window.to = $(".just-date").persianDatepicker({
        inline: true,
        altField: '.just-date-input',
        altFormat: 'YYYY/MM/DD',
        format: 'YYYY/MM/DD',
        initialValue: false,
        observer: true,
        //minDate: new persianDate().valueOf(),
        maxDate: new persianDate().valueOf()
        //onSelect: function (unix) {
        //    to.touched = true;
        //    if (from && from.options && from.options.maxDate != unix) {
        //        var cachedValue = from.getState().selected.unixDate;
        //        from.options = { maxDate: unix };
        //        if (from.touched) {
        //            from.setDate(cachedValue);
        //        }
        //    }
        //}
    });


});

$(document).on('click', '.choose-type>a:not(.active)', function () {
    typeId.replace('-btn', '');

})

//دریافت شهر های پرواز داخلی
$(document).ready(function () {
    $.ajax({
        url: "/Home/SelectCitiesDomesticFlight",
        Data: "",
        success: function (result) {
            if (result.isSuccess) {
                $('#domestic-flight-show-big .cities').html(addCitiesOptions(result.data));
                $('#domestic-flight-show-big .cities.select2').select2();
            }
        }
    });
})

$(document).on('click', '#domestic-flight-show-big .btn-search', function () {
    let travelType = $(`#domestic-flight-show-big select[name='travel-type']`).val()
    let fromCity = $(`#domestic-flight-show-big select[name='start-city']`).val()
    let toCity = $(`#domestic-flight-show-big select[name='end-city']`).val()
    let fromDate = $(`#domestic-flight-show-big [name='from-date']`).val()
    let toDate = $(`#domestic-flight-show-big [name='to-date']`).val()
    if (travelType == "1") {

        fromDate = $(`#domestic-flight-show-big [name='just-date']`).val()
    }
    let seniorPassengerCount = $(`#domestic-flight-show-big [name='passengers']`).attr('val-big')
    let teenagerPassnegerCount = $(`#domestic-flight-show-big [name='passengers']`).attr('val-avg')
    let babyPassengerCount = $(`#domestic-flight-show-big [name='passengers']`).attr('val-min')
    travelType = Number(travelType)
    fromCity = Number(fromCity)
    toCity = Number(toCity)
    seniorPassengerCount = Number(seniorPassengerCount)
    teenagerPassnegerCount = Number(teenagerPassnegerCount)
    babyPassengerCount = Number(babyPassengerCount)
    
    $.ajax({
        //contentType: 'application/json; charset=utf-8',
        //dataType: 'json',
        dataType: 'json',
        type: 'POST',
        url: "/Home/SearchDomesticFlightTravel",
        async: true,
        data: {
            FromCity: fromCity,
            FromDate: fromDate,
            ToCity: toCity,
            ToDate: toDate,
            TravelType: travelType,
            SeniorPassengerCount: seniorPassengerCount,
            TeenagerPassnegerCount: teenagerPassnegerCount,
            BabyPassengerCount: babyPassengerCount,
        },
        success: function (result) {
            console.log(result)
            if (!result.isSuccess) {
                toastr.error(result.message);
                return;
            }

            window.location.pathname = '/DomesticFlight/Index'
        },
        failure: function (response) {
            $('#result').html(response);
        }
    });
})

$(document).on('change', '#travel-type', function () {
    let type = this.value;

    if (type == 1) {
        $(".duplicate-date-group").addClass("d-none");
        $(".date-group").removeClass("d-none");
    } else {
        $(".duplicate-date-group").removeClass("d-none");
        $(".date-group").addClass("d-none");
    }

})