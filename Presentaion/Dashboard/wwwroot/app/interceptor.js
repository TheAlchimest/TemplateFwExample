
(function (send) {
    XMLHttpRequest.prototype.send = function (data) {
        this.setRequestHeader('Accept-Language', 'ar-EG');
        send.call(this, data);
    };
})(XMLHttpRequest.prototype.send);