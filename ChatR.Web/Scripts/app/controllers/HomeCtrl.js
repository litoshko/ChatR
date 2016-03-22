(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeCtrl', HomeCtrl);

    HomeCtrl.$inject = ['signalRService']; 

// ReSharper disable once InconsistentNaming
    function HomeCtrl(signalRService) {
        /* jshint validthis:true */
        var vm = this;

        vm.chats = signalRService;
        vm.username = undefined;
        vm.sendChat = function () {
            vm.chats.sendMessage(vm.username, vm.message);
            vm.message = '';
            $('#newMessage').focus();
        }

    }
})();
