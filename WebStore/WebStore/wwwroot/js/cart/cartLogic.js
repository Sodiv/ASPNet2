Cart = {
    _properties: {
        addToCartLink: '',
        getCartViewLink: '',
        removeFromCartLink: '',
        decrementLink: ''
    },
    init: function (properties) {
        $.extend(Cart._properties, properties);
        Cart.initAddToCart();
    },
    initAddToCart: function () {
        $('a.callAddToCart').on("click", Cart.addToCart);
        $('.cart_quantity_delete').on('click', Cart.removeFromCart);
        $('.cart_quantity_up').on('click', Cart.incrementItem);
        $('.cart_quantity_down').on('click', Cart.decrementItem);
    },
    addToCart: function (event) {
        var button = $(this);
        event.preventDefault();
        var id = button.data('id');
        $.get(Cart._properties.addToCartLink + '/' + id).done(function () {
            Cart.showToolTip(button);
            Cart.refreshCartView();
        }).fail(function () { cons.log('addToCart error'); });
    },
    refreshCartView: function () {
        var container = $("#cartContainer");
        $.get(Cart._properties.getCartViewLink).done(function (result) {
            container.html(result);
        }).fail(function () { cons.log('refreshCartView error'); });
    },
    showToolTip: function (button) {
        button.tooltip({
            title: "Добавлено в корзину"
        }).tooltip('show');
        setTimeout(function () {
            button.tooltip('destroy');
        }, 500);
    },
    removeFromCart: function (event) {
        var button = $(this);
        event.preventDefault();
        var id = button.data('id');
        $.get(Cart._properties.removeFromCartLink + '/' + id).done(function () {
            button.closest('tr').remove();
            Cart.refreshCartView();
        }).fail(function () { console.log('addToCart error'); });
    },
    incrementItem: function (event) {
        var button = $(this);
        var container = button.closest('tr');
        event.preventDefault();
        var id = button.data('id');
        $.get(Cart._properties.addToCartLink + '/' + id).done(function () {
            var value = parseInt($('.cart_quantity_input', container).val());
            $('.cart_quantity_input', container).val(value + 1);
            Cart.refreshPrice(container);
            Cart.refreshCartView();
        }).fail(function () { console.log('addToCart error'); });
    },
    decrementItem: function () {
        var button = $(this);
        var container = button.closest('tr');
        event.preventDefault();
        var id = button.data('id');
        $.get(Cart._properties.decrementLink + '/' + id).done(function () {
            var value = parseInt($('.cart_quantity_input', container).val());
            if (value > 1) {
                $('.cart_quantity_input', container).val(value - 1);
                Cart.refreshPrice(container);
            } else {
                container.remove();
                Cart.refreshTotalPrice();
            }
            Cart.refreshCartView();
        }).fail(function(){ console.log('addToCart error'); });
    },
    refreshPrice: function (container) {
        var quantity = parseInt($('.cart_quantity_input', container).val());
        var price = parseFloat($('.cart_price', container).data('price'));
        var totalPrice = quantity * price;
        var value = totalPrice.toLocaleString('ru-RU', { style: 'currency', currency: 'RUB' });
        $('.cart_total_price', container).data('price', totalPrice);
        $('.cart_total_price', container).html(value);
        Cart.refreshTotalPrice();
    },
    refreshTotalPrice: function () {
        var total = 0;
        $('.cart_total_price').each(function () {
            var price = parseFloat($(this).data('price'));
            total += price;
        });
        var value = total.toLocaleString('ru-RU', { style: 'currency', currency: 'RUB' });
        $('#totalOrderSum').html(value);
    }
}