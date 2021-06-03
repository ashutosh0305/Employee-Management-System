
 $(document).ready(function(){
    $(".demo").hide();
    $("#factorUpdate").hide();
     $("#factorUpdate").hide();
     $("#factorcancel").hide();
    $(".loyaltyLeaveUpdate").hide();
     console.log(6);


   
        
     $.post("/Home/Checkwho",
         {

         },
         function (data, status) {

             if (data) {
                
             } else {

                 $(".edithide").hide();
             }

         });
    

     $(".logout").click(function () {

         $.post("/Home/Logout",
             {

             }
           

             );
     });





     $.post("/Employee/findname",
         {

         },
         function (data, status) {

             document.getElementById("username").innerHTML = data;

         });
})


function EditSetting(i) {
    $("#Employee_" + i).prop("disabled", false);
    $("#Consultant_" + i).prop("disabled", false);

    //$("#Edit_" + i).text("Update");

    $("#Edit_" + i).hide();
    $("#Update_" + i).show();


}

function UpdateSetting(i) {


    $("#Update_" + i).hide();
    $("#Edit_" + i).show();
    $("#Employee_" + i).prop("disabled", true);
    $("#Consultant_" + i).prop("disabled", true);

    var value = $("input[name='Name_" + i + "']:checked").val();
    console.log(value);
    $.post("/setting/JobTitleUpdate",
        {
            Id: i,
            JobTitle: "",
            Type: value
        },
        function (data, status) {
            alert("Data: " + data + "\nStatus: " + status);
        });
}

function DeleteSetting(i) {
    $.post("/setting/JobTitleDelete",
        {
            Id: i,
            JobTitle: "",
            Type: ""
        },
        function (data, status) {

            if (data) {
                $("#Delete_" + i).hide();
                alert("Succesfully delete Job Title");
            } else {
                alert("Some Error Please try again later");
            }
        });
}

function JobTitleAdd() {
    var data = "<tr><td><input type='text' name='AddTitle' class=''></input></td><td>Employee: <input type='radio' name='add' value='Employee'></input> Consultant: <input type='radio' name='add' value='Consultant'></input></td><td><input class='btn btn-primary margin_0' type='button' onclick='JobTitleAddFire()' value='Add'/></td></tr>";
    tableBody = $("table tbody");
    tableBody.prepend(data);
}

function JobTitleAddFire() {
    var value = $("input[name='add']:checked").val();
    var value1 = $("input[name='AddTitle']").val();
    console.log("fire", value, value1);
    var form = document.createElement("form");
    form.method = 'post';
    form.action = '/setting/JobTitleAdd';
    var input = document.createElement('input');
    input.type = "text";
    input.name = "Type";
    input.value = value;
    form.appendChild(input);

    var input1 = document.createElement('input');
    input1.type = 'number';
    input1.name = "Id";
    input1.value = 0;
    form.appendChild(input1);

    var input2 = document.createElement('input');
    input2.type = "text";
    input2.name = "JobTitle";
    input2.value = value1;
    form.appendChild(input2);
    $(document.body).append(form);
    form.submit();
}

function JoiningLeaveFactorCancel() {
    $("#to1").prop("disabled", true);
    $("#from2").prop("disabled", true);
    $("#to2").prop("disabled", true);
    $("#from3").prop("disabled", true);
    $("#to3").prop("disabled", true);
    $("#from4").prop("disabled", true);
    $("#factorUpdate").hide();
    $("#factorEdit").show();
    $("#factorcancel").hide();
}


function JoiningLeaveFactorEdit() {
    $("#to1").prop("disabled", false);
    $("#from2").prop("disabled", false);
    $("#to2").prop("disabled", false);
    $("#from3").prop("disabled", false);
    $("#to3").prop("disabled", false);
    $("#from4").prop("disabled", false);
    $("#factorUpdate").show();
    $("#factorEdit").hide();
    $("#factorcancel").show();
}



