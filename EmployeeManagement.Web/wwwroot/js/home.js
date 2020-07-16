var home = {} || home;

home.drawTable = function () {
    $.ajax({
        url: "/Home/Gets",
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbDepart tbody').empty();
            $.each(data.departments, function (i, v) {
                $('#tbDepart tbody').append(
                    `<tr>
                        <td>${v.departmentId}</td>
                        <td>${v.departmentName}</td>
                        <td>
                            <a href="javascripts:;" class="btn btn-success">Edit</a> 
                            <a href="javascripts:;" class="btn btn-danger">Remove</a>
                        </td>
                    </tr>`
                );
            });
        }
    });

};

home.openAddEditdepartment = function () {
    //department.reset();
    $('#addEditdepartment').modal('show');
};


home.init = function () {
    home.drawTable();
};

$(document).ready(function () {
    home.init();
});