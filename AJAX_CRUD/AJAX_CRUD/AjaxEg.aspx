<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxEg.aspx.cs" Inherits="AJAX_CRUD.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="text" id="fname" placeholder="Enter your firstname"/>
            <br /><br />
            <input type="text" id="sname" placeholder="Enter your surname"/>
            <br /><br />
            <input type="button" value="submit" id="btn"/>
            <br /><br />
            <h2 id="result"></h2>
        </div>
    </form>
    <script>
        $(function () {
            $('#btn').click(function () {
                var fname = $('#fname').val();
                var sname = $('#sname').val();
                if (fname == "" || sname == "") {
                    alert("All fields are required..");
                }
                else {
                    $.ajax({
                        url: 'Default.aspx/GetData',
                        type: 'post',
                        contentType: 'application/json',
                        data: JSON.stringify({ fname, sname }),
                        dataType: 'json',
                        beforeSend: function(xhr){
                            $('#result').text('processing...');
                        },
                        success: function (result, status, xhr) {
                            $('#result').text(result.d);
                            //alert(status);
                            //alert(xhr);
                        },
                        error: function (xhr, status, result) {
                            alert(xhr);
                            alert(status);
                            $('#result').text(result.d);
                        },
                        complete: function (xhr, status) {
                            alert(status);
                        }
                    });
                }
            });
        });
    </script>
</body>
</html>
