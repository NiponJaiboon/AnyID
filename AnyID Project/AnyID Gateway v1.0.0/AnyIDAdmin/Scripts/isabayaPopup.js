function isabayaPopup(name) {
    this.Name = name;

    this.Show = function (text) {
        if (text) { document.getElementById(this.Name + "Content").innerHTML = text; }
        document.getElementById(this.Name + "O").click();
    }
    this.Hide = function () {
        document.getElementById(this.Name + "C").click();
    }
};