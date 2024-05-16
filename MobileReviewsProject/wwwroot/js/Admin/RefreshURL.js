var btn = document.querySelector(".refresh-btn");

btn.addEventListener("click", function (e) {
    $.ajax({
        type: "POST",
        url: "/Admin/RefreshUrl",

        success: function (data) {
            toastr.success(data.message);
        }
    });
});