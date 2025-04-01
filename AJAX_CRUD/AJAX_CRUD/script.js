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
    try {
       
        if (!jsonDate) return "";
        if (jsonDate.includes("/Date(")) {
            var date = new Date(parseInt(jsonDate.substr(6)));
            return date.toISOString().split('T')[0];
        }
        return jsonDate.split('T')[0]; 
    } catch (e) {
        console.error("Date formatting error:", e);
        return "";
    }
}

$(function () {
    function loadUserData() {
        debugger;
        $.ajax({
            type: "POST",
            url: "Default.aspx/GetUserData",
            contentType: "application/json;",
            dataType: "json",
            success: function (response) {
                var users = JSON.parse(response.d);
                var rows = "";
                users.forEach(function (user) {
                    rows += `<tr>
                        <td>${user.Name}</td>
                        <td>${user.Mobile}</td>
                        <td>${user.Email}</td>
                        <td>${user.Gender}</td>
                        <td>${user.Hobbies}</td>
                        <td>${formatJSONDate(user.DOB)}</td>
                        <td>
                            <input type="button" class="edit-btn" value="Edit" data-id="${user.Id}">
                           <button type="button" class="delete-btn" data-id="${user.Id}">Delete</button>

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
    
    

    // Edit button click event
    $(document).on("click", ".edit-btn", function (e) {
        e.preventDefault();
        var userId = $(this).data("id");

        $.ajax({
            type: "POST",
            url: "Default.aspx/GetUserById",
            data: JSON.stringify({ id: userId }),
            contentType: "application/json;",
            dataType: "json",
            success: function (response) {
                var user = JSON.parse(response.d);
  
                $("#txtName").val(user.Name);
                $("#txtMobile").val(user.Mobile);
                $("#txtEmail").val(user.Email);
                $("#DropDownGender").val(user.Gender);
                $("#txtDOB").val(formatJSONDate(user.DOB));

     
                var hobbies = user.Hobbies.split(", ");
                $("#chkCricket").prop("checked", hobbies.includes("Cricket"));
                $("#chkFootball").prop("checked", hobbies.includes("Football"));
                $("#chkReading").prop("checked", hobbies.includes("Reading"));
                $("#chkMovies").prop("checked", hobbies.includes("Movies"));

     
                $("#hiddenUserId").val(user.Id);
            },
            error: function () {
                alert("Error fetching data.");
            }
        });
    });

    // Delete button click event
    $(document).on("click", ".delete-btn", function () {
        
        var userId = $(this).data("id");

        if (confirm("Are you sure you want to delete this user?")) {
            $.ajax({
                type: "POST",
                url: "Default.aspx/DeleteUser",
                data: JSON.stringify({ id: userId }),
                contentType: "application/json;",
                dataType: "json",
                success: function (response) {
                        loadUserData();
                        alert("User deleted successfully!");  
                },
                error: function () {
                    alert("Error deleting user....");
                }
            });
        }

        
    });

    // Reload data on form submission
    //$("#btnSubmit").click(function () {
    //    //loadUserDat
    //    location.reload();
    //});

    $("#userTable").css({
        "borderCollapse": "collapse"
    });
});
