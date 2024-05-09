var userComment = document.querySelector(".user-comment");
var userName = document.querySelector(".user-name");
var sub = document.getElementById("btn");
var parent = document.getElementById("parent");
var deviceId = document.getElementById("device-Id");
let audioSRC = "/Audio/mixkit-bell-notification-933.wav";

function ValidateInput() {
    if (userComment.value.length <= 1 || userName.value.length <= 1) {
        return false;
    }
    return true;
}

sub.addEventListener("click", function (e) {
    var isSuccess = ValidateInput();
    var commentToAppend = ` <div>
                                                                     <h3>Customers Feedback</h3>
                                                                     <span style="border-radius:100%; background-color:aqua; color:black">SH</span>
                                                                     <h4>Name:${userName.value}</h4>
                                                                    <p>Comment :${userComment.value}</p>
                                                                    </div>`
    var obj = {
        UserName: userName.value,
        Comment: userComment.value,
        DeviceId: deviceId.value,
    };

    if (isSuccess) {
        $.ajax({
            type: "POST",
            url: "/device/handlecomment",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(obj),
            success: function (data) {
                toastr.success(data.message);
                userComment.value = " ";
                userName.value = " ";
                parent.insertAdjacentHTML('beforeend', commentToAppend);
                const audio = new Audio(audioSRC);
                audio.play();
            }
        });
    } else {
        Swal.fire({
            icon: "error",
            title: "Oops...",
            text: "Please write your name and feedback.",
        });
    }
});

