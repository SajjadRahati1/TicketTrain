
//دریافت شهر های پرواز داخلی
$(document).ready(function () {
    $.ajax({
        url: "/Home/SelectCitiesDomesticFlight",
        Data: "",
        success: function (result) {
            if (result.isSuccess) {
                $('.cities').html(addCitiesOptions(result.data));
                $('.cities.select2').select2();
                $($('.cities[name="start-city"]')[0]).val(FromCity).change();
                $($('.cities[name="end-city"]')[0]).val(ToCity).change();

            }
        }
    });

    FindTicket();
})
let isFrom = true;
let flightId1
let flightId2
function FindTicket(isToDate=false) {
    $('.loading').removeClass('d-none')
    $('#no-data').addClass('d-none')
    $('#show-all-tickets').addClass('d-none')
    let date = FromDate;
    if (isToDate) {
        date = ToDate;
        isFrom = false;
    } else {
        isFrom = true;
    }
    $.ajax({
        //contentType: 'application/json; charset=utf-8',
        //dataType: 'json',
        dataType: 'json',
        type: 'GET',
        url: "/DomesticFlight/Tickets",
        async: true,
        data: {
            FromCity: FromCity,
            FromDate: date,
            ToCity: ToCity,
            TravelType: TravelType,
            SeniorPassengerCount: SeniorPassengerCount,
            TeenagerPassnegerCount: TeenagerPassnegerCount,
            BabyPassengerCount: BabyPassengerCount,
        },
        success: function (result) {
            $('.loading').addClass('d-none')
            console.log(result)
            if (!result.isSuccess) {
                toastr.error(result.message);
                return;
            }
            if (result.data.length < 1) {
                $('#no-data').removeClass('d-none')
                $('#show-all-tickets').addClass('d-none')
               
                return;
            }
            $('#show-all-tickets').removeClass('d-none');
            $('#show-all-tickets').html(ShowTickets(result.data));
            /*window.location.pathname = '/DomesticFlight/Index'*/
        },
        failure: function (response) {
            $('#result').html(response);
        }
    })
}
function ShowTickets(data) {
    let resutlTickets=''
    for (var i = 0; i < data.length; i++) {
        resutlTickets+=ShowTicket(data[i])
    }
    return resutlTickets;
}
function ShowTicket(data) {
    // @*d-flex flex-row justify-content-between*@
    const {
        airCraft
        , airlineCode
        , airLineId
        , airlineLogo
        , airlineName
        , Class
        , classTypeID
        , classTypeName
        , commission
        , description
        , destination
        , destinationName
        , discountId
        , discountText
        , domesticFlightId
        , endMovingDateTime
        , endMovingDateTimePersian
        , flightId
        , flightNumber
        , groupRefundRulesTitle
        , isCharter
        , isRefundable
        , isSelectableInRoundtrip
        , maxAllowdBaggage
        , originId
        , originName
        , priceAdult
        , priceChild
        , priceTeenage
        , seat
        , stars
        , startMovingDateTime
        , startMovingDateTimePersian
        , status
        , statusName
        , terminalNumber
    } = data;
    let rules = data.resultTicketRefundRules;
    /* rules:
        DeductibleAmount 
        Description 
        EndHour 
        End_AfterIssuanceTicket 
        End_BeforeFlight 
        IsPercent 
        StartHour 
        Start_AfterIssuanceTicket 
        Start_BeforeFlight 
        Title 
    */
    let showrules = '';
    for (var i = 0; i < rules.length; i++) {
        showrules += `                      <div>
                                                <h5 class='text-danger text-bold'>${rules[i].title}</p>
                                                <p class='text-secondary'>${rules[i].description}</p>
                                            </div>`
    }
    let colPrice = priceAdult * SeniorPassengerCount;
    let showprice = ` <div class='d-flex flex-row justify-content-between w-100'>
                        <p>${SeniorPassengerCount} بزرگسال</p>
                         <div class="price d-flex align-items-center">
                                    <div class="price-number text-blue-2"> ${priceAdult * SeniorPassengerCount}</div>
                                    <span class="px-2">ریال</span>

                                </div>
                      </div>`
    if (TeenagerPassnegerCount > 0) {
        colPrice += priceTeenage * TeenagerPassnegerCount;
        showprice += ` <div class='d-flex flex-row justify-content-between w-100'>
                        <p>${TeenagerPassnegerCount} نوجوان</p>
                         <div class="price d-flex align-items-center">
                                    <div class="price-number text-blue-2"> ${priceTeenage * TeenagerPassnegerCount}</div>
                                    <span class="px-2">ریال</span>

                                </div>
                      </div>`
    }
    if (BabyPassengerCount) {
        colPrice += priceChild * BabyPassengerCount;
        showprice += ` <div class='d-flex flex-row justify-content-between w-100'>
                        <p>${BabyPassengerCount} کودک</p>
                         <div class="price d-flex align-items-center">
                                    <div class="price-number text-blue-2"> ${priceChild * BabyPassengerCount}</div>
                                    <span class="px-2">ریال</span>

                                </div>
                      </div>`;
    }
    showprice += ` <div class='d-flex flex-row justify-content-between w-100'>
                        <p>مجموع</p>
                         <div class="price d-flex align-items-center">
                                    <div class="price-number text-blue-2"> ${colPrice}</div>
                                    <span class="px-2">ریال</span>

                                </div>
                      </div>`;
    let resShow =
        `
        <div class="card card-ticket mt-4 mx-3 px-2 pt-2 border-2 shadow-lg ">
                       
                        <div class="row">
                            <div class="detail-ticket col-9">
                                <div class="d-flex flex-row justify-content-start top-titles">
                                    <span class="top-title text-muted  "><span class="top-title text-muted badge">${airlineCode}</span></span>
                                    <span class="top-title text-bold"></span>
                                    <span class="top-title text-bold">${classTypeName}</span>
                                </div>
                                <div class="d-flex flex-row justify-content-start align-items-center">

                                    <img src="${airlineLogo}" class="provider-logo border shadow" />
                                    <div class="from d-flex flex-row justify-content-start">
                                        <div class="city-show">${originName}</div>
                                        <div class="time-show">${startMovingDateTime.substring(11, 16)}</div>
                                    </div>
                                    <div class="show-way from d-flex flex-row justify-content-start align-items-center">
                                        <i class="las la-plane" style='transform: rotate(-90deg);'></i>
                                        <div class="line"></div>
                                    </div>
                                    <div class="to d-flex flex-row justify-content-start">
                                        <div class="city-show">${destinationName}</div>
                                        <div class="time-show">${endMovingDateTime.substring(11, 16)}</div>
                                    </div>
                                </div>
                                <ul class="links navbar-nav">
                                    <li class='text-blue-1 nav-item info-flight-btn'><a>اطلاعات پرواز</a></li>
                                    <li class='text-blue-1 nav-item rules-flight-btn'><a>قوانین استرداد</a></li>
                                   
                                </ul>
                                <div>
                                    <div class='info-flight p-3 d-none'>
                                        <div class='d-flex flex-row justify-content-between border-top'>
                                            <div>
                                                <p class='text-secondary'>شماره پرواز</p>
                                                <p class='text-bold '>${flightNumber}</p>
                                            </div>
                                            <div>
                                                <p class='text-secondary'>ترمینال</p>
                                                <p class='text-bold '>${terminalNumber}</p>
                                            </div>
                                            <div>
                                                <p class='text-secondary'>مقدار بار مجاز</p>
                                                <p class='text-bold '>${maxAllowdBaggage}</p>
                                            </div>
                                            <div>
                                                <p class='text-secondary'>پرواز</p>
                                                <p class='text-bold '>${flightId}</p>
                                            </div>
                                        </div>
                                        <div class='close-info text-blue-1 nav-item rules-flight-btn text-center'>بستن</div>
                                    </div>

                                    <div class='rules-flight p-3 d-none'>
                                        <p class='text-gray'>درصد جریمه کسر شده بر اساس زمان اعلام کنسلی</p>
                                        <div class='d-flex flex-row justify-content-between border-top'>
                                           ${showrules}
                                        </div>
                                        <div class='close-info text-blue-1 nav-item rules-flight-btn text-center'>بستن</div>
                                    </div>

                                </div>
                            </div>
                            <div class="price-ticket col-3 d-flex ">
                                ${showprice}
                                <button class="btn text-white btn-search select-ticket-btn" data-flightid=${flightId}>انتخاب بلیط</button>
                                <span class="mt-2 ${(seat <= 5 ? "text-danger" : "")} text-small">${seat} صندلی باقی مانده</span>

                            </div>
                        </div>
                    </div>
    `;
    return resShow;
}
/*
 @*class="active"*@
*/

