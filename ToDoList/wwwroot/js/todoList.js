$(function () {

    $('.auto-save').on('change', function () {
        let row = $(this).closest('.row');
        saveTask(row);
    });

    $('#listName').on('change', function () {
        let id = $('#listId').val();
        let name = $(this).val();
        updateListName(id, name);
    })
});

function updateListName(id, name) {
    $.ajax({
        url: '/Home/UpdateTodoListHeader',
        type: 'POST',
        data: {
            listId: id,
            name: name
        },
        success: function (response) {
            console.log('Auto-save for list successful');
        },
        error: function (xhr, status, error) {
            console.error('Auto-save for list failed:', error);
        }
    });
}

function saveTask(row) {
    var listItemId = row.data('task-id');
    var listId = row.data('list-id');
    var isComplete = $(`#IsComplete-${listItemId}`).is(":checked");
    var detail = $(`#Detail-${listItemId}`).val();

    let taskData = {
        ListItemId: listItemId,
        ListId: listId,
        IsComplete: isComplete,
        Detail: detail
    };

    $.ajax({
        url: '/Home/UpdateTask',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(taskData),
        success: function (response) {
            console.log('Auto-save for task successful');
        },
        error: function (xhr, status, error) {
            console.error('Auto-save for task failed:', error);
        }
    });

};