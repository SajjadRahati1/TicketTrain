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