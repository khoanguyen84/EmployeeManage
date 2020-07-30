var product = {} || product;
var catId = 0;

product.drawTable = function () {
    
    $.ajax({
        url: `/Product/Gets/${catId}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbProduct tbody').empty();
            $.each(data.products, function (i, v) {
                $('#tbProduct tbody').append(
                    `
                    <tr>
                        <td>${v.productId}</td>
                        <td>${v.productName}</td>
                        <td>${v.price}</td>
                        <td><img src='${v.image}' width='80' height='90'/></td>
                        <td>
                            <a href="javascript:;" onclick="product.get(${v.productId})" class="item"><i class="zmdi zmdi-edit"></i></a> 
                            <a href="javascript:;" onclick="product.delete(${v.productId})" class="item"><i class="zmdi zmdi-delete"></i></a>
                        </td>
                    </tr>
                    `
                );
            });
        }
    });

};

product.openAddEditProduct = function () {
    product.reset();
    $('#addEditProduct').appendTo("body").modal('show');
};


product.delete = function (id) {
    bootbox.confirm({
        title: "Delete department?",
        message: "Do you want to delete this product.",
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
                    url: `/Product/Delete/${id}`,
                    method: "GET",
                    dataType: "json",
                    success: function (data) {
                        bootbox.alert(data.result.message);
                        product.drawTable();
                    }
                });
            }
        }
    });
}

product.uploadImage = function (input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#Image').attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

product.get = function (id) {
    $.ajax({
        url: `/Product/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#ProductName').val(data.product.productName);
            $('#ProductId').val(data.product.productId);
            $('#Price').val(data.product.price);
            $('#Category').val(data.product.categoryId);
            $('#Image').attr("src",data.product.image);

            $('#addEditProduct').find('.modal-title').text('Edit Product');
            $('#addEditProduct').appendTo("body").modal('show');
        }
    });
}

product.reset = function () {
    $('#ProductName').val("");
    $('#ProductId').val("0");
    $('#Price').val(0);
    $('#Category').val(catId);
    $('#Image').attr('src', '/images/noimage.jpg');
    $('#FileUpload').val('');
    $('#addEditProduct').find('.modal-title').text('Add New Product');
}

product.save = function () {
    var saveObj = {};
    saveObj.ProductName = $('#ProductName').val();
    saveObj.ProductId = parseInt($('#ProductId').val());
    saveObj.Price = parseFloat($('#Price').val());
    saveObj.Image = $('#Image').attr('src');
    saveObj.CategoryId = parseInt($('#Category').val());
    $.ajax({
        url: `/Product/Save/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditProduct').modal('hide');
            bootbox.alert(data.result.message);
            product.drawTable();
        }
    });
}

product.initCategory = function () {
    $.ajax({
        url: `/Category/Gets`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#Category').empty();
            $.each(data.categories, function (i, v) {
                $("#Category").append(`<option value=${v.categoryId}>${v.categoryName}</option>`)
            });
        }
    });
}

product.init = function () {
    product.drawTable();
    product.initCategory();
};

$(document).ready(function () {
    catId = $('#CategoryId').val();
    product.init();
});