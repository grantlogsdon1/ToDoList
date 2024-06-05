$(function () {
    populatePanel();
});

function populatePanel() {
    $.ajax({
        url: '/Panel/Index',
        type: 'GET'
    }).done(content => {
        $('.panel-items').html(content);
        let selectedListId = $('#selected-list-id').val();
        let matchingDiv = $('.todo-list-card[data-list-id="' + selectedListId + '"]');
        matchingDiv.removeClass('btn-outline-secondary')
        matchingDiv.addClass('btn-primary');

    });
};