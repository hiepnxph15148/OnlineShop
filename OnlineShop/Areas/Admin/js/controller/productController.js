/* <><script src="http://code.jquery.com/jquery-1.9.1.js"></script><script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.0/jquery.min.js"></script></>*/
var product = {
    init: function () {
        product.ProductEvents();
    },

    ProductEvents: function () {
        $('.btn-active2').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = $(this).data('id');
            $.ajax({
                type: "Get",
                url: "/Admin/Product/ChangeStatus?id=" + id,
                //data: { id: id },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text('Còn hàng');

                    } else {
                        btn.text('hết hàng');
                    }
                }
            });
        });
    }
}
product.init();