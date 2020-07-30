var site = site || { };
site.linkUrl = function (url) {
    window.location.href = url;
}

site.initMenu = function () {
    $('.list-unstyled').append(`<li class="active">
                            <a class="js-arrow" href="/Home/Index">
                                <i class="fas fa-tachometer-alt"></i>Department
                            </a>
                        </li>`)
                    .append(`<li>
                            <a class="js-arrow" href="/Category/Index">
                                <i class="fas fa-tachometer-alt"></i>Category
                            </a>
                        </li>`);
}
$(document).ready(function () {
    //site.initMenu();
    $('.list-unstyled li a').click(function (e) {

        $('.list-unstyled li.active').removeClass('active');

        var $parent = $(this).parent();
        $parent.addClass('active');
        e.preventDefault();
    });
});