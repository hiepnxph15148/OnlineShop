/* <><script src="http://code.jquery.com/jquery-1.9.1.js"></script><script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.0/jquery.min.js"></script></>*/
var user = {
    init: function () {
        user.registerEvents();
    },

    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = $(this).data('id');
            $.ajax({
                type: "Get",
                url: "/Admin/User/ChangeStatus?id=" + id,
                //data: { id: id },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text('Activated');

                    } else {
                        btn.text('Lock up');
                    }
                }
            });
        });
    }
}
user.init();