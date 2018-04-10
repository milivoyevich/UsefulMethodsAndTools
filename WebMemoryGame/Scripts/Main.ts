var interval;

function stisniDugme(ovo) {

}
function pokreniIgru() {
    interval = setInterval(function () {
        console.log('test');
        $.get("./GameTimer", function (data) {
            console.log(data);
        });
        
    }, 1000);
}
function zaustaviIgru() {
    clearInterval(interval);
}