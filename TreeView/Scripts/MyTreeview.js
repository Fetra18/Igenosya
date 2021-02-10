$(document).ready(function () {
    
    $(".collapsing").live("click", (function (e) {
        e.preventDefault();
        var this1 = $(this);
        var data = {
            pid: $(this).attr('pid')

        };
        var isLoaded = $(this).attr('dadata-loaded');
        if (isLoaded == false) {
            $(this1).addClass("loadingP");
            $(this1).removeClass("collapse");

            $.ajax({
                url: "/Treeview/Getsubmenu",
                type: "GET",
                data: data,
                dataType: "json",
                success: function (data) {
                    $(this1).removeClass("loadingP");
                    if (d.length > 0) {
                        var $ul = $("<ul></ul>");
                        $.each(d, function (i, ele) {
                            $ul.append(
                                $("<li></li>").append(
                                    "<span class='collapse collapsing' data-loaded='false' pid='" + ele.MenuID + "'>&nbsp; </span>" +
                                    "<span><a href='" + ele.NaveURL + "'>" + ele.MenuName + "</a></span>"
                                )
                            )
                        });
                        $(this1).parent().append($ul);
                        $(this1).addClass('collapse');
                        $(this1).toggleClass('collapse expand');
                        $(this1).closest('li').children('ul').slideDown();
                    } else {
                        $(this1).css({ 'display': 'inline-block', 'width': '15px' });
                    }
                    $(this1).attr('data-loaded', true);
                },
                error: function () {
                    alert("Error!")
                }
            });
        }
        else {
            $(this1).toggleClass("collapse expand");
            $(this1).closest('li').children('ul').slideToggle();
        }
    }));
});