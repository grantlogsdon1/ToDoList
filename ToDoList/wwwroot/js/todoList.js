$(function () {

    $('.auto-save').on('change', function () {
        let row = $(this).closest('.row');
        saveTaskChanges(row);
    });
});

function saveTaskChanges(row) {
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
        url: '/Home/EditTask',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(taskData),
        success: function (response) {
            console.log('Auto-save successful');
        },
        error: function (xhr, status, error) {
            console.error('Auto-save failed:', error);
        }
    });

};