var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('BookingSystem');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);