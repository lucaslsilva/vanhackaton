var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('TaskManager');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);