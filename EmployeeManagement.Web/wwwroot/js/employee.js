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
                        <td><img src='${v.avatarPath}' width='80' height='90'/></td>
                        <td>${v.createdDate}</td>
                        <td>
                            <a href="javascript:;" onclick="employee.get(${v.employeeId})" class="item"><i class="zmdi zmdi-edit"></i></a> 
                            <a href="javascript:;" onclick="employee.delete(${v.employeeId})" class="item"><i class="zmdi zmdi-delete"></i></a>
                        </td>
                    </tr>
                    `
                );
            });
        }
    });

};

employee.openAddEditEmployee = function () {
    employee.reset();
    $('#addEditEmployee').appendTo("body").modal('show');
};


employee.delete = function (id) {
    bootbox.confirm({
        title: "Delete department?",
        message: "Do you want to delete this employee.",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Yes'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Employee/Delete/${id}`,
                    method: "GET",
                    dataType: "json",
                    success: function (data) {
                        bootbox.alert(data.result.message);
                        employee.drawTable();
                    }
                });
            }
        }
    });
}

employee.uploadAvatar = function (input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#Avatar').attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

employee.get = function (id) {
    $.ajax({
        url: `/Employee/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#EmployeeName').val(data.employee.employeeName);
            $('#EmployeeId').val(data.employee.employeeId);
            $('#DoB').val(data.employee.doB);
            $('#Gender').val(data.employee.gender);
            $('#Department').val(data.employee.departmentId);
            $('#Avatar').attr("src",data.employee.avatarPath);

            $('#addEditEmployee').find('.modal-title').text('Edit Employee');
            $('#addEditEmployee').appendTo("body").modal('show');
        }
    });
}

employee.reset = function () {
    $('#EmployeeName').val("");
    $('#EmployeeId').val("0");
    $('#DoB').val();
    $('#Gender').val(1);
    $('#Department').val(departId);
    $('#Avatar').attr('src','/images/noavatar.png')
    $('#addEditEmployee').find('.modal-title').text('Add New Employee');
}

employee.save = function () {
    var saveObj = {};
    saveObj.EmployeeName = $('#EmployeeName').val();
    saveObj.EmployeeId = parseInt($('#EmployeeId').val());
    saveObj.DoB = $('#DoB').val();
    saveObj.Gender = parseInt($('#Gender').val());
    saveObj.AvatarPath = $('#Avatar').attr('src');
    saveObj.DepartmentId = parseInt($('#Department').val());
    $.ajax({
        url: `/Employee/Save/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditEmployee').modal('hide');
            bootbox.alert(data.result.message);
            employee.drawTable();
        }
    });
}

employee.initGender = function () {
    $("#Gender").append(`<option value=1>Male</option>`)
                .append(`<option value=0>Female</option>`);
}

employee.initDepartment = function () {
    $.ajax({
        url: `/Department/Gets`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#Department').empty();
            $.each(data.departments, function (i, v) {
                $("#Department").append(`<option value=${v.departmentId}>${v.departmentName}</option>`)
            });
        }
    });
}

employee.init = function () {
    employee.drawTable();
    employee.initGender();
    employee.initDepartment();
};

$(document).ready(function () {
    departId = $('#DepartmentId').val();
    employee.init();
});