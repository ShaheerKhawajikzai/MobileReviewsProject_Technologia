var btn = document.querySelector(".hamburger");
var nav = document.querySelector(".nav-bar");
btn.addEventListener("click", function () {
    console.log(nav, btn)
    nav.classList.toggle("toggle-nav");
});