var depart = {} || depart;

depart.drawTable = function () {
    $.ajax({
        url: "/Department/Gets",
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbDepart tbody').empty();
            $.each(data.departments, function (i, v) {
                //var emps = v.employees > 0 ?
                //    `<a href="/Employee/List/${v.departmentId}" title="Employee list">${v.employees}</a>` :
                //    `${v.employees}`;
                $('#tbDepart tbody').append(
                    `<tr>
                        <td>${v.departmentId}</td>
                        <td>${v.departmentName}</td>
                        <td><a href="/Employee/List/${v.departmentId}" title="Employee list">${v.employees}</a></td>
                        <td>
                            <a href="javascripts:;"
                                       onclick="depart.get(${v.departmentId})" class="item"><i class="zmdi zmdi-edit"></i></a> 
                            <a href="javascripts:;" class="item"
                                        onclick="depart.delete(${v.departmentId})"><i class="zmdi zmdi-delete"></i></a>
                        </td>
                    </tr>`
                );
            });
        }
    });

}; 

depart.openAddEditdepartment = function () {
    depart.reset();
    $('#addEditdepartment').appendTo("body").modal('show');
};


depart.delete = function (id) {
    bootbox.confirm({
        title: "Delete department?",
        message: "Do you want to delete this department.",
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
                    url: `/Department/Delete/${id}`,
                    method: "GET",
                    dataType: "json",
                    success: function (data) {
                        bootbox.alert(data.result.message);
                        depart.drawTable();
                    }
                });
            }
        }
    });
}


depart.get = function (id) {
    $.ajax({
        url: `/Department/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#DepartmentName').val(data.result.departmentName);
            $('#DepartmentId').val(data.result.departmentId);
            $('#addEditdepartment').appendTo("body").modal('show');
        }
    });
}

depart.reset = function () {
    $('#DepartmentName').val("");
    $('#DepartmentId').val(0);
}

depart.save = function () {
    var saveObj = {};
    saveObj.DepartmentName = $('#DepartmentName').val();
    saveObj.DepartmentId = parseInt($('#DepartmentId').val());
    $.ajax({
        url: `/Department/Save/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditdepartment').modal('hide');
            bootbox.alert(data.result.message);
            depart.drawTable();
        }
    });
}

depart.init = function () {
    depart.drawTable();
};

$(document).ready(function () {
    depart.init();
});