$(document).on('click', '.rules-flight-btn', function () {
    $('.rules-flight-btn').removeClass('active')
    $('.info-flight-btn').removeClass('active')
    $('.rules-flight').addClass('d-none')
    $('.info-flight').addClass('d-none')
    $(this).addClass('active');

    $($($(this).parents('.detail-ticket')).find('.rules-flight')).removeClass('d-none');
})
$(document).on('click', '.info-flight-btn', function () {
    $('.rules-flight-btn').removeClass('active')
    $('.info-flight-btn').removeClass('active')
    $('.rules-flight').addClass('d-none')
    $('.info-flight').addClass('d-none')
    $(this).addClass('active');

    $($($(this).parents('.detail-ticket')).find('.info-flight')).removeClass('d-none');
})
$(document).on('click', '.close-info', function () {
    $('.rules-flight-btn').removeClass('active')
    $('.info-flight-btn').removeClass('active')
    $('.rules-flight').addClass('d-none')
    $('.info-flight').addClass('d-none')
   
})

$(document).on('click', '#search-flight', function () {
   
    FromCity = $(`select[name='start-city']`).val()
    ToCity = $(`select[name='end-city']`).val()
    FromDate = $(`[name='from-date']`).val()
    ToDate = $(`[name='to-date']`).val()
   
    FromCity = Number(FromCity)
    ToCity = Number(ToCity)
  
    FindTicket();
})


//دریافت بلیط
$(document).on('click', '.select-ticket-btn', function () {
    let thisFlightId = Number($(this).attr('data-flightid'))
    if (TravelType == 2) {
        if (isFrom) {
            flightId1 = thisFlightId;
        } else {
            flightId2 = thisFlightId;
            window.location.href = window.location.origin + '/DomesticFlight/SelectTicket?id=' + flightId1 + '&id2=' + flightId2
        }
    } else {

        window.location.href = window.location.origin + '/DomesticFlight/SelectTicket?id=' + thisFlightId + '&id2=' + 0;
    }

    //if (TravelType == 2) {
    //    FindTicket(isToDate)
    //}
    if (TravelType == 2) {

    }
});