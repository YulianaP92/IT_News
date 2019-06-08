$(function () {
    // Ссылка на автоматически-сгенерированный прокси хаба
    var comment = $.connection.commentHub;
    // Объявление функции, которая хаб вызывает при получении сообщений
    comment.client.Send = function (message, name,date) {
        // Добавление сообщений на веб-страницу 
        $('#comments').append('<p><b>' + htmlEncode(name)
            + '</b>: ' + htmlEncode(message) + '</p>' + '<p>' + htmlEncode(date) + '</p>');
    };

   
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
        });
    });
});
// Кодирование тегов
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}
