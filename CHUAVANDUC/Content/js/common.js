/************************************************/
$("body").on("click", ".redirect-btn", function (event) {
    event.preventDefault();
    var url = $(this).attr("data-url");   
    var data = PrepearJasonData("filter-item");
    window.location.href = url + EncodeQueryData(data);
});

/************************************************/
$("body").on("click", ".redirect-only-btn", function (event) {
    event.preventDefault();
    var url = $(this).attr("data-url");
    window.location.href = url;
});


/************************************************/
$("body").on("click", ".redirect-link", function (event) {
    event.preventDefault();
    var url = $(this).attr("href");
    var data = PrepearJasonData("filter-item");
    window.location.href = url + EncodeQueryData(data);
});

/************************************************/
$("body").on("click", ".ajax-link", function (event) {
    event.preventDefault();
    //alert("The page will comming soon...")
    var page = $(this).html();
    $("#content").html('<div class="row"><div id="breadcrumb" class="col-xs-12"><a href="#" class="show-sidebar"><i class="fa fa-bars"></i></a><ol class="breadcrumb pull-left"><li><a href="#">Dashboard</a></li></ol></div></div><h1>' + page + ' will comming soon...</h1>');
});


/*******************toggle- check value ******************************/
$("body").on("click", ".toggle-value", function (event) {
    var v = $(this).val();
    if (v == "True") $(this).val("False");
    else $(this).val("True");
});

/*********************number validation*******************************/
$("body").on("keypress", ".num-val", function (e) {
    //e.preventDefault();
    if (e.which != 46 && e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        return false;
    }
});

//btn
var active_btn = false;
$("body").on("mouseover", ".btn-inline", function (event) {
    active_btn = true;
});
$("body").on("mouseout", ".btn-inline", function (event) {
    active_btn = false;
});
//input
$("body").on("focus", ".input-inline", function (event) {
    $(".btn-inline").hide();
    $(this).prev("button").show();
});
$("body").on("blur", ".input-inline", function (event) {
    if (!active_btn) {
        $(this).prev("button").hide();
    }
});
/*******************change inline input ************************************/
$("body").on("change", ".input-inline", function (event) {
    event.preventDefault();

    var cValue = parseFloat($(this).val());
    var oValue = parseFloat($(this).attr("data-old"));

    if (cValue != oValue) {
        $(this).addClass("change-value");
    } else {
        $(this).removeClass("change-value");
    }
});

function SetErrorMessage(fieldId, message) {

    jQuery(".field-validation-valid").each(function (i) {
        var t = jQuery(this).attr("data-valmsg-for");
        if (t == fieldId) {
            //alert(message);
            jQuery(this).removeClass("field-validation-valid");
            jQuery(this).addClass("field-validation-error");
            jQuery("#" + fieldId).addClass("input-validation-error");

            jQuery(this).html('<span for="' + fieldId + '" generated="true" class="">' + message + '</span>');

        }
    });
}

function RemoveErrorMessage(fieldId) {

    jQuery(".field-validation-error").each(function (i) {
        var t = jQuery(this).attr("data-valmsg-for");
        if (t == fieldId) {
            //alert(message);
            jQuery(this).removeClass("field-validation-error");
            jQuery(this).addClass("field-validation-valid");
            jQuery(this).html('');
            jQuery("#" + fieldId).removeClass("input-validation-error");
        }
    });
}

function InitSortingHeader(id) {

    $('#' + id + ' .table  thead  th').on("click", function (event) {
        event.preventDefault();
        var action = $(this).attr("class");
        var suffix = $(this).attr("data-suffix");
        
        if (suffix != null && suffix != "") {
            $("#option-action").val(suffix);
            suffix = "-" + suffix
        }

        //alert(suffix)


        if (action != "" && action != null) {
            if (action == "sorting") {
                $('#' + id + " .sorting_asc").removeClass("sorting_asc").addClass("sorting");
                $('#' + id + " .sorting_desc").removeClass("sorting_desc").addClass("sorting");
                $(this).removeClass("sorting").addClass("sorting_asc");
                $("#sort-direction" + suffix).val("asc");
            } else if (action == "sorting_asc") {
                $('#' + id + " .sorting_asc").removeClass("sorting_asc").addClass("sorting_desc");
                $("#sort-direction" + suffix).val("desc");
            }
            else if (action == "sorting_desc") {
                $('#' + id + " .sorting_desc").removeClass("sorting_desc").addClass("sorting_asc");
                $("#sort-direction" + suffix).val("asc");
            }

            $("#sort-name" + suffix).val($(this).attr("data-sort"));
            $("#page-number" + suffix).val("1");

            LoadTableData();
        }
    });
}

