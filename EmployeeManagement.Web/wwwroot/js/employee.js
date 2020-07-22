var employee = {} || employee;
var departId = 0;

employee.drawTable = function () {
    
    $.ajax({
        url: `/Employee/Gets/${departId}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbEmployee tbody').empty();
            $.each(data.employees, function (i, v) {
                $('#tbEmployee tbody').append(
                    `
                    <tr>
                        <td>${v.employeeId}</td>
                        <td>${v.employeeName}</td>
                        <td>${v.doB}</td>
                        <td>${v.gender}</td>
                        <td>${v.avatarPath}</td>
                        <td>${v.createdDate}</td>
                        <td>
                            <a href="#" class="btn btn-success">Edit</a> 
                            <a href="#" class="btn btn-danger">Remove</a>
                        </td>
                    </tr>
                    `
                );
            });
        }
    });

};

//employee.openAddEditdepartment = function () {
//    employee.reset();
//    $('#addEditdepartment').modal('show');
//};


//employee.delete = function (id) {
//    bootbox.confirm({
//        title: "Delete department?",
//        message: "Do you want to delete this department.",
//        buttons: {
//            cancel: {
//                label: '<i class="fa fa-times"></i> No'
//            },
//            confirm: {
//                label: '<i class="fa fa-check"></i> Yes'
//            }
//        },
//        callback: function (result) {
//            if (result) {
//                $.ajax({
//                    url: `/Home/Delete/${id}`,
//                    method: "GET",
//                    dataType: "json",
//                    success: function (data) {
//                        bootbox.alert(data.result.message);
//                        employee.drawTable();
//                    }
//                });
//            }
//        }
//    });
//}


//employee.get = function (id) {
//    $.ajax({
//        url: `/Home/Get/${id}`,
//        method: "GET",
//        dataType: "json",
//        success: function (data) {
//            $('#DepartmentName').val(data.result.departmentName);
//            $('#DepartmentId').val(data.result.departmentId);
//            $('#addEditdepartment').modal('show');
//        }
//    });
//}

//employee.reset = function () {
//    $('#DepartmentName').val("");
//    $('#DepartmentId').val(0);
//}

//employee.save = function () {
//    var saveObj = {};
//    saveObj.DepartmentName = $('#DepartmentName').val();
//    saveObj.DepartmentId = parseInt($('#DepartmentId').val());
//    $.ajax({
//        url: `/Home/Save/`,
//        method: "POST",
//        dataType: "json",
//        contentType: "application/json",
//        data: JSON.stringify(saveObj),
//        success: function (data) {
//            $('#addEditdepartment').modal('hide');
//            bootbox.alert(data.result.message);
//            employee.drawTable();
//        }
//    });
//}

employee.init = function () {
    employee.drawTable();
};

$(document).ready(function () {
    departId = $('#DepartmentId').val();
    employee.init();
});