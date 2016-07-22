// location: /app/persons/person-list.controller.js
(function () {
    'use strict';

    var controllerId = 'PersonListController';

    angular
        .module('PersonsApp')
        .controller(controllerId, personController);

    personController.$inject = ['personFactory'];

    function personController(personFactory) {
        var vm = this;

        // method of vm
        vm.delete = del;

        // list of collection
        vm.listData = [];

        getAll();

        // get all person entities
        function getAll() {
            return personFactory.getPersons()
                .then(function (result) { vm.listData = result.data; })
                .catch(showError);
        }

        // delete person entity by id
        function del(id) {
            if (confirm('are u sure ?')) {
                return personFactory.deletePerson(id)
                .then(function (msg) { getAll(); })
                .catch(showError);
            } else return;
        }

        function showError(msg) {
            console.log(msg);
            alert('error occured: ' + msg.statusText);
        }
    }
})();