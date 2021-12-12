var cart = {
    init: function() {
        cart.regEvents();
    },
    regEvents: function() {
        $('#btnContinute').off('click').on('click', function() {
            window.location.href = "/danh-sach-san-pham";
        });

        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.quantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        id: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    } else {

                    }
                }
            })
        });

        $('#btnDelete').off('click').on('click', function () {
            

            $.ajax({
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    } else {

                    }
                }
            })
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: {id:$(this).data('id')},
                url: '/Cart/DeleteOne',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    } else {

                    }
                }
            })
        });

        $('#btnPay').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });

        $('#btnDelete2').off('click').on('click', function () {


            $.ajax({
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/thanh-toan";
                    } else {

                    }
                }
            })
        });
    }
}
cart.init();