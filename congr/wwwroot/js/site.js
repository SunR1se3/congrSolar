function changeReady() {
    $('#new_photo').on('change', function () {
        $('#lb_cur_photo').remove();
        $('#photo_cur').remove();
        $('#img-cur-block').append('<div class="alert alert-success" role="alert">Новое фото загружено!</div >');
    });
}
