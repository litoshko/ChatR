(function () {
    'use strict';

    angular
        .module('app')
        .factory('signalRService', signalRService);

    signalRService.$inject = ['$rootScope', 'Hub'];

    function signalRService($rootScope, Hub) {

        // API declaration
        var service = {
            getMessages: getMessages,
            sendMessage: sendMessage
        };

        var messages = [];

        //Chat ViewModel
        var Chat = function (chat) {
            if (!chat) chat = {};

            var Chat = {
                UserName: chat.UserName || 'Anonimous',
                ChatMessage: chat.ChatMessage || ''
            }

            return Chat;
        }

        //Hub setup
        var hub = new Hub("chatRHub", {
            listeners: {
                'addNewMessageToPage': function (userName, chatMessage) {
                    addMessage(userName, chatMessage);
                    $rootScope.$digest();
                }
            },
            methods: ['send'],
            errorHandler: function (error) {
                console.error(error);
            },
            hubDisconnected: function () {
                if (hub.connection.lastError) {
                    hub.connection.start();
                }
            },
            transport: 'webSockets',
            logging: true
        });

        // API implementation
        function sendMessage(userName, chatMessage) {
            hub.send(userName, chatMessage);
        }

        function getMessages() {
            return messages;
        }

        // helpers
        function addMessage(userName, chatMessage) {
            messages.push(new Chat({ UserName: userName, ChatMessage: chatMessage }));
        }

        return service;
    }
})();