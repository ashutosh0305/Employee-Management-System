$(document).ready(function () {
    $("#time").hide();
    $("#table2").hide();
    $.post("/Home/Checkwho",
        {
            
        },
        function (data, status) {

            if (data) {
               
                } else {

                $(".edithide").hide();
            }
        });
    $(".click3").click(function () {
        $(".Leaves3").toggle();
    });
    $(".logout").click(function () {

        $.post("/Home/Logout",
            {

            }
           

            );
    });
})
$("#LeaveType").change(() => {
    var data = $("#LeaveType").val();
    if (data == "Half Day") {
        $("#ToDate").prop("disabled", true);
        $("#ToTime").prop("disabled", true);
        $("#time").show();
    }
    if (data != "Half Day") {
        $("#ToDate").prop("disabled", false);
        $("#ToTime").prop("disabled", true);
        $("#time").hide();
    }
})

function checkApply() {
    var data = $("#FromDate").val()
    var data2 = $("#ToDate").val()
    var date = new Date(data);
    var date2 = new Date(data2);
    if (date > date2) {
        alert("Choose Date properly")
        console.log(date, date2)
        return false
    } else {
        var count = 0;
        console.log(date, date2)
        $.ajaxSetup({ async: false });
        $.post("/Leave/CheckPlannned",
            {
                FromDate: data,
                ToDate: data2,
                FromTime: $("#FromTime").val(),
                ToTime: $("#ToTime").val(),
                Status: $("#LeaveType").val()
            },
            function (data, status) {

                if (data) {
                    if (confirm('Are you sure to mark Leave as ' + data)) {
                        count = 1;
                        $("#Type").val(data);
                    } else {

                    }
                } else {
                    alert("Some Error Please try again later");
                }
            });
        $.ajaxSetup({ async: true });
        if (count == 1) {
            //var data = $("#LeaveType").val();
            //if (data == "Half Day") {
            //    $("#ToDate").val($("#FromDate").val());
            //}
            return true
        } else {
            return false
        }
    }
}
function checkApply2() {
    var data = $("#FromDate").val()
    var data2 = $("#ToDate").val()
    var date = new Date(data);
    var date2 = new Date(data2);
    if (date > date2) {
        alert("Choose Date properly")
        console.log(date, date2)
        return false
    } else {
        $("#LeaveType").prop("disabled", false);
        return true
    }
}

$('select').change(function () {
    if ($(this).children('option:selected').val() == "Consulting") {
        $("#table1").show();
        $("#table2").hide()

    } else {
        $("#table1").hide();
        $("#table2").show()
    }
});

$('#DebitCredit').change(function () {
    if ($(this).children('option:selected').val() == "Debit") {
        $("#table1").show();
        $("#table2").hide()
        console.log("one")

    } else {
        $("#table1").hide();
        $("#table2").show()
        console.log("two")
    }
});