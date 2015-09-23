// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize
                // your application here.
            } else {
                // TODO: This application has been reactivated from suspension.
                // Restore application state here.
            }
            args.setPromise(WinJS.UI.processAll());
        }
    };

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
    };

    app.start();

    WinJS.Utilities.ready(function () {
        // get the element by id
        var input = document.getElementById("inputUrl");
        // add our event listener here
        input.addEventListener("change", changeHandler);
    }, false);

    function changeHandler(e) {
        var input = e.target;
        var resDiv = document.getElementById("ResultDiv");
        resDiv.innerText = "requesting....";
        resDiv.style.backgroundColor = "transparent";
        WinJS.xhr({ url: e.target.value }).then(function completed(result) {
            if (result.status === 200) {
                resDiv.style.backgroundColor = "lightGreen";
                resDiv.innerText = "Success";
            }
        },
        function rejected() {
            resDiv.style.backgroundColor = "red";
            resDiv.innerText = "Error";
        }
        );
    }
})();

