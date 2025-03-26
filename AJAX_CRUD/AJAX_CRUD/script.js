$(function () {
    // Validate hobbies selection
    function ValidateHobbies(source, args) {
        var checked = $('input[type="checkbox"]').is(':checked');
        args.IsValid = checked;
    }

    if (typeof txtDOBClientID !== "undefined") {
        var $dobInput = $("#" + txtDOBClientID);
        var today = new Date().toISOString().split('T')[0]; // Get today's date in YYYY-MM-DD format

        $dobInput.attr("max", today); // Set max attribute to today's date

        // Prevent manual entry of future dates
        $dobInput.on("change", function () {
            if ($(this).val() > today) {
                alert("Future dates are not allowed!");
                $(this).val(""); // Clear invalid input
            }
        });
    }
});

function formatJSONDate(jsonDate) {
    var timestamp = +jsonDate.slice(6, -2); // Extracts the numeric timestamp
    var date = new Date(timestamp);
    return date.toISOString().split('T')[0]; // Returns YYYY-MM-DD
}



$(function () {
    function loadUserData() {
        $.ajax({
            type: "POST",
            url: "Default.aspx/GetUserData",
            contentType: "application/json;",
            dataType: "json",
            success: function (response) {
                var users = JSON.parse(response.d);
                var rows = "";
                users.forEach(function (user, index) {
                    rows += `<tr>
                        <td>${user.Name}</td>
                        <td>${user.Mobile}</td>
                        <td>${user.Email}</td>
                        <td>${user.Gender}</td>
                        <td>${user.Hobbies}</td>
                        <td>${formatJSONDate(user.DOB)}</td>
                        <td>
                            <button class="edit-btn" data-index="${index}">Edit</button>
                            <button class="delete-btn" data-index="${index}">Delete</button>
                        </td>
                    </tr>`
                });
                $("#userTable tbody").html(rows);
            },
            error: function () {
                alert("Error loading data.");
            }
        });
    }

    // Load data on page load
    loadUserData();

    // Reload data on form submission
    $("#btnSubmit").click(function (e) {
        loadUserData();
    });

    $("#userTable").css({
        "borderCollapse": "collapse"
    });
});
