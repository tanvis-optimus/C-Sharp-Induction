// For changing background color
function changeColor(selector, colors, time) {
    var curCol = 0,
        timer = setInterval(function () {
            if (curCol === colors.length) curCol = 0;
            $(selector).animate({
                backgroundColor: colors[curCol]
            }, 1000);
            curCol++;
        }, time);
}
// For form validation
function validate(e) {
    var location_element = document.querySelector('#tx_location');
    var location_error_element = document.querySelector('#tx_error');
    var location_regex = /^(?![0-9]*$)[a-zA-Z0-9-, ]+$/;
    if (!location_regex.test(location_element.value)) {
        //display error messege
        location_error_element.classList.remove("hidden");
        return false;
    } else {
        //remove error mesege
        location_error_element.classList.add("hidden");        
        return true;
    }
}
$(window).on('load', function () {
    changeColor("body", ["rgba(0,128,0,0.6)", "rgba(128,0,128, 0.6)", "rgba(0,0,128,0.6)"], 3000);
});
