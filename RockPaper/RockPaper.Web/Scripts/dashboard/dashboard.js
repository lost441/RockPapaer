/// <reference path="../jquery-1.9.1.js" />
/// <reference path="../knockout-3.4.0.debug.js" />


$(document).ready(function () {


    var poolServer = function(timeout,delegate)
    {
        setTimeout(getResultsFromServer, timeout);
        poolServer(timeout, delegate);
    }

    function getResultsFromServer() {

        $.ajax({
            url: 'http://localhost:49207/Dashboard/GetResults',
            type: 'GET',
            success: function (data) {
                if (data.IsSuccessfull === true) {
                    populateDashboard(data.Data);
                }
                else {

                    notifyError(data.ResultDescription);
                }
            },

            error: function (xhr, errorMessage, errocode) {
                alert(errorMessage);
            }

        });

    }

    function populateDashboard(data) {

        ViewModel.Games = data;
    }

    function notifyError(errormessage) {
        $("#dashboardcontainer").append("<div class='row' id='errorResponse'><div class='alert alert-warning'>" + errormessage + "</div></div>");
    }

   

    var ViewModel = function () {

        var self = this;
        self.Games = ko.observable();

    };

    poolServer(60000, poolServer);


    var viewModel = new ViewModel();
    ko.applyBindings(viewModel);
});