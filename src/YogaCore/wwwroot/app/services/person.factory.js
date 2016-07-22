// location: /app/factories/person.factory.js
(function () {
    'use strict';

    var serviceId = 'personFactory';

    angular
        .module('PersonsApp')
        .factory(serviceId, personFactory);

    personFactory.$inject = ['$http'];

    function personFactory($http) {

        // accessible members always on top
        var factory = {
            getPersons: getPersons,
            getPerson: getPerson,
            addPerson: addPerson,
            updatePerson: updatePerson,
            deletePerson: deletePerson
        };
        return factory;

        // get all person entities
        function getPersons() {
            return $http.get("/api/person");
        }

        // get a person entity by id
        function getPerson(id) {
            console.log("trying get person entities");
            return $http.get("/api/person/" + id);
        }

        // create a new person entity
        function addPerson(person) {

            console.log("trying post new person:");
            console.log(person);

            var response = $http({
                method: "post",
                url: "/api/person",
                data: JSON.stringify(person),
                dataType: "json"
            });
            return response;
        }

        /// update a new person entity
        function updatePerson(person) {
            console.log("trying update person: #" + person.id);

            var response = $http({
                method: "put",
                url: "/api/person/" + person.id,
                data: JSON.stringify(person),
                dataType: "json"
            });
            return response;
        }

        function deletePerson(id)
        {
            console.log("deleting person with id: #" + id);
            return $http.delete('/api/person/' + id);
        }
    }
})();