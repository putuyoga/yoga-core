// location: /app/persons/person.controller.js
// the main purpose of this controller is
// to create and update an entity
(function () {
    'use strict';

    var controllerId = 'PersonFormController';

    angular
        .module('PersonsApp')
        .controller(controllerId, personFormController);

    personFormController.$inject = ['personFactory', '$stateParams', '$state'];

    function personFormController(personFactory, $stateParams, $state) {
        var vm = this;

        // properties
        vm.data = {
            firstName: '',
            birthDate: null,
            sex: 0
        };
        vm.isBusy = false;
        vm.busyMsg = '';
        vm.titleMode = '';

        // method
        vm.save = save;

        // execute this first when controller called
        // to check the state is edit or add
        check();

        function check() {
            if ($state.is('person_edit'))
            {
                vm.titleMode = 'Update a Person';
                startAction('getting data...');

                var id = $stateParams.personId;
                return personFactory.getPerson(id)
                    .then(getDataComplete)
                    .catch(showError);
            } else {
                vm.titleMode = 'Create new Person';
            }
            
        }

        function save() {

            startAction('saving data...');

            if ($state.is('person_edit')) {
                var id = $stateParams.personId;

                // add id property
                var data = vm.data;
                data.id = id;

                // send update request
                return personFactory.updatePerson(data)
                    .then(saveComplete)
                    .catch(showError);
            } else {
                return personFactory.addPerson(vm.data)
                    .then(saveComplete)
                    .catch(showError);
            }
        }

        function saveComplete(msg) {
            stopAction();
            $state.go('person_list');
        }

        function getDataComplete(msg)
        {
            stopAction();
            
            // little hack 
            msg.data.birthDate = new Date(msg.data.birthDate);
            vm.data = msg.data;
        }

        function startAction(msg)
        {
            vm.isBusy = true;
            vm.busyMsg = msg;
        }

        function stopAction()
        {
            vm.busyMsg = '';
            vm.isBusy = false;
        }

        function showError(msg) {
            stopAction();
            alert('error occured: ' + msg.statusText);
        }
    }
})();