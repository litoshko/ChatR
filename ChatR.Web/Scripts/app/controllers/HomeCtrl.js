(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeCtrl', HomeCtrl);

    HomeCtrl.$inject = ['$scope', 'signalRService']; 

// ReSharper disable once InconsistentNaming
    function HomeCtrl($scope, signalRService) {
        /* jshint validthis:true */
        var vm = this;

        $scope.chats = signalRService;
        $scope.username = undefined;
        $scope.sendChat = function () {
            $scope.chats.sendMessage($scope.username, $scope.message);
            $('#message').val('').focus();
        }

    }
})();
