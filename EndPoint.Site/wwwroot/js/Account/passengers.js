function showAddPassengerModal() {
    $("#add-edit-modal").modal("show");
}

//انتخاب تاریخ :
$(document).ready(function () {

    window.to = $(".passenger-date").persianDatepicker({
        inline: true,
        altField: '.passenger-date-input',
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
