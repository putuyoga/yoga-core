// Location: /app/app.config.json
(function () {
    angular
        .module('PersonsApp', ["ui.router"])
        .config(function ($stateProvider, $urlRouterProvider) {
            // For any unmatched url, redirect to /
            //$urlRouterProvider.otherwise("/person");

            // Now set up the states
            $stateProvider
                .state('person_list', {
                    url: '/',
                    templateUrl: "/app/persons/person-list.html",
                    controller: 'PersonListController as person'
                })
                .state('person_add', {
                    url: '/add',
                    templateUrl: '/app/persons/person-form.html',
                    controller: 'PersonFormController as person'
                })
                .state('person_edit', {
                    url: '/edit/{personId}',
                    templateUrl: '/app/persons/person-form.html',
                    controller: 'PersonFormController as person'
                })
        })
        .config(["$locationProvider", function ($locationProvider) {
            $locationProvider.html5Mode(true);
        }]);;
})();