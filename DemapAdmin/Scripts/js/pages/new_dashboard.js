"use strict";
$(document).ready(function() {

    // =====================main chart js============================
    // tabs 1
    //start area chart
    var da1 = [["Jan", 0],["Feb", 0],["Mar", 0],["Apr", 0],["May", 0],["Jun", 0],["Jul", 0],["Aug", 0],["Sep", 0],["Oct", 0],["Nov", 0],["Dec", 1]];
    var da2 = [["Jan", 0],["Feb", 0],["Mar", 0],["Apr", 0],["May", 0],["Jun", 0],["Jul", 0],["Aug", 0],["Sep", 0],["Oct", 0],["Nov", 0],["Dec", 0]];
    $.plot("#area-chart", [{
        data: da1,
        label: "Denuncias de Alimentos",
        color: "#69d3be"
    },{
        data: da2,
        label: "Denuncias de Medicamentos",
        color: "#4FB7FE"
    }], {
        series: {
            lines: {
                show: !0,
                fill: .8,
                fillColor: { colors: [{ opacity: 0.0 }, { opacity: 0.6}] }
            },
            points: {
                show: !0,
                radius: 3
            }
        },
        grid: {
            borderColor: "#fff",
            borderWidth: 1,
            hoverable: !0
        },
        tooltip: true,
        tooltipOpts: {
            content: "%y",
            defaultTheme: true
        },
        xaxis: {
            tickColor: "#eff",
            mode: "categories"
        },
        yaxis: {
            tickColor: "#eff"
        },
        shadowSize: 0
    });



    // tab-2
    var realtoggle = new Switchery(document.querySelector('#toggle_real'), { size: 'small', color: '#00c0ef', jackColor: '#fff' });
    var data_1 = [],
        totalPoints_1 = 70;

    function getRandomData_1() {
        if (data_1.length > 0)
            data_1 = data_1.slice(1);
        // do a random walk
        while (data_1.length < totalPoints_1) {
            var prev_1 = data_1.length > 0 ? data_1[data_1.length - 1] : 50;
            var y = prev_1 + Math.random() * 10 - 5;
            if (y < 25)
                y = 30;
            if (y > 100)
                y = 90;
            data_1.push(y);
        }
        var res_1 = [];
        for (var i = 0; i < data_1.length; ++i)
            res_1.push([i, data_1[i]])
        return res_1;
    }

    // setup control widget
    var updateInterval_1 = 300;

    // setup plot
    var options_1 = {
        colors: ["linear-gradient(70deg, #4FB7FE 0)"],

        series: {
            shadowSize: 0,
            lines: {
                show: true,
                fill: true,
                fillColor: {
                    colors: [{
                        opacity: 0.3
                    }, {
                        opacity: 1
                    }]
                }
            }
        },
        yaxis: {
            min: 0,
            max: 120
            // tickLength:0
        },
        xaxis: {
            show: false
            // tickLength:0
        },
        grid: {
            backgroundColor: '#fff',
            borderWidth: 1,
            borderColor: '#fff'
        }
    };

    var plot_1 = $.plot($("#realtime"), [getRandomData_1()], options_1);

    function update_1() {
        plot_1.setData([getRandomData_1()]);
        // since the axes don't change, we don't need to call plot.setupGrid()
        plot_1.draw();
        if ($("#toggle_real").prop("checked")) {
            setTimeout(update_1, updateInterval_1);
        }
    }

    update_1();

    $("#toggle_real").on("change",function() {
        update_1();
    });
    // tab2 end
// -=========================end main chat js========================
    // ========================to do list==============

    $('body').on('click', '.border_color', function() {
        $('#btn_color').removeClass('btn-secondary btn-danger btn-primary btn-info btn-mint').addClass($(this).data('color'));
        $('#btn_color').data('badge', $(this).data('badge'));
        $('#btn_color').css("color", "#fff");
        return false;
    });
    $('[data-toggle="popover"]').popover({
        html: true,
        placement: 'right',
        content: function() {
            return $($(this).data('contentwrapper')).html();
        }
    });
    $(".border_danger").on('click',function() {
        $(".todo_mintbadge").addClass('border_danger')
    });
    $("form#main_input_box").submit(function(event) {
        event.preventDefault();
        var deleteButton = " <a href='' class='tododelete redcolor'><span class='fa fa-trash'></span></a>";
        var striks = " <span class='dividor'>|</span> ";
        var editButton = " <a href='#' class='todoedit'><span class='fa fa-pencil'></span></a>";
        var checkBox = "<p><input type='checkbox' class='striked form-control' autocomplete='off' /></p>";
        var twoButtons = "<div class='col-lg-3 col-sm-4 col-xs-3 showbtns todoitembtns'>" + editButton + striks + deleteButton + "</div>";
        var badgeClass = $('#btn_color').data('badge');
        $(".list_of_items").prepend("<div class='todolist_list showactions'>  " + "<div class='col-lg-8 col-sm-8 col-xs-8 nopad custom_textbox1'> <div class='todo_mintbadge " + badgeClass + "'> </div> <div class='todoitemcheck'>" + checkBox + "</div>" + "<div class='todotext todoitem'>" + $("#custom_textbox").val() + "</div> </div>" +   twoButtons + "<span class='seperator'></span>");
        $("#custom_textbox").val('');
        $('#btn_color').css("color", "#fff");
        return false;
    });
    $(".todo_section").on('click','.tododelete', function(e) {
        e.preventDefault();
        $(this).closest('.todolist_list').remove();
    });
    $(".todo_section").on('click','.striked', function(e) {
        $(this).closest('.todolist_list').find('.todotext').toggleClass('strikethrough');
        $(this).closest('.todolist_list').find('.showbtns').toggle();
    });
    $(".todo_section").on('click',".todoedit", function(e) {
        var editButton = " <a href='#' class='todoedit'><span class='fa fa-pencil'></span></a>";
        e.preventDefault();
        $(this).closest('.todolist_list').find('.striked').toggle();
        if ($(this).text() == " ") {
            $(this).closest('.todolist_list').find(".showbtns").toggleClass("opacityfull");
            var text1 = $(this).closest('.todolist_list').find("input[type='text'][name='text']").val().trim();
            if (text1 === '') {
                alert('Come on! you can\'t create a todo without title');
                $(this).closest('.todolist_list').find("input[type='text'][name='text']").focus();
                $(this).closest('.todolist_list').find(".striked").hide();
                return;
            }
            $(this).closest('.todolist_list').find('.todotext').html(text1);
            $(this).html("<span class='fa fa-pencil'></span>");
            $(this).closest('.todolist_list').find(".showbtns").toggleClass("opacityfull");
            return;
        }
        var text = '';
        text = $(this).closest('.todolist_list').find('.todotext').text();
        text = "<input type='text' name='text' value='" + text + "' onkeypress='return event.keyCode != 13;' />";
        $(this).closest('.todolist_list').find('.todotext').html(text);
        $(this).html("<span class='fa fa-check'></span> ");
        text = '';
        return;
    });
    $("#custom_textbox").on("keypress", function(e) {
        if (e.which === 32 && !this.value.length)
            e.preventDefault();
    });
    // ======================to do list end=============================
    // =================top 4 sections countup js==================
    var options = {
        useEasing: true,
        useGrouping: true,
        separator: ',',
        decimal: '.',
        prefix: '',
        suffix: ''
    };
    new CountUp("sales_count", 0, 750, 0, 2.5, options).start();
    new CountUp("visitors_count", 0, 1700, 0, 2.5, options).start();
    new CountUp("revenue_count", 0, 1200, 0, 2.5, options).start();
    new CountUp("subscribers_count", 0, 1020, 0, 2.5, options).start();
    // =========================News ticker===========================================
    var nt_example1 = $('#nt-example1').newsTicker({
        direction: 'down',
        row_height: 85,
        max_rows: 3,
        duration: 2000
    });

    $('.todo_section').slimscroll({
        height: '213px',
        size: '5px',
        opacity: 0.2
    });
    // slimscroll for notes section
    $('.content').slimscroll({
        height: '300px',
        size: '5px',
        opacity: 0.2
    });

    //server load
    var flot2 = function() {
        // We use an inline data source in the example, usually data would
        // be fetched from a server
        var data = [],
            totalPoints = 100;

        function getRandomData() {
            if (data.length > 0)
                data = data.slice(1);
            // Do a random walk
            while (data.length < totalPoints) {
                var prev = data.length > 0 ? data[data.length - 1] : 50,
                    y = prev + Math.random() * 10 - 5;
                if (y < 0) {
                    y = 0;
                } else if (y > 100) {
                    y = 100;
                }
                data.push(y);
            }
            // Zip the generated y values with the x values
            var res = [];
            for (var i = 0; i < data.length; ++i) {
                res.push([i, data[i]])
            }
            return res;
        }
        var plot2 = $.plot("#flotchart2", [getRandomData()], {
            series: {
                shadowSize: 0 // Drawing is faster without shadows
            },
            yaxis: {
                min: 0,
                max: 100
            },
            xaxis: {
                show: false
            },
            colors: ["#22BAA0"],
            legend: {
                show: false
            },
            grid: {
                color: "#AFAFAF",
                hoverable: true,
                borderWidth: 0,
                backgroundColor: '#FFF'},
            tooltip: true,
            tooltipOpts: {
                content: "Y: %y",
                defaultTheme: false
            }
        });

        function update() {
            plot2.setData([getRandomData()]);
            plot2.draw();
            setTimeout(update, 30);
        }
        update();
    };
    flot2();
    //donut
    var datax = [{
        label: "Profile",
        data: 150,
        color: '#00c0ef'
    }, {
        label: "Facebook ",
        data: 130,
        color: '#668cff'
    }, {
        label: "Twitter ",
        data: 190,
        color: '#0fb0c0'
    }, {
        label: "Google+",
        data: 180,
        color: '#ff8080'
    }, {
        label: "Linkedin",
        data: 120,
        color: '#ffb300'
    }];
    $.plot($("#donut"), datax, {
        series: {
            pie: {
                innerRadius: 0.5,
                show: true
            }
        },
        legend: {
            show: false
        },
        grid: {
            hoverable: true
        },
        tooltip: true,
        tooltipOpts: {
            content: "%p.0%, %s"
        }
    });
    var progressBarContainer = $('#progress-bar');
    var progressBar = {
        chain: [],
        progress: progressBarContainer.children('progress'),
        progressBar: progressBarContainer.find('.progress-bar'),
        progressInfo: progressBarContainer.children('.progress-info'),
        set: function(value, info, noPush) {
            if (!noPush) {
                this.chain.push(value);
            }
            if (this.chain[0] == value) {
                this.go(value, info);
            } else {
                var self = this;
                setTimeout(function() {
                    self.set(value, info, true)
                }, 500);
            }
        },
        go: function(value, info) {
            this.progressInfo.text(info);
            var self = this;
            var interval = setInterval(function() {
                var curr = self.progress.attr('value');
                if (curr >= value) {
                    clearInterval(interval);
                    self.progress.attr('value', value);
                    self.progressBar.css('width', value + '%');
                    self.chain.shift()
                } else {
                    self.progress.attr('value', ++curr);
                    self.progressBar.css('width', curr + '%');
                }
            }, 10)
        }
    };
    progressBar.set(5);
    progressBar.set(12);
    progressBar.set(22);
    progressBar.set(32);
    progressBar.set(52);
    var progressBarContainer12 = $('#progress-bar1');
    var progressBar = {
        chain: [],
        progress: progressBarContainer12.children('progress'),
        progressBar: progressBarContainer12.find('.progress-bar'),
        progressInfo: progressBarContainer12.children('.progress-primary'),
        set: function(value, info, noPush) {
            if (!noPush) {
                this.chain.push(value);
            }
            if (this.chain[0] == value) {
                this.go(value, info);
            } else {
                var self = this;
                setTimeout(function() {
                    self.set(value, info, true)
                }, 500);
            }
        },
        go: function(value, info) {
            this.progressInfo.text(info);
            var self = this;
            var interval = setInterval(function() {
                var curr = self.progress.attr('value');
                if (curr >= value) {
                    clearInterval(interval);
                    self.progress.attr('value', value);
                    self.progressBar.css('width', value + '%');
                    self.chain.shift()
                } else {
                    self.progress.attr('value', ++curr);
                    self.progressBar.css('width', curr + '%');
                }
            }, 10)
        }
    };
    progressBar.set(5);
    progressBar.set(10);
    progressBar.set(40);
    progressBar.set(60);
    progressBar.set(80);
    var progressBarContainer2 = $('#progress-bar2');
    var progressBar = {
        chain: [],
        progress: progressBarContainer2.children('progress'),
        progressBar: progressBarContainer2.find('.progress-bar'),
        progressInfo: progressBarContainer2.children('.progress-primary'),
        set: function(value, info, noPush) {
            if (!noPush) {
                this.chain.push(value);
            }
            if (this.chain[0] == value) {
                this.go(value, info);
            } else {
                var self = this;
                setTimeout(function() {
                    self.set(value, info, true)
                }, 500);
            }
        },
        go: function(value, info) {
            this.progressInfo.text(info);
            var self = this;
            var interval = setInterval(function() {
                var curr = self.progress.attr('value');
                if (curr >= value) {
                    clearInterval(interval);
                    self.progress.attr('value', value);
                    self.progressBar.css('width', value + '%');
                    self.chain.shift()
                } else {
                    self.progress.attr('value', ++curr);
                    self.progressBar.css('width', curr + '%');
                }
            }, 10)
        }
    };
    progressBar.set(5);
    progressBar.set(12);
    progressBar.set(22);
    progressBar.set(52);
    progressBar.set(73);
    var progressBarContainer1 = $('#progress-bar3');
    var progressBar = {
        chain: [],
        progress: progressBarContainer1.children('progress'),
        progressBar: progressBarContainer1.find('.progress-bar'),
        progressInfo: progressBarContainer1.children('.progress-info'),
        set: function(value, info, noPush) {
            if (!noPush) {
                this.chain.push(value);
            }
            if (this.chain[0] == value) {
                this.go(value, info);
            } else {
                var self = this;
                setTimeout(function() {
                    self.set(value, info, true)
                }, 500);
            }
        },
        go: function(value, info) {
            this.progressInfo.text(info);
            var self = this;
            var interval = setInterval(function() {
                var curr = self.progress.attr('value');
                if (curr >= value) {
                    clearInterval(interval);
                    self.progress.attr('value', value);
                    self.progressBar.css('width', value + '%');
                    self.chain.shift()
                } else {
                    self.progress.attr('value', ++curr);
                    self.progressBar.css('width', curr + '%');
                }
            }, 10)
        }
    };
    progressBar.set(5);
    progressBar.set(10);
    progressBar.set(22);
    progressBar.set(37);
    progressBar.set(50);
    var progressBarContainer = $('#progress-bar4');
    var progressBar = {
        chain: [],
        progress: progressBarContainer.children('progress'),
        progressBar: progressBarContainer.find('.progress-bar'),
        progressInfo: progressBarContainer.children('.progress-info'),
        set: function(value, info, noPush) {
            if (!noPush) {
                this.chain.push(value);
            }
            if (this.chain[0] == value) {
                this.go(value, info);
            } else {
                var self = this;
                setTimeout(function() {
                    self.set(value, info, true)
                }, 500);
            }
        },
        go: function(value, info) {
            this.progressInfo.text(info);
            var self = this;
            var interval = setInterval(function() {
                var curr = self.progress.attr('value');
                if (curr >= value) {
                    clearInterval(interval);
                    self.progress.attr('value', value);
                    self.progressBar.css('width', value + '%');
                    self.chain.shift()
                } else {
                    self.progress.attr('value', ++curr);
                    self.progressBar.css('width', curr + '%');
                }
            }, 10)
        }
    };
    progressBar.set(5);
    progressBar.set(12);
    progressBar.set(22);
    progressBar.set(37);
    progressBar.set(40);
    var progressBarContainer = $('#progress-bar5');
    var progressBar = {
        chain: [],
        progress: progressBarContainer.children('progress'),
        progressBar: progressBarContainer.find('.progress-bar'),
        progressInfo: progressBarContainer.children('.progress-info'),
        set: function(value, info, noPush) {
            if (!noPush) {
                this.chain.push(value);
            }
            if (this.chain[0] == value) {
                this.go(value, info);
            } else {
                var self = this;
                setTimeout(function() {
                    self.set(value, info, true)
                }, 500);
            }
        },
        go: function(value, info) {
            this.progressInfo.text(info);
            var self = this;
            var interval = setInterval(function() {
                var curr = self.progress.attr('value');
                if (curr >= value) {
                    clearInterval(interval);
                    self.progress.attr('value', value);
                    self.progressBar.css('width', value + '%');
                    self.chain.shift()
                } else {
                    self.progress.attr('value', ++curr);
                    self.progressBar.css('width', curr + '%');
                }
            }, 10)
        }
    };
    progressBar.set(5);
    progressBar.set(12);
    progressBar.set(42);
    progressBar.set(72);
    progressBar.set(93);

});