function DeleteConfirmationModal(name, id) {

    //fixed size modal
    $(".devoops-modal").css("width", 350);

    //$("#my-email").html(email);
    var html = "Are you sure want to delete - " + name + "?";
    var html2 = ' <button id="delete-ok-button" class="btn btn-success ladda-button"  data-style="slide-left" style="margin:0; width:80px;; float:right;" onClick="DeleteItem(' + id + ');">OK</button><button id="delete-cancel-btn" class="btn btn-danger" style="margin:0;margin-right: 10px; width:80px; float:right;" onClick="CloseModalBox();">Cancel</button>';

    OpenModalBox("Delete Confirmation", html, html2);

    var h = $(window).height();
    //var w = $(window).width();
    ////$(".devoops-modal").css('width', 'auto');
    $(".devoops-modal").css('height', 'auto');
    var h2 = $(".devoops-modal").height();
    //var w2 = 300;//$(".devoops-modal").width();
    var top = (h / 2) - (h2 / 2);
    //var left = (w / 2) - (w2 / 2);
    //$(".devoops-modal").css('left', left + 'px');
    $(".devoops-modal").css('top', top + 'px');
}

/********************************************************/
function ConfirmationModalCustomize(title, message, functionName) {
    //fixed size modal
    $(".devoops-modal").css("width", 350);

    //$("#my-email").html(email);
    var html = message;
    var html2 = '<button id="delete-ok-button" class="btn btn-success ladda-button"  data-style="slide-left" style="margin:0; width:80px;; float:right;" onClick="' + functionName + '";>OK</button><button id="delete-cancel-btn" class="btn btn-danger" style="margin:0;margin-right: 10px; width:80px; float:right;" onClick="CloseModalBox();">Cancel</button>';

    OpenModalBox(title, html, html2);

    var h = $(window).height();
    //var w = $(window).width();
    ////$(".devoops-modal").css('width', 'auto');
    $(".devoops-modal").css('height', 'auto');
    var h2 = $(".devoops-modal").height();
    //var w2 = 300;//$(".devoops-modal").width();
    var top = (h / 2) - (h2 / 2);
    //var left = (w / 2) - (w2 / 2);
    //$(".devoops-modal").css('left', left + 'px');
    $(".devoops-modal").css('top', top + 'px');
}

function ShowFormModal(title, html, html2, w) {

    if (w == "" || w == null) {
        w = 600;
    }
    //fixed size modal
    $(".devoops-modal").css("width", w);

    if (html2 == "" || html2 == null) {
        html2 = '<button style="margin:0; width:80px; float:right;" data-style="slide-left" class="btn btn-success form-modal-save-btn ladda-button" id="form-modal-save-btn">Save</button><button onclick="CloseModalBox();" style="margin:0;margin-right: 10px; width:80px; float:right;" class="btn btn-danger" id="form-modal-cancel-btn">Cancel</button>'
    }else if (html2 == "no-footer") {
        html2 = ''
    }

    OpenModalBox(title, html, html2);

    var h = $(window).height();
    //var w = $(window).width();
    //$(".devoops-modal").css('width', 'auto');
    $(".devoops-modal").css('height', 'auto');
    var h2 = $(".devoops-modal").height();

   // var w2 = 600;//$(".devoops-modal").width();
    var top = (h / 2) - (h2 / 2);
    if (top <= 0) {
        top = 10;
    }

    //var left = (w / 2) - (w2 / 2);
    //$(".devoops-modal").css('left', left + 'px');
    $(".devoops-modal").css('top', top + 'px');
}

function ShowFormModalCustomize(id, title, html, html2, w) {

    if (w == "" || w == null) {
        w = 600;
    }
    //fixed size modal
    $("#" +id + " .devoops-modal").css("width", w);


    if (html2 == "" || html2 == null) {
        html2 = '<button style="margin:0; width:80px; float:right;" data-style="slide-left" class="btn btn-success form-modal-save-btn ladda-button" id="form-modal-save-btn">Save</button><button onclick="CloseModalBoxCustomize(\'' + id + '\');" style="margin:0;margin-right: 10px; width:80px; float:right;" class="btn btn-danger" id="form-modal-cancel-btn">Cancel</button>'
    } else if (html2 == "no-footer") {
        html2 = ''
    }

    OpenModalBoxCustomize(id, title, html, html2);

    var h = $(window).height();
    //var w = $(window).width();
    //$(".devoops-modal").css('width', 'auto');
    $("#" + id + " .devoops-modal").css('height', 'auto');
    var h2 = $("#" + id + " .devoops-modal").height();

    // var w2 = 600;//$(".devoops-modal").width();
    var top = (h / 2) - (h2 / 2);
    if (top <= 0) {
        top = 10;
    }

    //var left = (w / 2) - (w2 / 2);
    //$(".devoops-modal").css('left', left + 'px');
    $("#" + id + " .devoops-modal").css('top', top + 'px');
}

