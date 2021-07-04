function productLiked(productId) {
    var getData = new XMLHttpRequest();
    getData.open("GET", "/Account/SendActivationCode/" + productId);
    getData.send();
}
