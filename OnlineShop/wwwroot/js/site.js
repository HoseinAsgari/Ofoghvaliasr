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
