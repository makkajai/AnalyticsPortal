function SummaryViewModel() {
    this.studentLogin = ko.observable(""); //this is what is used for fetching data - should be updated

    this.studentSummary = ko.observableArray([{Duration: "100"}, {Duration: "200"}]);

    this.getData = function() {
        //make a call to the function
        //get data
        var summaryUrl = "/summary/" + this.studentLogin();
        jQuery.get(summaryUrl, this.bindStudentData, 'json');
        alert("got to the end");
    };

    this.bindStudentData = function (data) {
        ko.mapping.fromJS(data, this.studentSummary);
        alert("mapped");
    };
};

$('input').first().focus();
ko.applyBindings(new SummaryViewModel());