function productLiked(productId) {
    var getData = new XMLHttpRequest();
    getData.open("GET", "/Product/ProductLiked/" + productId);
    getData.onload = function () {
        if (this.response.includes('<html')) {
            alert('برای لایک کردن باید به اکانت خود وارد شوید');
            document.write(this.response);
        }
    };
    getData.send();
}

function addToCart(productId) {
    var count = document.getElementById('quantity_value').innerHTML;
    var getData = new XMLHttpRequest();
    getData.open("GET", "/Cart/AddToCart/" + productId + '?count=' + count);
    getData.onload = function () {
        alert('کالا با موفقیت به سبد خرید شما اضافه شد!!');
    };
    getData.send();
}

function pictureUploaded(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            document.getElementById("show-image").attributes.item('src').value = e.target.result;
        };

        reader.readAsDataURL(input.files[0]);
    }
}