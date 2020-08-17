let navbar = document.getElementById("navbar");
let sticky = screen.height - 200;
let timmerHanler;

window.onscroll = function () {
    stickyFunction();
};

function stickyFunction() {
    clearTimeout(timmerHanler);
    timmerHanler = setTimeout(() => {
        let offset = window.pageYOffset;
        if (offset > sticky) {
            navbar.classList.add("sticky")
        }
        else {
            navbar.classList.remove("sticky")
        }
    }, 10);
}