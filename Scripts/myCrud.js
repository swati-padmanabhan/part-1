function loadContacts(userId) {
    $.ajax({
        url: "/Contact/GetAllContacts",
        type: "GET",
        data: { userId: userId },  
        success: function (data) {
            $("#tblBody").empty();

            $.each(data, function (index, contact) {
                var row = `<tr>
                    <td>${contact.FirstName}</td>
                    <td>${contact.LastName}</td>
                    <td>${contact.IsActive}</td>
                    <td>
                        <button onclick="editContact('${contact.Id}')" value="Edit" class="btn btn-success">Edit</button>
                    </td>
                </tr>`;
                $("#tblBody").append(row);
            });
        },
        error: function (err) {
            $("#tblBody").empty();
            alert("Error: No Data Available");
        }
    });
}


