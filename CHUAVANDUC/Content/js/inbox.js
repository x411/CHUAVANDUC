/*! light-blue - v3.3.0 - 2016-03-08 */
$(function () {
    function a() {
        "use strict";
        var a = 33,
            b = Backbone.Model.extend({
                defaults: function () {
                    return {
                        sender: "",
                        senderMail: "",
                        subject: "",
                        body: e[Math.round(3 * Math.random())],
                        receiver: "",
                        timestamp: new Date((new Date).getTime() - 72e5).getTime(),
                        read: !0,
                        starred: !1,
                        attachment: !1,
                        folderId: 1,
                        selected: !1
                    }
                },
                markRead: function () {
                    this.save({
                        read: !0
                    })
                },
                toggleStarred: function () {
                    this.save({
                        starred: !this.get("starred")
                    })
                },
                toggleSelected: function () {
                    this.save({
                        selected: !this.get("selected")
                    })
                }
            }),
            c = Backbone.Model.extend({
                defaults: {
                    name: "",
                    current: !1,
                    order: 3,
                    unread: 0
                },
                sync: function () { }
            }),
            f = Backbone.Collection.extend({
                model: c,
                url: "js/json/folders.json",
                comparator: "order",
                parse: function (b) {
                    return b.push({
                        name: "Starred",
                        id: a,
                        order: 4
                    }), b
                }
            }),
            g = new f,
            h = Backbone.View.extend({
                tagName: "li",
                template: _.template($("#folder-template").html()),
                events: {
                    click: "selectFolder"
                },
                initialize: function () {
                    this.listenTo(this.model, "change", this.render)
                },
                render: function () {
                    return this.$el.attr("class", this.model.get("current") ? "active" : ""), this.$el.html(this.template(this.model.toJSON())), this
                },
                selectFolder: function () {
                    var a = this;
                    g.each(function (b) {
                        b.save({
                            current: b == a.model
                        })
                    }), q.showEmailsView()
                }
            }),
            i = window.EmailList = Backbone.Collection.extend({
                model: b,
                url: "js/json/emails.json",
                comparator: function (a) {
                    return -a.get("timestamp")
                },
                search: function (a, b) {
                    if ("" == a) return this.where({
                        folderId: b
                    });
                    var c = new RegExp(a, "gi");
                    return this.filter(function (a) {
                        return a.get("folderId") == b && c.test(a.get("subject")) || c.test(a.get("sender"))
                    })
                }
            }),
            j = new i,
            k = Backbone.View.extend({
                tagName: "tr",
                template: _.template($("#mail-item-template").html()),
                events: {
                    "change .selected-checkbox": "toggleSelected",
                    "click .starred": "toggleStarred",
                    "click .name,.subject": "openEmail"
                },
                initialize: function () {
                    this.listenTo(this.model, "change", this.render)
                },
                render: function () {
                    return this.$el.attr("class", this.model.get("read") ? "" : "unread"), this.$el.html(this.template(this.model.toJSON())), this
                },
                formatDate: function (a) {
                    var b = new Date(a),
                        c = new Date,
                        d = new Date(c.getFullYear(), c.getMonth(), c.getDate());
                    return b.getTime() > d ? b.getHours() + ":" + (b.getMinutes() < 10 ? "0" + b.getMinutes() : b.getMinutes()) : ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"][b.getMonth()] + " " + b.getDate()
                },
                toggleSelected: function () {
                    this.model.toggleSelected()
                },
                toggleStarred: function () {
                    this.model.toggleStarred()
                },
                openEmail: function () {
                    this.model.save({
                        read: !0
                    }), q.setCurrentView(new l({
                        model: this.model
                    }))
                }
            }),
            l = Backbone.View.extend({
                template: _.template($("#email-view-template").html()),
                attributes: {
                    id: "email-view",
                    "class": "email-view"
                },
                events: {
                    "click #email-opened-reply": "replyEmail"
                },
                initialize: function () {
                    this.listenTo(this.model, "change", this.render)
                },
                render: function () {
                    return $("#widget-email-header").html("<h4>" + this.model.get("subject") + '</h4><div class="widget-controls"><a href="#"><i class="fa fa-print"></i></a></div>'), $("#folder-stats").addClass("hide"), $("#back-btn").removeClass("hide"), this.$el.html(this.template(this.model.toJSON())), this
                },
                formatDate: function (a) {
                    var b = new Date(a),
                        c = new Date,
                        d = new Date(c.getFullYear(), c.getMonth(), c.getDate());
                    if (b.getTime() > d) return b.getHours() + ":" + (b.getMinutes() < 10 ? "0" + b.getMinutes() : b.getMinutes());
                    var e = Math.floor((c.getTime() - b.getTime()) / 864e5);
                    return ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"][b.getMonth()] + " " + b.getDate() + " (" + e + " days ago)"
                },
                replyEmail: function () {
                    var a = "<br/><br/><blockquote class='blockquote-sm'>" + this.model.get("body") + "</blockquote> <br/>",
                        c = new b({
                            body: a,
                            receiver: this.model.get("sender") ? this.model.get("sender") : this.model.get("senderMail"),
                            subject: "Re: " + this.model.get("subject")
                        });
                    q.showComposeView(c)
                }
            }),
            m = Backbone.View.extend({
                template: _.template($("#compose-view-template").html()),
                attributes: {
                    id: "compose-view",
                    "class": "compose-view"
                },
                events: {
                    "click #compose-save-button, #compose-send-button, #compose-discard-button": "backToFolders"
                },
                render: function () {
                    return $("#widget-email-header").html('<h4>Compose <span class="fw-semi-bold">New</span></h4>'), $("#folder-stats").addClass("hide"), $("#back-btn").removeClass("hide"), this.$el.html(this.template(this.model.toJSON())), this._initViewComponents(), this
                },
                backToFolders: function () {
                    q.showEmailsView()
                },
                _initViewComponents: function () {
                    this.$("textarea").wysihtml5({
                        html: !0,
                        customTemplates: d,
                        stylesheets: ["data:text/css,body{ background-color: transparent !important; }"],
                        toolbar: {
                            size: "sm btn-transparent"
                        }
                    })
                }
            }),
            n = Backbone.View.extend({
                tagName: "table",
                attributes: {
                    id: "folder-view",
                    "class": "table table-striped table-emails table-hover table-lg mb-sm"
                },
                template: _.template($("#folders-view-template").html()),
                events: {
                    "change #toggle-all": "toggleAll"
                },
                initialize: function () {
                    this.currentFolderEmails = new i, this.folders = g, this.listenTo(this.currentFolderEmails, "reset", this.renderEmails), this.listenTo(this.currentFolderEmails, "all", this.renderFolderActions), this.listenTo(this.currentFolderEmails, "destroy", this.renderEmails), this.listenTo(this.folders, "change", this.resetEmails)
                },
                render: function () {
                    return $("#widget-email-header").html($("#email-list-view-header-template").html()), $("#folder-stats").removeClass("hide"), $("#back-btn").addClass("hide"), $("#select-all").on("click", $.proxy(this.selectAll, this)), $("#select-none").on("click", $.proxy(this.selectNone, this)), $("#select-read").on("click", $.proxy(this.selectRead, this)), $("#select-unread").on("click", $.proxy(this.selectUnread, this)), $("#mark-as-read").on("click", $.proxy(this.markSelectedAsRead, this)), $("#mark-as-unread").on("click", $.proxy(this.markSelectedAsUnread, this)), $("#delete").on("click", $.proxy(this.deleteEmails, this)), this.resetEmails(), this.delegateEvents(this.events), this
                },
                renderFolderActions: function () {
                    var a = this.currentFolderEmails.where({
                        selected: !0
                    }).length,
                        b = a == this.currentFolderEmails.length;
                    this.$toggleAllCheckbox = this.$("#toggle-all"), this.$toggleAllCheckbox.prop("checked", b)
                },
                addOne: function (a) {
                    var b = new k({
                        model: a
                    });
                    this.$el.find("tbody").append(b.render().el)
                },
                renderEmails: function () {
                    this.reset(), this.currentFolderEmails.length ? this.currentFolderEmails.each(this.addOne, this) : this.$el.find("tbody").append('<tr><td colspan="100">Nothing here yet</td></tr>');
                    var a = this.folders.where({
                        current: !0
                    })[0],
                        b = (this.currentFolderEmails.where({
                            read: !1
                        }).length, "Inbox");
                    a && (b = a.get("name"))
                },
                reset: function () {
                    this.$el.html(this.template())
                },
                resetEmails: function () {
                    var b = this.folders.where({
                        current: !0
                    })[0],
                        c = 1;
                    b && (c = b.get("id")), c == a ? this.currentFolderEmails.reset(j.where({
                        starred: !0
                    })) : this.currentFolderEmails.reset(j.where({
                        folderId: c
                    }))
                },
                toggleAll: function () {
                    var a = this.$toggleAllCheckbox.prop("checked");
                    this.currentFolderEmails.each(function (b) {
                        b.save({
                            selected: a
                        })
                    })
                },
                selectAll: function () {
                    this.$toggleAllCheckbox.prop("checked", !0), this.toggleAll()
                },
                selectNone: function () {
                    this.$toggleAllCheckbox.prop("checked", !1), this.toggleAll()
                },
                selectRead: function () {
                    this.selectNone(), _(this.currentFolderEmails.where({
                        read: !0
                    })).each(function (a) {
                        a.save({
                            selected: !0
                        })
                    })
                },
                selectUnread: function () {
                    this.selectNone(), _(this.currentFolderEmails.where({
                        read: !1
                    })).each(function (a) {
                        a.save({
                            selected: !0
                        })
                    })
                },
                search: function () {
                    var a = this.folders.where({
                        current: !0
                    })[0],
                        b = 1;
                    a && (b = a.get("id")), this.currentFolderEmails.reset(j.search($("#mailbox-search").val(), b))
                },
                markSelectedAsRead: function () {
                    _(this.currentFolderEmails.where({
                        selected: !0
                    })).each(function (a) {
                        a.save({
                            read: !0
                        })
                    })
                },
                markSelectedAsUnread: function () {
                    _(this.currentFolderEmails.where({
                        selected: !0
                    })).each(function (a) {
                        a.save({
                            read: !1
                        })
                    })
                },
                deleteEmails: function () {
                    _(this.currentFolderEmails.where({
                        selected: !0
                    })).each(function (a) {
                        a.destroy()
                    })
                }
            }),
            o = new n,
            p = Backbone.View.extend({
                el: $(".content"),
                $content: $("#mailbox-content"),
                events: {
                    "keyup #mailbox-search": "search",
                    "click #compose-btn": "handleComposeBtnClick",
                    "click #back-btn": "handleBackBtnClick"
                },
                initialize: function () {
                    this.currentView = o, this.folders = g, this.listenTo(this.folders, "reset", this.renderFolders);
                    var a = this;
                    this.folders.fetch({
                        success: function () {
                            j.fetch({
                                success: function () {
                                    a.render()
                                },
                                reset: !0
                            })
                        },
                        reset: !0
                    })
                },
                render: function () {
                    this.$content.html(this.currentView.render().el)
                },
                setCurrentView: function (a) {
                    this.currentView !== o && this.currentView.remove(), this.currentView = a, this.render()
                },
                renderFolders: function () {
                    this.resetFoldersList(), this.folders.each(this.addFolder, this)
                },
                resetFoldersList: function () {
                    this.$("#folders-list").html("")
                },
                addFolder: function (a) {
                    var b = new h({
                        model: a
                    });
                    this.$("#folders-list").append(b.render().el)
                },
                search: function () {
                    "function" == typeof this.currentView.search && this.currentView.search()
                },
                showEmailsView: function () {
                    this.currentView != o && this.setCurrentView(o)
                },
                handleComposeBtnClick: function () {
                    return this.showComposeView(), !1
                },
                handleBackBtnClick: function () {
                    return this.showEmailsView(), !1
                },
                showComposeView: function (a) {
                    a = a ? a : new b({
                        body: ""
                    }), this.setCurrentView(new m({
                        model: a
                    }))
                }
            }),
            q = new p
    }

    function b() {
        setTimeout(function () {
            $("#app-alert").removeClass("hide").one("webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend", function () {
                $(this).removeClass("animated bounceInLeft")
            })
        }, 3e3)
    }

    function c() {
        $("#wysiwyg").wysihtml5({
            html: !0,
            customTemplates: d,
            stylesheets: ["data:text/css,body{ background-color: transparent !important; }"],
            toolbar: {
                size: "sm btn-transparent"
            }
        }), a(), b()
    }
    var d = {
        emphasis: function (a) {
            var b = (a.locale, a.options),
                c = b.toolbar && b.toolbar.size ? " btn-" + b.toolbar.size : "";
            return "<li><div class='btn-group'><a class='btn btn-transparent btn-" + c + "' data-wysihtml5-command='bold' title='CTRL+B' tabindex='-1'><i class='glyphicon glyphicon-bold'></i></a><a class='btn btn-transparent btn-" + c + "' data-wysihtml5-command='italic' title='CTRL+I' tabindex='-1'><i class='glyphicon glyphicon-italic'></i></a></div></li>"
        },
        link: function (a) {
            var b = (a.locale, a.options);
            b.toolbar && b.toolbar.size ? " btn-" + b.toolbar.size : "";
            return '<li><a class="btn btn-sm btn-transparent" data-wysihtml5-command="createLink" title="Insert link" tabindex="-1" href="javascript:;" unselectable="on">            <span class="glyphicon glyphicon-share"></span>            </a>            <div class="bootstrap-wysihtml5-insert-link-modal modal fade" data-wysihtml5-dialog="createLink">            <div class="modal-dialog ">                <div class="modal-content">                    <div class="modal-header">                        <a class="close" data-dismiss="modal">×</a>                        <h3>Insert link</h3>                    </div>                    <div class="modal-body">                        <div class="form-group no-margin">                            <input value="http://" class="bootstrap-wysihtml5-insert-link-url form-control bg-gray-lighter" data-wysihtml5-dialog-field="href" data-parsley-id="7677"><ul class="parsley-errors-list" id="parsley-id-7677"></ul>                            </div>                            <br>                            <div class="checkbox mt-sm checkbox-dark">                                <input type="checkbox" id="in-a-new-window" class="bootstrap-wysihtml5-insert-link-target" checked="">                                <label for="in-a-new-window">                                Open link in new window                                    </label>                                </div>                            </div>                            <div class="modal-footer">                                <a class="btn btn-default" data-dismiss="modal" data-wysihtml5-dialog-action="cancel" href="#">Cancel</a>                                <a href="#" class="btn btn-primary" data-dismiss="modal" data-wysihtml5-dialog-action="save">Insert link</a>                            </div>                        </div>                    </div>                </div></li>'
        },
        image: function (a) {
            return '<li><div class="bootstrap-wysihtml5-insert-image-modal modal fade" data-wysihtml5-dialog="insertImage" aria-hidden="true" style="display: none;">            <div class="modal-dialog ">                <div class="modal-content">                    <div class="modal-header">                        <a class="close" data-dismiss="modal">×</a>                        <h3>Insert image</h3>                    </div>                    <div class="modal-body">                        <div class="form-group no-margin">                            <input value="http://" class="bootstrap-wysihtml5-insert-image-url form-control bg-gray-lighter" data-parsley-id="7359"><ul class="parsley-errors-list" id="parsley-id-7359"></ul>                            </div>                        </div>                        <div class="modal-footer">                            <a class="btn btn-default" data-dismiss="modal" data-wysihtml5-dialog-action="cancel" href="#">Cancel</a>                            <a class="btn btn-primary" data-dismiss="modal" data-wysihtml5-dialog-action="save" href="#">Insert image</a>                        </div>                    </div>                </div>                </div>                <a class="btn btn-sm btn-transparent" data-wysihtml5-command="insertImage" title="Insert image" tabindex="-1" href="javascript:;" unselectable="on"><span class="glyphicon glyphicon-picture"></span></a>                </li>'
        },
        html: function (a) {
            var b = a.locale,
                c = a.options,
                d = c.toolbar && c.toolbar.size ? " btn-" + c.toolbar.size : "";
            return "<li><div class='btn-group'><a class='btn btn-transparent btn-" + d + "' data-wysihtml5-action='change_view' title='" + b.html.edit + "' tabindex='-1'><i class='fa fa-pencil'></i></a></div></li>"
        }
    },
        e = ["<p>Why painful the sixteen how minuter looking nor. Subject but why ten earnest husband imagine sixteen brandon. Are unpleasing occasional celebrated motionless unaffected conviction out. Evil make to no five they. Stuff at avoid of sense small fully it whose an. Ten scarcely distance moreover handsome age although. As when have find fine or said no mile. He in dispatched in imprudence dissimilar be possession unreserved insensible. She evil face fine calm have now. Separate screened he outweigh of distance landlord.</p>", "somm text bodt. Reall small. ust few lines", "<p>Lose john poor same it case do year we. Full how way even the sigh. Extremely nor furniture fat questions now provision incommode preserved. Our side fail find like now. Discovered travelling for insensible partiality unpleasing impossible she. Sudden up my excuse to suffer ladies though or. Bachelor possible marianne directly confined relation as on he.</p>", "empty"];
    c(), PjaxApp.onPageLoad(c)
});