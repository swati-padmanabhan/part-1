function loadContacts() {
    $.ajax({
        url: "/Contact/GetAllContacts",
        type: "GET",
        //data: { userId: userId },
        success: function (data) {
            $("#tblBody").empty();

            $.each(data, function (index, contact) {
                var isActiveCheckbox = `<input type="checkbox" class="is-active-checkbox" data-contact-id="${contact.Id}" ${contact.IsActive ? "checked" : ""} />`;

                var row = `<tr>
                    <td>${contact.FirstName}</td>
                    <td>${contact.LastName}</td>
                    <td>${isActiveCheckbox}</td>
                    <td>
                    <button onclick="editContact('${contact.Id}')" value="Edit" class="btn btn-success">Edit</button>
                    </td>
                    <td>
                    <button onclick="contactDetails('${contact.Id}') value="ContactDetails" class="btn btn-danger">Contact Details</button>
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





function addNewRecord(newItem) {
    $.ajax({
        url: "/Contact/AddContact",
        type: "POST",
        data: newItem,

        success: function (contact) {
            alert("New Contact Added Successfully")
            loadContacts()
        },
        error: function (err) {
            alert("Error Adding New Record")
        }
    })
}

function getContact(contactId) {
    $.ajax({
        url: "/Contact/GetContact",
        type: "GET",
        data: { contactId: contactId },
        success: function (contact) {
            $("#editContactId").val(contact.Id); 
            $("#newFirstName").val(contact.FirstName);
            $("#newLastName").val(contact.LastName);
        },
        error: function (err) {
            alert("No such data found");
        }
    });
}


function modifyRecord(modifiedContact) {
    $.ajax({
        url: "/Contact/EditContact",
        type: "POST",
        data: modifiedContact,

        success: function (contact) {
            alert("Contact Edited Successfully");
            loadContacts();
        },
        error: function (err) {
            alert("Error Editing Record");
        }
    });
}

$(document).on('change', '.is-active-checkbox', function () {
    var isActive = $(this).is(':checked');
    var contactId = $(this).data('contact-id');

    $.ajax({
        url: '/Contact/UpdateIsActiveStatus',
        type: 'POST',
        data: { contactId: contactId, isActive: isActive },
        success: function (response) {
            alert('Status updated successfully');
        },
        error: function (xhr, status, error) {
            alert('An error occurred: ' + error);
        }
    });
});

$("#btnAdd").click(() => {
    $("#itemList").hide();
    $("#newContact").show();
})
function editContact(contactId) {
    getContact(contactId);
    $("#itemList").hide();
    $("#editContact").show();
}