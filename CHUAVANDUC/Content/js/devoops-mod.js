//
//  Helper for open ModalBox with requested header, content and bottom
//
//
function OpenModalBox(header, inner, bottom) {
    var modalbox = $('#modalbox');
    modalbox.find('.modal-header-name span').html(header);
    modalbox.find('.devoops-modal-inner').html(inner);
    modalbox.find('.devoops-modal-bottom').html(bottom);
    modalbox.fadeIn('fast');
    $('body').addClass("body-expanded");
}

function OpenModalBoxCustomize(id, header, inner, bottom) {
    var modalbox = $('#' + id);
    modalbox.find('.modal-header-name span').html(header);
    modalbox.find('.devoops-modal-inner').html(inner);
    modalbox.find('.devoops-modal-bottom').html(bottom);
    modalbox.fadeIn('fast');
    $('body').addClass("body-expanded");
}
//
//  Close modalbox
//
//
function CloseModalBox() {
    var modalbox = $('#modalbox-2');
    if (!modalbox.is(':visible')) {
        modalbox = $('#modalbox')
    }
    modalbox.fadeOut('fast', function () {
        modalbox.find('.modal-header-name span').children().remove();
        modalbox.find('.devoops-modal-inner').children().remove();
        modalbox.find('.devoops-modal-bottom').children().remove();
        $('body').removeClass("body-expanded");
    });
    $('.devoops-modal-bottom').show();
}

function CloseModalBoxCustomize(id)
{
    var modalbox = $('#' + id);
    modalbox.fadeOut('fast', function () {
        modalbox.find('.modal-header-name span').children().remove();
        modalbox.find('.devoops-modal-inner').children().remove();
        modalbox.find('.devoops-modal-bottom').children().remove();
        if (!$('#modalbox').is(':visible'))
        {
            $('body').removeClass("body-expanded");
        }
    });
    $('#' + id + ' .devoops-modal-bottom').show();
}