function JoiningLeaveFactorUpdate() {
  //  var to1 = $("#to1").val();
    var to1 = $("input[name='TO1']").val();
    var to2 = $("#to2").val();
    var to3 = $("#to3").val();

    var from2 = $("#from2").val();
    var from3 = $("#from3").val();
    var from4 = $("#from4").val();

    if (from2 - to1 == 1) {
        if (from3 - to2 == 1) {
            if (from4 - to3 == 1) {
                console.log("Done")
                $.post("/setting/JoiningLeaveFactorUpdate",
                    {
                        From1: 1,
                        To1: to1,
                        Factor1: null,
                        From2: from2,
                        To2: to2,
                        Factor2: null,
                        From3: from3,
                        To3: to3,
                        Factor3: null,
                        From4: from4,
                        To4: 31,
                        Factor4: null,
                    },
                    function (data, status) {

                        if (data) {
                            $("#factorUpdate").hide();
                            $("#factorEdit").show();
                            $("#to1").prop("disabled", true);
                            $("#from2").prop("disabled", true);
                            $("#to2").prop("disabled", true);
                            $("#from3").prop("disabled", true);
                            $("#to3").prop("disabled", true);
                            $("#from4").prop("disabled", true);
                            alert("Succesfully Updated");
                        } else {
                            $("#factorUpdate").hide();
                            $("#factorEdit").show();
                            alert("Some Error Please try again later");
                        }
                    });
            } else {
                alert("Value in ‘To Day’ and ‘From Day’ must not have gap.")
            }
        } else {
            alert("Value in ‘To Day’ and ‘From Day’ must not have gap.")
        }
    } else {
        alert("Value in ‘To Day’ and ‘From Day’ must not have gap.")
    }
}


function loyaltyLeaveFactorEdit(i) {
    $("#loyaltyLeaveEdit_" + i).hide();
    $("#loyaltyLeaveUpdate_" + i).show();
    $("#_" + i).prop("disabled", false);
    //var data = $(i).val();
    /////// console.log(data);
}

function loyaltyLeaveFactorUpdate(i) {
    $("#loyaltyLeaveEdit_" + i).show();
    $("#loyaltyLeaveUpdate_" + i).hide();
    $("#_" + i).prop("disabled", true);
    var data = $("#_" + i).val();

    $.post("/setting/loyaltyLeaveFactorUpdate",
        {
            id: i,
            value: data
        },
        function (data, status) {

            if (data) {

                alert("Succesfully  Updated");
            } else {
                alert("Some Error Please try again later");
            }
        });

}



function monthlyLeaveFactorEdit(i) {
    $("#monthlyLeaveEdit_" + i).hide();
    $("#monthlyLeaveUpdate_" + i).show();
    $("#_" + i).prop("disabled", false);
}

function monthlyLeaveFactorUpdate(i) {
    $("#monthlyLeaveEdit_" + i).show();
    $("#monthlyLeaveUpdate_" + i).hide();
    $("#_" + i).prop("disabled", true);
    var data = $("#_" + i).val();
    console.log(data)
    $.post("/setting/MonthlyLeaveUpdate",
        {
            id: i,
            value: data
        },
        function (data, status) {

            if (data) {

                alert("Succesfully  Updated");
            } else {
                alert("Some Error Please try again later");
            }
        });
}



function plannedLeaveFactorUpdate(i) {
    $("#plannedLeaveEdit_" + i).show();
    $("#plannedLeaveUpdate_" + i).hide();
    $("#_" + i).prop("disabled", true);
    var data = $("#_" + i).val();
    console.log(data)

    $.post("/setting/PlannedLeaveUpdate",
        {
            id: i,
            value: data
        },
        function (data, status) {

            if (data) {

                alert("Succesfully  Updated");
            } else {
                alert("Some Error Please try again later");
            }
        });
}

function plannedLeaveFactorEdit(i) {
    $("#plannedLeaveEdit_" + i).hide();
    $("#plannedLeaveUpdate_" + i).show();
    $("#_" + i).prop("disabled", false);
    console.log(i);
}



function unplannedLeaveFactorUpdate(i) {
    $("#unplannedLeaveEdit_" + i).show();
    $("#unplannedLeaveUpdate_" + i).hide();
    $("#_" + i).prop("disabled", true);
    var data = $("#_" + i).val();
    console.log(data)

    $.post("/setting/UnplannedLeaveUpdate",
        {
            id: i,
            value: data
        },
        function (data, status) {

            if (data) {

                alert("Succesfully  Updated");
            } else {
                alert("Some Error Please try again later");
            }
        });
}

function unplannedLeaveFactorEdit(i) {
    $("#unplannedLeaveEdit_" + i).hide();
    $("#unplannedLeaveUpdate_" + i).show();
    $("#_" + i).prop("disabled", false);
    console.log(i);
}


