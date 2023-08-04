﻿//انتخاب نوع مسافرت
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
        onSelect: function (unix) {
            to.touched = true;
            if (from && from.options && from.options.maxDate != unix) {
                var cachedValue = from.getState().selected.unixDate;
                from.options = { maxDate: unix };
                if (from.touched) {
                    from.setDate(cachedValue);
                }
            }
        }
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

$(document).on('click', '#domestic-flight-show-big .btn-search', function () {
    let travelType = $(`#domestic-flight-show-big select[name='travel-type']`).val()
    let fromCity = $(`#domestic-flight-show-big select[name='start-city']`).val()
    let toCity = $(`#domestic-flight-show-big select[name='end-city']`).val()
    let fromDate = $(`#domestic-flight-show-big [name='from-date']`).val()
    let toDate = $(`#domestic-flight-show-big [name='to-date']`).val()
    travelType = Number(travelType)
    fromCity = Number(fromCity)
    toCity = Number(toCity)
    let req = {
        fromCity: fromCity,
        fromDate: fromDate,
        toCity: toCity,
        toDate: toDate,
        travelType: travelType
    }
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
            toCity: toCity,
            toDate: toDate,
            travelType: travelType
        },
        success: function (result) {
            console.log(result)
        },
        failure: function (response) {
            $('#result').html(response);
        }
    });
})