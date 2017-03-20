$(function () {
    var canvas = document.getElementById('canvas'),
        context = canvas.getContext('2d'),
        video = document.getElementById('video'),
       txt = "x",
            vendorUrl = window.URL || window.webkitURL;
    navigator.getMedia = navigator.getUserMedia ||
                             navigator.webkitGetUserMedia ||
                             navigator.mozGetUserMedia ||
                             navigator.msGetUserMedia;


    navigator.getMedia({
        video: true,
        audio: false
    }, function (stream) {
        video.src = vendorUrl.createObjectURL(stream);
        video.play();
    }, function (error) { });
    video.addEventListener('play', function () {
        draw(this, context, 600, 300, txt);
    }
        , false);
    function draw(video, context, width, height, txt) {
        txt = $('#someInput').val();
        context.drawImage(video, 0, 0, width, height);
        context.font = "40pt Calibri";
        context.fillText(txt, 20, 60);
        setTimeout(draw, 10, video, context, width, height, txt);
    }

});