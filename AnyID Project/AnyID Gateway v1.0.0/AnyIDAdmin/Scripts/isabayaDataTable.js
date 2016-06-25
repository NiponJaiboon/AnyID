function isabayaDataTable(name, imgURL) {
    this.Name = name;
    this.ImgURL = (I = imgURL == null ? "" : imgURL);
    this.EmptyTableText = "No data available in table";
    this.InfoText = "Showing _START_ to _END_ of _TOTAL_ entries";
    this.InfoEmptyText = "Showing 0 to 0 of 0 entries";
    this.ZeroRecordsText = "No matching records found";

    this.Initial = function (language) {
        if (language) { this.SetLanguage(language.EmptyTableText, language.InfoText, language.InfoEmptyText, language.ZeroRecordsText); }
        $('#' + this.Name).DataTable({
            "language": {
                "emptyTable": this.EmptyTableText,
                "info": this.InfoText,
                "infoEmpty": this.InfoEmptyText,
                "zeroRecords": this.ZeroRecordsText,
            },
            "scrollX": true
        });

        var sWarpper = document.getElementById(this.Name + "_wrapper");
        var sfooter = document.getElementById(this.Name + "_footer");
        var sfooter1 = document.getElementById(this.Name + "_footer_col1");

        sWarpper.removeChild(sWarpper.children[0]);
        sWarpper.removeChild(sWarpper.children[0]);
        sWarpper.removeChild(sWarpper.children[2]);
        sWarpper.children[1].className = "";
        sfooter1.appendChild(sWarpper.children[1]);
        sWarpper.appendChild(sfooter);
    }
    this.Destroy = function () {
        var sfooterT = document.getElementById(this.Name + "_footerT");
        var sfooter = document.getElementById(this.Name + "_footer");
        var sfooter1 = document.getElementById(this.Name + "_footer_col1");

        sfooterT.appendChild(sfooter);
        sfooter1.removeChild(sfooter1.children[0]);
        $("#" + this.Name).dataTable().fnDestroy();
    }
    this.SetLanguage = function (emptyTableText, infoText, infoEmptyText, zeroRecordsText) {
        if (emptyTableText) { this.EmptyTableText = emptyTableText };
        if (infoText) { this.InfoText = infoText };
        if (infoEmptyText) { this.InfoEmptyText = infoEmptyText };
        if (zeroRecordsText) { this.ZeroRecordsText = zeroRecordsText };
    }
    this.UpdateDataGrid = function (data) {
        this.Destroy();
        document.getElementById(this.Name + "_data").innerHTML = data;
        this.Initial();
        this.ChangePageLength(this.GetCurrentPageLength());
    }
    this.GetRecordCount = function () {
        return $('#' + this.Name).DataTable().rows().count();
    }
    this.ChangePageLength =  function (length) {
        $('#' + this.Name).DataTable().page.len(length).draw();
        var paginate = document.getElementById(this.Name + "_cus_paginate");
        var paginatePrev = document.getElementById(this.Name + "_cus_paginatePrev");
        var paginateNext = document.getElementById(this.Name + "_cus_paginateNext");

        var pageMax = Math.ceil(this.GetRecordCount() / length);
        pageMax = (pageMax == 0 ? 1 : pageMax);
        while (paginate.children.length != 0) { paginate.removeChild(paginate.children[0]); }
        for (var i = 1; i <= pageMax; i++) {
            var ele = document.createElement("option");
            ele.setAttribute("value", i);
            ele.innerHTML = i;
            paginate.appendChild(ele);
        }
        jDataTableUpdatePaginate(this.Name, this.ImgURL, 1);
    }
    this.GetCurrentPageLength = function () {
        return parseInt(document.getElementById(this.Name + "_cus_paginatelength").value);
    }
    this.GotoPage = function (page) {
        var oTable = $('#' + this.Name).dataTable();
        oTable.fnPageChange(page - 1);
        jDataTableUpdatePaginate(this.Name, this.ImgURL, parseInt(page));
    }

    function jDataTableUpdatePaginate(senderName, imgUrl, page) {
        var min, max;
        var paginate = document.getElementById(senderName + "_cus_paginate");
        var paginatePrev = document.getElementById(senderName + "_cus_paginatePrev");
        var paginateNext = document.getElementById(senderName + "_cus_paginateNext");

        min = parseInt(paginate.children[0].value);
        max = parseInt(paginate.children[paginate.children.length - 1].value);
        if (page == min) {
            paginatePrev.src = imgUrl + "arrow-left-dis.png";
            paginatePrev.style.cursor = "default";
            paginatePrev.setAttribute("onclick", "");
        }
        else {
            paginatePrev.src = imgUrl + "arrow-left.png";
            paginatePrev.style.cursor = "pointer";
            paginatePrev.setAttribute("onclick", senderName + ".GotoPage(" + (page - 1) + ")");
        }

        if (page == max) {
            paginateNext.src = imgUrl + "arrow-right-dis.png";
            paginateNext.style.cursor = "default";
            paginateNext.setAttribute("onclick", "");
        }
        else {
            paginateNext.src = imgUrl + "arrow-right.png";
            paginateNext.style.cursor = "pointer";
            paginateNext.setAttribute("onclick", senderName + ".GotoPage(" + (page + 1) + ")");
        }
        paginate.selectedIndex = page - 1;
    }
    function SetAttributes(ele, attrValuePaires) {
        var s = document.createElement(ele);
        if (attrValuePaires != null)
            for (var i = 0; i < attrValuePaires.length ; i = i + 2) {
                s.setAttribute(attrValuePaires[i], attrValuePaires[i + 1]);
            }
        return s;
    };
};