$(function () {
    // Ссылка на автоматически-сгенерированный прокси хаба
    var comment = $.connection.commentHub;
    // Объявление функции, которая хаб вызывает при получении сообщений
    comment.client.Send = function (message, name, date, rating) {
        // Добавление сообщений на веб-страницу 
        $('#comments').append(renderRating(rating) + '<p><b>' + htmlEncode(name)
            + '</b>: ' + htmlEncode(message) + '</p>' + '<p><i>' + htmlEncode(date) + '</i></p>')};


    // Открываем соединение
    $.connection.hub.start().done(function () {

        $('#sendmessage').click(function () {
            // Вызываем у хаба метод 
            var userId = document.getElementById("userPageId").value;
            var postId = document.getElementById("modelId").value;
            var content = document.getElementById("message").value;
            var rating = document.getElementById("Rating").value;
            comment.server.comments(postId, content, userId, rating);
            $('#message').val('').focus();
            $("#Rating").val("").focus();
            setDefaultStars();
        });
    });
});
// Кодирование тегов
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}

function renderRating(rating) {
    var result = "";

    for (var i = 1; i <= rating; i++) {
        result += '<span class="starGlowN"></span>';
    }
    for (var i = (rating + 1); i <= 5; i++) {
        result += '<span class="starFadeN"></span>';
    }
    return result;
}

function setDefaultStars() {
    var rate = '#Rate';
    for (var i = 1; i <= 5; i++) {
        var tempRate = rate + i;
        $(tempRate).attr("class", 'starFade');
    }
}