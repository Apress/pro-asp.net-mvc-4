function selectView(view) {
    $('.display').not('#' + view + "Display").hide();
    $('#' + view + "Display").show();
}

function getData() {
    $.ajax({
        type: "GET",
        url: "/api/reservation",
        success: function (data) {
            $('#tableBody').empty();
            for (var i = 0; i < data.length; i++) {
                $('#tableBody').append('<tr><td><input id="id" name="id" type="radio"'
                    + 'value="' + data[i].ReservationId + '" /></td>'
                    + '<td>' + data[i].ClientName + '</td>'
                    + '<td>' + data[i].Location + '</td></tr>');
            }
            $('input:radio')[0].checked = "checked";
            selectView("summary");
        }
    });
}

$(document).ready(function () {
    selectView("summary");
    getData();
    $("button").click(function (e) {
        var selectedRadio = $('input:radio:checked')
        switch (e.target.id) {
            case "refresh":
                getData();
                break;
            case "delete":
                $.ajax({
                    type: "DELETE",
                    url: "/api/reservation/" + selectedRadio.attr('value'),
                    success: function (data) {
                        selectedRadio.closest('tr').remove();
                    }
                });
                break;
            case "add":
                selectView("add");
                break;
            case "edit":
                $.ajax({
                    type: "GET",
                    url: "/api/reservation/" + selectedRadio.attr('value'),
                    success: function (data) {
                        $('#editReservationId').val(data.ReservationId);
                        $('#editClientName').val(data.ClientName);
                        $('#editLocation').val(data.Location);
                        selectView("edit");
                    }
                });
                break;
            case "submitEdit":
                $.ajax({
                    type: "PUT",
                    url: "/api/reservation/" + selectedRadio.attr('value'),
                    data: $('#editForm').serialize(),
                    success: function (result) {
                        if (result) {
                            var cells = selectedRadio.closest('tr').children();
                            cells[1].innerText = $('#editClientName').val();
                            cells[2].innerText = $('#editLocation').val();
                            selectView("summary");
                        }
                    }
                });
                break;
        }
    });
});