//////////////////////////////////////////////////////
//////////////////////////////////////////////////////
//
//      MAIN DOCUMENT READY SCRIPT OF DEVOOPS THEME
//
//      In this script main logic of theme
//
//////////////////////////////////////////////////////
//////////////////////////////////////////////////////
$(document).ready(function () {
    $('body').on('click', '.show-sidebar', function (e) {
        e.preventDefault();
        $('div#main').toggleClass('sidebar-show');
        setTimeout(MessagesMenuWidth, 250);
    });
    //var ajax_url = location.hash.replace(/^#/, '');
    //if (ajax_url.length < 1) {
    //	ajax_url = 'ajax/dashboard.html';
    //}
    //LoadAjaxContent(ajax_url);
    $('.main-menu').on('click', 'a', function (e) {
        var parents = $(this).parents('li');
        var li = $(this).closest('li.dropdown');
        var another_items = $('.main-menu li').not(parents);
        another_items.find('a').removeClass('active');
        another_items.find('a').removeClass('active-parent');
        another_items.find('a').children("small").first().removeClass("fa-angle-down").addClass("fa-angle-right");
        if ($(this).hasClass('dropdown-toggle') || $(this).closest('li').find('ul').length == 0) {
            $(this).addClass('active-parent');
            var current = $(this).next();
            if (current.is(':visible')) {
                li.find("ul.dropdown-menu").slideUp('fast');
                li.find("ul.dropdown-menu a").removeClass('active');
                //alert("111")
                $(this).children("small").first().removeClass("fa-angle-down").addClass("fa-angle-right");
            }
            else {
                another_items.find("ul.dropdown-menu").slideUp('fast');
                current.slideDown('fast');
                //alert("222")
                $(this).children("small").first().removeClass("fa-angle-right").addClass("fa-angle-down");
            }
        }
        else {
            if (li.find('a.dropdown-toggle').hasClass('active-parent')) {
                var pre = $(this).closest('ul.dropdown-menu');
                pre.find("li.dropdown").not($(this).closest('li')).find('ul.dropdown-menu').slideUp('fast');
            }
        }
        if ($(this).hasClass('active') == false) {
            $(this).parents("ul.dropdown-menu").find('a').removeClass('active');
            $(this).addClass('active')
            //alert("111")
        }
        //if ($(this).hasClass('ajax-link')) {
        //    e.preventDefault();
        //    if ($(this).hasClass('add-full')) {
        //        $('#content').addClass('full-content');
        //    }
        //    else {
        //        $('#content').removeClass('full-content');
        //    }
        //    var url = $(this).attr('href');
        //    window.location.hash = url;
        //    LoadAjaxContent(url);
        //}
        if ($(this).attr('href') == '#') {
            e.preventDefault();
        }
    });
    var height = window.innerHeight - 49;
    $('#main').css('min-height', height)
		.on('click', '.expand-link', function (e) {
		    var body = $('body');
		    e.preventDefault();
		    var box = $(this).closest('div.box');
		    var button = $(this).find('i');
		    button.toggleClass('fa-expand').toggleClass('fa-compress');
		    box.toggleClass('expanded');
		    body.toggleClass('body-expanded');
		    var timeout = 0;
		    if (body.hasClass('body-expanded')) {
		        timeout = 100;
		    }
		    setTimeout(function () {
		        box.toggleClass('expanded-padding');
		    }, timeout);
		    setTimeout(function () {
		        box.resize();
		        box.find('[id^=map-]').resize();
		    }, timeout + 50);
		})
		.on('click', '.collapse-link', function (e) {
		    e.preventDefault();
		    var box = $(this).closest('div.box');
		    var button = $(this).find('i');
		    var content = box.find('div.box-content');
		    content.slideToggle('fast');
		    button.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
		    setTimeout(function () {
		        box.resize();
		        box.find('[id^=map-]').resize();
		    }, 50);
		})
		.on('click', '.close-link', function (e) {
		    e.preventDefault();
		    var content = $(this).closest('div.box');
		    content.remove();
		});
    $('#locked-screen').on('click', function (e) {
        e.preventDefault();
        $('body').addClass('body-screensaver');
        $('#screensaver').addClass("show");
        ScreenSaver();
    });
    $('body').on('click', 'a.close-link', function (e) {
        e.preventDefault();
        CloseModalBox();
    });
    $('#top-panel').on('click', 'a', function (e) {
        if ($(this).hasClass('ajax-link')) {
            e.preventDefault();
            if ($(this).hasClass('add-full')) {
                $('#content').addClass('full-content');
            }
            else {
                $('#content').removeClass('full-content');
            }
            var url = $(this).attr('href');
            window.location.hash = url;
            LoadAjaxContent(url);
        }
    });
    $('#search').on('keydown', function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $('#content').removeClass('full-content');
            ajax_url = 'ajax/page_search.html';
            window.location.hash = ajax_url;
            LoadAjaxContent(ajax_url);
        }
    });
    $('#screen_unlock').on('mouseover', function () {
        var header = 'Enter current username and password';
        var form = $('<div class="form-group"><label class="control-label">Username</label><input type="text" class="form-control" name="username" /></div>' +
					'<div class="form-group"><label class="control-label">Password</label><input type="password" class="form-control" name="password" /></div>');
        var button = $('<div class="text-center"><a href="index.html" class="btn btn-primary">Unlock</a></div>');
        OpenModalBox(header, form, button);
    });
    $('.about').on('click', function () {
        $('#about').toggleClass('about-h');
    })
    $('#about').on('mouseleave', function () {
        $('#about').removeClass('about-h');
    })
});