function PrepearJasonData(classname) {

    classname = "." + classname

    var jsonData = {};
    jQuery("input" + classname).each(function (index) {
        if (jQuery(this).attr("datepicker") == "datepicker") {
            jsonData[jQuery(this).attr("name")] = AlterDateStr(jQuery(this).val());
        } else if (jQuery(this).attr("type") == "radio") {
            if (jQuery(this).is(":checked")) {
                jsonData[jQuery(this).attr("name")] = jQuery(this).val();
            }
        } else {
            jsonData[jQuery(this).attr("name")] = jQuery(this).val();
        }
    });

    jQuery("select" + classname).each(function (index) {
        jsonData[jQuery(this).attr("name")] = jQuery(this).val();
    });

    jQuery("textarea" + classname).each(function (index) {
        jsonData[jQuery(this).attr("name")] = jQuery(this).val();
    });


    //var data = "{'model':" + JSON.stringify(jsonData) + ", 'conditions':" + JSON.stringify(items) + ", 'medications':" + JSON.stringify(items2) + "}";


    return jsonData;

}

function PrepearJasonFormData(classname) {

    classname = "." + classname

    var jsonData = {};

    jQuery(classname + " input[type=text]").each(function (index) {
        if (jQuery(this).attr("datepicker") == "datepicker") {
            jsonData[jQuery(this).attr("name")] = AlterDateStr(jQuery(this).val());
        } else {
            jsonData[jQuery(this).attr("name")] = jQuery(this).val();
        }      
    });

    jQuery(classname + " input[type=email]").each(function (index) {
        jsonData[jQuery(this).attr("name")] = jQuery(this).val();
    });

    jQuery(classname + " input[type=password]").each(function (index) {
        jsonData[jQuery(this).attr("name")] = jQuery(this).val();
    });

    //for textarea input
    jQuery(classname + " textarea").each(function (index) {
        jsonData[jQuery(this).attr("name")] = jQuery(this).val();
    });
    //for select input
    jQuery(classname + " select").each(function (index) {
        jsonData[jQuery(this).attr("name")] = jQuery(this).val();
    });

    //for text inputs
    jQuery(classname + " input[type=hidden]").each(function (index) {
        jsonData[jQuery(this).attr("name")] = jQuery(this).val();
    });

    var ary = "";
    jQuery(classname + " input[type=checkbox]:checked").each(function (index) {
        var name = jQuery(this).attr("name");
        if (ary == name) {
            jsonData[jQuery(this).attr("name")] += "," + jQuery(this).val();
        } else {
            jsonData[jQuery(this).attr("name")] = jQuery(this).val();
        }
        ary = name;
    });

    ary = "";
    jQuery(classname + " input[type=checkbox]:not(:checked)").each(function (index) {
        var name = jQuery(this).attr("name");
        if (ary == name) {
            jsonData[jQuery(this).attr("name")] += "," + jQuery(this).val();
        } else {
            jsonData[jQuery(this).attr("name")] = jQuery(this).val();
        }
        ary = name;
    });


    jQuery(classname + " input[type=radio]:checked").each(function (index) {
        jsonData[jQuery(this).attr("name")] = jQuery(this).val();
    });



    return jsonData;
}

function SetPageNumberForDelete() {

    var currentPage = jQuery("#page-number").val();
    if (isNaN(currentPage) || currentPage == "" || currentPage == null)
        currentPage = 1;

    var rows = jQuery(".table tbody tr").length;
    if (currentPage > 1 && rows == 1) {
        currentPage = currentPage - 1;
    }

    jQuery("#page-number").val(currentPage)
}

function EncodeQueryData(data) {
    var ret = [];
    for (var d in data) {
        if (data[d] != "" && data[d] != null)
            ret.push(encodeURIComponent(d) + "=" + encodeURIComponent(data[d]));
    }
    return "?" + ret.join("&");
}

function AlterDateStr(date) {
    if (date != "") {
        var arr = date.split('/');
        return arr[1] + "/" + arr[0] + "/" + arr[2];
    }
    else {
        return null;
    }
}

function InitNumberSpiner() {
    $(".number-spiner").TouchSpin({
        verticalbuttons: true
    });
}

/******************* set time zone cookie ************/
function SetTimezoneCookie() {

    var timezone_cookie = "timezoneoffset";

    // if the timezone cookie not exists create one.
    if (!$.cookie(timezone_cookie)) {
        // create a new cookie
        $.cookie(timezone_cookie, new Date().getTimezoneOffset(),{ expires: 120, path: '/' });
    }
        // if the current timezone and the one stored in cookie are different
        // then store the new timezone in the cookie and refresh the page.
    else {
        var storedOffset = parseInt($.cookie(timezone_cookie));
        var currentOffset = new Date().getTimezoneOffset();

        // user may have changed the timezone
        if (storedOffset !== currentOffset) {
            $.cookie(timezone_cookie, new Date().getTimezoneOffset(), { expires: 120, path: '/' });
        }
    }
}
