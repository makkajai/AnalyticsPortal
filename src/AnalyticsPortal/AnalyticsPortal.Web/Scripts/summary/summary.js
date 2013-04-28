function SummaryViewModel() {
// ReSharper disable InconsistentNaming
    var _this = this;
// ReSharper restore InconsistentNaming
    this.studentLogin = ko.observable(""); //this is what is used for fetching data - should be updated

    this.studentSummary = ko.observableArray();

    this.bindRow = function (row) {
        _this.studentSummary.push(row);
    };

    this.bindStudentData = function (data) {
        data.forEach(_this.bindRow);
    };
    
    this.getData = function() {
        _this.studentSummary.removeAll();
        var summaryUrl = "/summary/" + this.studentLogin();
        jQuery.get(summaryUrl, this.bindStudentData, 'json');
    };
};

$('input').first().focus();
ko.applyBindings(new SummaryViewModel());