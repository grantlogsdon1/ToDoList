$(function () {

    $('.auto-save').on('change', function () {
        let row = $(this).closest('.row');
        saveTask(row);
    });

    $('#listName').on('change', function () {
        let id = $('#selected-list-id').val();
        let name = $(this).val();
        updateListName(id, name);
    })

    $('#add-task').on('click', function () {
        $('#add-task').addClass('disabled');
    });
});

function updateListName(listId, name) {
    $.ajax({
        url: '/Home/UpdateTodoListHeader',
        type: 'POST',
        data: {
            listId: listId,
            name: name
        },
        success: function (response) {
            console.log('Auto-save for list successful');
            console.log($('#listName').val());
            $(`#panel-card-${listId}`).text($('#listName').val());
        },
        error: function (xhr, status, error) {
            console.error('Auto-save for list failed:', error);
        }
    });
}

function saveTask(row) {
    var taskId = row.data('task-id');
    var listId = $('#selected-list-id').val();
    var isComplete = $(`#IsComplete-${taskId}`).is(":checked");
    var detail = $(`#Detail-${taskId}`).val();

    let taskData = {
        TaskId: taskId,
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