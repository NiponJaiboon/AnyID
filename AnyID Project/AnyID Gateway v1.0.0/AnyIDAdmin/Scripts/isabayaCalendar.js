function isabayaCalendar(name, offsetYear, urlPic) {
    this.Name = name;
    this.Date = new Date();
    this.SelDateValue = null;
    this.OffsetYear = offsetYear;
    this.DayText = ["SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT"];
    this.MonthText = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    this.UrlPic = (urlPic == null ? "" : urlPic);
    this.ControlWidth = 170;
    this.ControlHeight = 25;
    this.ClearButtonText = "Clear";
    this.TodayButtonText = "Today";

    this.GetDate = function () { return this.SelDateValue; };
    this.SetDate = function (date) { this.SelDateValue = date; };
    this.ChangeMonth = function (pn, m, y) {
        m = m + pn;
        if (m > 11) { m = 0; y = y + 1; }
        else if (m < 0) { m = 11; y = y - 1; }
        ChageCalendar(this, m, y);
    };
    this.SelectedDate = function (s, d, m, y) {
        var dateSel = document.getElementById("calendarT-" + this.Name)
        dateSel.value = d.toString() + " / " + (m + 1).toString() + " / " + (y + this.OffsetYear).toString();
        this.SetDate(new Date(y, m, d));

        var calendarTbody = document.getElementById("calendarBox-" + this.Name).children[0].children[0];
        for (var i = 1; i < calendarTbody.children.length - 1; i++) {
            var setActive = calendarTbody.children[i];
            if (setActive != null) {
                for (var j = 0; j < 7; j++) {
                    if (setActive.children[j].getAttribute("class") != null || setActive.children[j].getAttribute("class") != "" || setActive.children[j].getAttribute("class") != "invalDate")
                        setActive.children[j].setAttribute("class", "avalDate");
                }
            }
        }
        s.setAttribute("class", "activeDate");
        this.DropdownClick();
    }
    this.DropdownClick = function () {
        var calender = document.getElementById('calendarBox-' + this.Name);
        if (calender.style.display == "none") { calender.style.display = "table-cell"; }
        else { calender.style.display = "none"; }
    };
    this.ClearButtonClick = function () {
        var dateSel = document.getElementById("calendarT-" + this.Name)
        dateSel.value = "";
        this.SetDate(null);

        var calendarTbody = document.getElementById("calendarBox-" + this.Name).children[0].children[0];
        for (var i = 1; i < calendarTbody.children.length - 1; i++) {
            var setActive = calendarTbody.children[i];
            if (setActive != null) {
                for (var j = 0; j < 7; j++) {
                    if (setActive.children[j].getAttribute("class") != null || setActive.children[j].getAttribute("class") != "" || setActive.children[j].getAttribute("class") != "invalDate")
                        setActive.children[j].setAttribute("class", "avalDate");
                }
            }
        }

        this.DropdownClick();
    }
    this.TodayButtonClick = function () {
        var dateSel = document.getElementById("calendarT-" + this.Name)
        this.SetDate(new Date());
        dateSel.value = this.SelDateValue.getDate().toString() + " / " + (this.SelDateValue.getMonth() + 1).toString() + " / " + (this.SelDateValue.getFullYear() + this.OffsetYear).toString();
        ChageCalendar(this, this.SelDateValue.getMonth(), this.SelDateValue.getFullYear());
        this.DropdownClick();
    }
    this.Init = function () {
        {
            var cIn = document.getElementById("calendarText-" + this.Name);
            cIn.setAttribute("class", "isbaycalendartextbox");
            cIn.setAttribute("style", "width:" + this.ControlWidth.toString() + ";");
            var cIn_tr = SetAttributes("tr", ["onclick", this.Name + ".DropdownClick();"]);
            var cIn_tr_td1 = SetAttributes("td", ["style", "height:" + this.ControlHeight + ";"]);
            var cIn_tr_td1_input = SetAttributes("input", ["id", "calendarT-" + this.Name, "type", "text", "style", "border:0px; width:100%; height:100%; padding:5px;", "readonly", "true"]);
            var cIn_tr_td2 = SetAttributes("td", ["style", "width:16px; height:" + this.ControlHeight + ";"]);
            var cIn_tr_td2_img = SetAttributes("img", new Array("alt", "", "src", this.UrlPic + "calendar.png"));

            cIn.removeChild(cIn.children[0]);
            cIn_tr_td1.appendChild(cIn_tr_td1_input);
            cIn_tr_td2.appendChild(cIn_tr_td2_img);
            cIn_tr.appendChild(cIn_tr_td1);
            cIn_tr.appendChild(cIn_tr_td2);
            cIn.appendChild(cIn_tr);

            var cBox = document.getElementById("calendarBox-" + this.Name);
            var cBox_table = SetAttributes("table", ["class", "isbaycalendar"]);
            var cBox_tbody = SetAttributes("tbody");
            var cBox_tr = SetAttributes("tr");
            var cBox_td = SetAttributes("td", ["class", "navigatebar", "colspan", "7"]);
            var cBox_td_t = SetAttributes("table", ["style", "width:100%;"]);
            var cBox_td_t_tr = SetAttributes("tr", ["id", "calendarN-" + this.Name]);

            cBox_td_t.appendChild(cBox_td_t_tr);
            cBox_td.appendChild(cBox_td_t);
            cBox_tr.appendChild(cBox_td);
            cBox_tbody.appendChild(cBox_tr);
            cBox_table.appendChild(cBox_tbody);
            cBox.appendChild(cBox_table);
        }
        ChageCalendar(this, this.Date.getMonth(), this.Date.getFullYear());
    };

    function SetAttributes(ele, attrValuePaires) {
        var s = document.createElement(ele);
        if (attrValuePaires != null)
            for (var i = 0; i < attrValuePaires.length ; i = i + 2) {
                s.setAttribute(attrValuePaires[i], attrValuePaires[i + 1]);
            }
        return s;
    };
    function ChageCalendar(s, m, y) {
        {
            var navM = document.getElementById("calendarN-" + s.Name);
            var prev = SetAttributes("td", new Array("class", "arrow", "onclick", s.Name + ".ChangeMonth(-1, " + m + ", " + y + ");"));
            var imgL = SetAttributes("img", new Array("alt", "", "src", s.UrlPic + "arrow-left.png"));
            prev.appendChild(imgL);
            var next = SetAttributes("td", new Array("class", "arrow", "onclick", s.Name + ".ChangeMonth(1, " + m + ", " + y + ");"));
            var imgR = SetAttributes("img", new Array("alt", "", "src", s.UrlPic + "arrow-right.png"));
            next.appendChild(imgR);
            var lm = SetAttributes("td");
            lm.innerHTML = s.MonthText[m] + ", " + (y + s.OffsetYear).toString();

            while (navM.children.length > 0) { navM.removeChild(navM.children[0]); }
            navM.appendChild(prev);
            navM.appendChild(lm);
            navM.appendChild(next);
        }
        {
            var calendarTbody = document.getElementById("calendarBox-" + s.Name).children[0].children[0];
            while (calendarTbody.children.length > 1) { calendarTbody.removeChild(calendarTbody.children[1]); }

            var trLD = SetAttributes("tr", ["class", "cell"])
            for (var i = 0; i < 7; i++) {
                var tdLD = SetAttributes("td", ["class", "header"]);
                tdLD.innerHTML = s.DayText[i];
                trLD.appendChild(tdLD);
            }
            calendarTbody.appendChild(trLD);

            var startDOM = new Date(y, m, 1);
            var lastDOM = new Date(y, (m + 1), 0);
            while (startDOM <= lastDOM) {
                var tr = SetAttributes("tr", ["class", "cell"]);
                for (var i = 0; i < 7; i++) {
                    if (startDOM.getDay() == i && startDOM.getMonth() === lastDOM.getMonth()) {
                        var td;
                        if (s.SelDateValue != null && s.SelDateValue.getDate() == startDOM.getDate() && s.SelDateValue.getMonth() == startDOM.getMonth() && s.SelDateValue.getFullYear() == startDOM.getFullYear()) {
                            td = SetAttributes("td", ["class", "activeDate", "onclick", s.Name + ".SelectedDate(this, " + startDOM.getDate() + ", " + startDOM.getMonth() + ", " + startDOM.getFullYear() + ")"]);
                        }
                        else {
                            td = SetAttributes("td", ["class", "avalDate", "onclick", s.Name + ".SelectedDate(this, " + startDOM.getDate() + ", " + startDOM.getMonth() + ", " + startDOM.getFullYear() + ")"]);
                        }

                        td.innerHTML = startDOM.getDate();
                        tr.appendChild(td);
                        startDOM = new Date(startDOM.getFullYear(), startDOM.getMonth(), startDOM.getDate() + 1);
                    }
                    else {
                        tr.appendChild(SetAttributes("td", ["class", "invalDate"]));
                    }
                }
                calendarTbody.appendChild(tr);
            }

            var tr_td_input_c_footer = SetAttributes("input", ["type", "button", "class", "isbaycalendarFooterButton", "style", "width:80px; height:30px;", "value", s.ClearButtonText, "onclick", s.Name + ".ClearButtonClick()"]);
            var tr_td_input_t_footer = SetAttributes("input", ["type", "button", "class", "isbaycalendarFooterButton", "style", "width:80px; height:30px;", "value", s.TodayButtonText, "onclick", s.Name + ".TodayButtonClick()"]);
            var tr_td_footer = SetAttributes("td", ["colspan", "7"]);
            var tr_footer = SetAttributes("tr", ["class", "cell", "style", "background-color:rgb(230,230,230);"]);
            tr_td_footer.appendChild(tr_td_input_t_footer);
            tr_td_footer.appendChild(document.createTextNode(" "));
            tr_td_footer.appendChild(tr_td_input_c_footer);
            tr_footer.appendChild(tr_td_footer);
            calendarTbody.appendChild(tr_footer);
        }
    }
};