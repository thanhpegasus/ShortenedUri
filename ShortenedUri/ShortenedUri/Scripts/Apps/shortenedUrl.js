$(function () {
    $('#generateUrl').click(function () {
        var form = $('#generateShortenedUrl');
        if (form.valid()) {
            $.ajax({
                url: form.attr('action'),
                data: $('#generateShortenedUrl').serialize(),
                error: function (xhr, status, error) {
                    toastr.error(error);
                },
                dataType: 'json',
                success: function (data) {
                    toastr.info('Generate success');
                    var rowContent =
                        '<tr>' +
                        '<th scope="row">' + data.ID + '</th>' +
                        '<td><a href=' + data.ShortUrl + '>' + data.ShortUrl + '</a>' + '</td>' +
                        '<td><a href=' + data.LongUrl + '>' + data.LongUrl + '</a>' + '</td>' +
                        '</tr>';
                    $('#shortenedUrlList tbody').append(rowContent);
                },
                type: form.attr('method')
            });
        }
    });
});