//function EditHoliday(i) {
//    $("#Consulting_" + i).prop("disabled", false);
//    $("#KPO_" + i).prop("disabled", false);
//    $("#Both_" + i).prop("disabled", false);
//    $("#name_" + i).prop("disabled", false);
//    $("#date_" + i).prop("disabled", false);

//    //$("#Edit_" + i).text("Update");

//    $("#Edit_" + i).hide();
//    $("#Update_" + i).show();
//}

function EditHoliday(i) {
    $("#Consulting_" + i).prop("disabled", false);
    $("#KPOB_" + i).prop("disabled", false);
    $("#Both_" + i).prop("disabled", false);
    $("#name_" + i).prop("disabled", false);
    $("#date_" + i).prop("disabled", false);
    $("#Edit_" + i).hide();
    $("#Update_" + i).show();


}

//function UpdateHoliday(i) {
//    $("#Update_" + i).hide();
//    $("#Edit_" + i).show();
//    $("#Consulting_" + i).prop("disabled", true);
//    $("#KPO_" + i).prop("disabled", true);
//    $("#Both_" + i).prop("disabled", true);
//    $("#name_" + i).prop("disabled", true);
//    $("#date_" + i).prop("disabled", true);

//    var value = $("input[name='radio_" + i + "']:checked").val();
//    var name = $("#name_" + i).val();
//    var date = $("#date_" + i).val();
//    console.log(value, date);
//    $.post("/setting/PublicHolidayUpdate",
//        {
//            Id: i,
//            Name: name,
//            Department: value,
//            Dates: date
//        },
//        function (data, status) {
//            alert("Data Updated");
//        });
//}


function UpdateHoliday(i) {
    $("#Update_" + i).hide();
    $("#Edit_" + i).show();
    $("#Consulting_" + i).prop("disabled", true);
    $("#KPOB_" + i).prop("disabled", true);
    $("#Both_" + i).prop("disabled", true);
    $("#name_" + i).prop("disabled", true);
    $("#date_" + i).prop("disabled", true);

    var value = $("input[name='radio_" + i + "']:checked").val();
    var name = $("#name_" + i).val();
    var date = $("#date_" + i).val();
    $.post("/setting/PublicHolidayUpdate",
    {
        Id: i,
        HolidayName:name,
        Department: value,
        Dates: date
    },
        function (data, status) {
            alert("Data Updated");
        });


}
function DeleteHoliday(i) {
    $.post("/setting/PublicHolidayDelete",
        {
            Id: i
        },
        function (data, status) {

            if (data) {
                $("#Delete_" + i).hide();
                alert("Succesfully delete Job Title");
            } else {
                alert("Some Error Please try again later");
            }
        });

}
function PublicHolidayAdd() {
    var data = "<tr><td><input type='date' name='AddHolidayDate' class=''></input></td><td><input type='text' name='AddHolidayName' class=''></input ></td><td> Consulting: <input type='radio' id='Consulting_New' name='radios' value = 'Consulting'  > KPO B: <input type='radio' id='KPO_New' name='radios' value = 'KPO B'  >BOTH: <input type='radio' id='Both_New' name='radios' value = 'both'  ></td><td><input class='btn btn-primary margin_0' type='button' onclick='PublicHolidayAddFire()' value='Add'/></td></tr > ";
    tableBody = $("table tbody");
    console.log(5);
    tableBody.prepend(data);
}

function PublicHolidayAddFire() {
    var radios = $("input[name='radios']:checked").val();
    var date = $("input[name='AddHolidayDate']").val();
    var name = $("input[name='AddHolidayName']").val();
    console.log("fire", radios, date, name);
    var form = document.createElement("form");
    form.method = 'post';
    form.action = '/setting/PublicHolidayAdd';
    var input = document.createElement('input');
    input.type = "text";
    input.name = "Department";
    input.value = radios;
    form.appendChild(input);

    var input1 = document.createElement('input');
    input1.type = 'date';
    input1.name = "Dates";
    input1.value = date;
    form.appendChild(input1);

    var input1 = document.createElement('input');
    input1.type = 'text';
    input1.name = "HolidayName";
    input1.value = name;
    form.appendChild(input1);

    var input2 = document.createElement('input');
    input2.type = "number";
    input2.name = "Id";
    input2.value = 0;
    form.appendChild(input2);
    $(document.body).append(form);
    form.submit();
}



