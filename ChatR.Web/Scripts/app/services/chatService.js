(function () {
    'use strict';

    angular
        .module('app')
        .factory('chatService', chatService);

    chatService.$inject = ['$http', '$q'];

    function chatService($http, $q) {

        // API declaration
        var service = {
            getMessages: getMessages
        };
        
        // API implementation
        function getMessages() {
            return $q(function (resolve, reject) {
                $http({
                    method: 'GET',
                    url: '/Home/GetMessages'
                }).then(resolve, reject);
            });
        }

        return service;
    }
})();