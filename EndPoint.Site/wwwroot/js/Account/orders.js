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

$(document).on('focus', '.form-group .input-group input', function () {
    $(this).parents('.form-group .input-group').addClass('focus');
})

$(document).on('blur', '.form-group .input-group input', function () {
    $(this).parents('.form-group .input-group').removeClass('focus');
})
$(document).on('focus', '.form-group .input-group select', function () {
    $(this).parents('.form-group .input-group').addClass('focus');
})

$(document).on('blur', '.form-group .input-group select', function () {
    $(this).parents('.form-group .input-group').removeClass('focus');
})