/*-------------------------------------------
	Demo graphs for xCharts page (charts_xcharts.html)
---------------------------------------------*/
//
// Graph1 created in element with id = xchart-1
//
function xGraph1() {
    var tt = document.createElement('div'),
	leftOffset = -(~~$('html').css('padding-left').replace('px', '') + ~~$('body').css('margin-left').replace('px', '')),
	topOffset = -32;
    tt.className = 'ex-tooltip';
    document.body.appendChild(tt);
    var data = {
        "xScale": "time",
        "yScale": "linear",
        "main": [
			{
			    "className": ".xchart-class-1",
			    "data": [
                    {
                        "x": "2012-11-05",
                        "y": 6
                    },
                    {
                        "x": "2012-11-06",
                        "y": 6
                    },
                    {
                        "x": "2012-11-07",
                        "y": 8
                    },
                    {
                        "x": "2012-11-08",
                        "y": 3
                    },
                    {
                        "x": "2012-11-09",
                        "y": 4
                    },
                    {
                        "x": "2012-11-10",
                        "y": 9
                    },
                    {
                        "x": "2012-11-11",
                        "y": 6
                    },
                    {
                        "x": "2012-11-12",
                        "y": 16
                    },
                    {
                        "x": "2012-11-13",
                        "y": 4
                    },
                    {
                        "x": "2012-11-14",
                        "y": 9
                    },
                    {
                        "x": "2012-11-15",
                        "y": 2
                    }
			    ]
			}
        ]
    };
    var opts = {
        "dataFormatX": function (x) { return d3.time.format('%Y-%m-%d').parse(x); },
        "tickFormatX": function (x) { return d3.time.format('%A')(x); },
        "mouseover": function (d, i) {
            var pos = $(this).offset();
            $(tt).text(d3.time.format('%A')(d.x) + ': ' + d.y)
				.css({ top: topOffset + pos.top, left: pos.left + leftOffset })
				.show();
        },
        "mouseout": function (x) {
            $(tt).hide();
        }
    };
    var myChart = new xChart('line-dotted', data, '#xchart-1', opts);
}
//
// Graph2 created in element with id = xchart-2
//
function xGraph2() {
    var data = {
        "xScale": "ordinal",
        "yScale": "linear",
        "main": [
            {
                "className": ".xchart-class-2",
                "data": [
                    {
                        "x": "Apple",
                        "y": 575
                    },
                    {
                        "x": "Facebook",
                        "y": 163
                    },
                    {
                        "x": "Microsoft",
                        "y": 303
                    },
                    {
                        "x": "Cisco",
                        "y": 121
                    },
                    {
                        "x": "Google",
                        "y": 393
                    }
                ]
            }
        ]
    };
    var myChart = new xChart('bar', data, '#xchart-2');
}
//
// Graph3 created in element with id = xchart-3
//
function xGraph3() {
    var data = {
        "xScale": "time",
        "yScale": "linear",
        "type": "line",
        "main": [
		{
		    "className": ".xchart-class-3",
		    "data": [
				{
				    "x": "2012-11-05",
				    "y": 1
				},
				{
				    "x": "2012-11-06",
				    "y": 6
				},
				{
				    "x": "2012-11-07",
				    "y": 13
				},
				{
				    "x": "2012-11-08",
				    "y": -3
				},
				{
				    "x": "2012-11-09",
				    "y": -4
				},
				{
				    "x": "2012-11-10",
				    "y": 9
				},
				{
				    "x": "2012-11-11",
				    "y": 6
				},
				{
				    "x": "2012-11-12",
				    "y": 7
				},
				{
				    "x": "2012-11-13",
				    "y": -2
				},
				{
				    "x": "2012-11-14",
				    "y": -7
				}
		    ]
		}
        ]
    };
    var opts = {
        "dataFormatX": function (x) { return d3.time.format('%Y-%m-%d').parse(x); },
        "tickFormatX": function (x) { return d3.time.format('%A')(x); }
    };
    var myChart = new xChart('line', data, '#xchart-3', opts);
}

//
// Helper for run TinyMCE editor with textarea's
//
function TinyMCEStart(elem, mode){
	var plugins = [];
	if (mode == 'extreme'){
		plugins = [ "advlist anchor autolink autoresize autosave bbcode charmap code contextmenu directionality ",
			"emoticons fullpage fullscreen hr image insertdatetime layer legacyoutput",
			"link lists media nonbreaking noneditable pagebreak paste preview print save searchreplace",
			"tabfocus table template textcolor visualblocks visualchars wordcount"]
	}
	tinymce.init({selector: elem,
		theme: "modern",
		plugins: plugins,
		//content_css: "css/style.css",
		toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | print preview media fullpage | forecolor backcolor emoticons",
		style_formats: [
			{title: 'Header 2', block: 'h2', classes: 'page-header'},
			{title: 'Header 3', block: 'h3', classes: 'page-header'},
			{title: 'Header 4', block: 'h4', classes: 'page-header'},
			{title: 'Header 5', block: 'h5', classes: 'page-header'},
			{title: 'Header 6', block: 'h6', classes: 'page-header'},
			{title: 'Bold text', inline: 'b'},
			{title: 'Red text', inline: 'span', styles: {color: '#ff0000'}},
			{title: 'Red header', block: 'h1', styles: {color: '#ff0000'}},
			{title: 'Example 1', inline: 'span', classes: 'example1'},
			{title: 'Example 2', inline: 'span', classes: 'example2'},
			{title: 'Table styles'},
			{title: 'Table row 1', selector: 'tr', classes: 'tablerow1'}
		]
	});
}
//