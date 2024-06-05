$(function () {
    console.log('hit');
    getAllTodoLists();

});

function getAllTodoLists() {
    $.ajax({
        url: '/Panel/Index',
        type: 'GET'
    }).done(content => {
        $('.panel-items').html(content);
    });
};