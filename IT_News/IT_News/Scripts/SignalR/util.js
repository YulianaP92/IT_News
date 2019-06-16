$(function () {
    // Ссылка на автоматически-сгенерированный прокси хаба
    var comment = $.connection.commentHub;
    // Объявление функции, которая хаб вызывает при получении сообщений
    comment.client.Send = function (message, name, date, rating) {
        // Добавление сообщений на веб-страницу 
        $('#comments').append(renderRating(rating) + '<p><b>' + htmlEncode(name)
            + '</b>: ' + htmlEncode(message) + " " /*+ likeV()*/ +'</p>' + '<p><i>' + htmlEncode(date) + '</i></p>')};

    comment.client.TotalRatingSend = function (totalDecimal) {
        $('#starMain').html("");
        $('#starMain').append(setTotalStars(totalDecimal))};
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
            var totalDecimal = 0;
            comment.server.show(totalDecimal, postId);
        });
    });
});

$(function () {
    var postClient = $.connection.likeCommentHub;
    postClient.client.updateLikeCount = function (post) {

        var counter = $(".like-count");
        $(counter).fadeOut(function () {
            $(this).text(post);
            $(this).fadeIn();
        });
    };

        [].forEach.call(document.querySelectorAll(".like-button"), function (item) {
            item.addEventListener("click", function () {
                var comment = item.closest("a").getElementsByTagName("input")[0].value;
                var code = $(this).attr("data-id");
                postClient.server.like(code, comment);
            });
        });

    $.connection.hub.start();

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

function setTotalStars(totalDecimal) {

    var result = "";

    for (var i = 1; i <= totalDecimal; i++) {
        result += `<span class="starGlowN id="sRate${i}"></span>`;
    }

    for (var i = (totalDecimal + 1); i <= 5; i++) {
        result += `<span class="starFadeN id="sRate${i}"></span>`;
    }
    return result;
}


function likeV() {
    var postId = document.getElementById("data-id").value;
    var valueComment = document.getElementById("commentId").value;
    var likeCount = document.getElementsByClassName(".like-count").value;
    var result = `<a data-id='${postId}'class="like-button" style="color: red">+
        <input id="commentId" type="hidden" name="commentId" value='${valueComment}' />+
        <span class="glyphicon glyphicon-heart like-count">'${likeCount}'</span></a>`;
    return result;
}


