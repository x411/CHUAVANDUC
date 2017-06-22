/*! light-blue - v3.3.0 - 2016-03-08 */
function triggerChartsResize() {
    try {
        window.onresize && window.onresize()
    } catch (a) { }
    $(window).trigger("resize")
}
$(function () {
    var a = $("#settings"),
        b = $("#sidebar-settings"),
        c = JSON.parse(localStorage.getItem("settings-state")) || {
            sidebar: "left",
            sidebarState: "auto",
            displaySidebar: !0
        },
        d = $(".page-header"),
        e = $("body"),
        f = function () {
            a.data("bs.popover").hoverState = "out", a.popover("hide")
        },
        g = function (b) {
            var c = a.siblings(".popover");
            c.length && !$.contains(c[0], b.target) && (f(), $(document).off("click", g))
        },
        h = function (a) {
            "right" == a ? e.addClass("sidebar-on-right") : e.removeClass("sidebar-on-right")
        },
        i = function (a, c) {
            var d = $("#sidebar-settings-template");
            c = void 0 == c ? !0 : !1, d[0] && (b.html(_.template(d.html())({
                sidebarState: a
            })), "auto" == a ? $(".sidebar, .side-nav, .wrap, .logo").removeClass("sidebar-icons") : $(".sidebar, .side-nav, .wrap, .logo").addClass("sidebar-icons"), c && triggerChartsResize())
        },
        j = function (a, b) {
            b = void 0 == b ? !0 : !1, 1 == a ? e.removeClass("sidebar-hidden") : e.addClass("sidebar-hidden"), b && triggerChartsResize()
        };
    h(c.sidebar), i(c.sidebarState, !1), j(c.displaySidebar, !1), a[0] && (a.popover({
        template: '<div class="popover settings-popover"><div class="arrow"></div><div class="popover-inner"><div class="popover-content"></div></div></div>',
        html: !0,
        animation: !1,
        placement: "bottom",
        content: function () {
            return _.template($("#settings-template").html())(c)
        }
    }).click(function (a) {
        return $(".page-header .dropdown.open .dropdown-toggle").dropdown("toggle"), $(document).on("click", g), $(this).focus(), !1
    }), $(".page-header .dropdown-toggle").click(function () {
        f(), $(document).off("click", g)
    }), d.on("click", ".popover #sidebar-toggle .btn", function () {
        var a = $(this),
            b = a.data("value");
        h(b), c.sidebar = b, localStorage.setItem("settings-state", JSON.stringify(c))
    }), d.on("click", ".popover #display-sidebar-toggle .btn", function () {
        var a = $(this),
            b = a.data("value");
        j(b), c.displaySidebar = b, localStorage.setItem("settings-state", JSON.stringify(c))
    }), b.on("click", ".btn", function () {
        var a = $(this),
            b = a.data("value");
        "icons" == b && closeNavigation(), i(b), c.sidebarState = b, localStorage.setItem("settings-state", JSON.stringify(c))
    }), ($("#sidebar").is(".sidebar-icons") || $(window).width() < 1049) && $(window).width() > 767 && closeNavigation(), d.on("click", ".popover [data-toggle='buttons-radio'] .btn:not(.active)", function () {
        var a = $(this),
            b = a.parent().find(".btn");
        b.removeClass("active"), setTimeout(function () {
            a.addClass("active")
        }, 0)
    }))
}), window.LightBlue = {
    screens: {
        "xs-max": 767,
        "sm-min": 768,
        "sm-max": 991,
        "md-min": 992,
        "md-max": 1199,
        "lg-min": 1200
    },
    isScreen: function (a) {
        var b = window.innerWidth;
        return (b >= this.screens[a + "-min"] || "xs" == a) && (b <= this.screens[a + "-max"] || "lg" == a)
    },
    getScreenSize: function () {
        var a = window.innerWidth;
        return a <= this.screens["xs-max"] ? "xs" : a >= this.screens["sm-min"] && a <= this.screens["sm-max"] ? "sm" : a >= this.screens["md-min"] && a <= this.screens["md-max"] ? "md" : a >= this.screens["lg-min"] ? "lg" : void 0
    },
    changeColor: function (a, b, c) {
        var d = function (a, b) {
            var c = "0";
            for (a += ""; a.length < b;) a = c + a;
            return a
        };
        a = a.replace(/^\s*|\s*$/, ""), a = a.replace(/^#?([a-f0-9])([a-f0-9])([a-f0-9])$/i, "#$1$1$2$2$3$3");
        var e = Math.round(256 * b) * (c ? -1 : 1),
            f = a.match(new RegExp("^rgba?\\(\\s*(\\d|[1-9]\\d|1\\d{2}|2[0-4][0-9]|25[0-5])\\s*,\\s*(\\d|[1-9]\\d|1\\d{2}|2[0-4][0-9]|25[0-5])\\s*,\\s*(\\d|[1-9]\\d|1\\d{2}|2[0-4][0-9]|25[0-5])(?:\\s*,\\s*(0|1|0?\\.\\d+))?\\s*\\)$", "i")),
            g = f && null != f[4] ? f[4] : null,
            h = f ? [f[1], f[2], f[3]] : a.replace(/^#?([a-f0-9][a-f0-9])([a-f0-9][a-f0-9])([a-f0-9][a-f0-9])/i, function () {
                return parseInt(arguments[1], 16) + "," + parseInt(arguments[2], 16) + "," + parseInt(arguments[3], 16)
            }).split(/,/);
        return f ? "rgb" + (null !== g ? "a" : "") + "(" + Math[c ? "max" : "min"](parseInt(h[0], 10) + e, c ? 0 : 255) + ", " + Math[c ? "max" : "min"](parseInt(h[1], 10) + e, c ? 0 : 255) + ", " + Math[c ? "max" : "min"](parseInt(h[2], 10) + e, c ? 0 : 255) + (null !== g ? ", " + g : "") + ")" : ["#", d(Math[c ? "max" : "min"](parseInt(h[0], 10) + e, c ? 0 : 255).toString(16), 2), d(Math[c ? "max" : "min"](parseInt(h[1], 10) + e, c ? 0 : 255).toString(16), 2), d(Math[c ? "max" : "min"](parseInt(h[2], 10) + e, c ? 0 : 255).toString(16), 2)].join("")
    },
    lighten: function (a, b) {
        return this.changeColor(a, b, !1)
    },
    darken: function (a, b) {
        return this.changeColor(a, b, !0)
    }
};