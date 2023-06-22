//Tu JS fuctions
$(function popoverBottom() {
    $('[data-toggle="popoverBt"]').popover({
        placement: "bottom",
        delay: 400,
        trigger: "hover"
    })
})

$(function popoverTop() {
    $('[data-toggle="popoverTp"]').popover({
        placement: "top",
        delay: 400,
        trigger: "hover"
    })
})