(function () {
    'use strict';

    angular
        .module('app')
        .factory('signalRService', signalRService);

    signalRService.$inject = ['$rootScope', 'Hub', 'chatService'];

    function signalRService($rootScope, Hub, chatService) {

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

        // Initalize messages
        chatService.getMessages().then(function (response) {
                response.data.forEach(function(item) {
                    messages.push(new Chat({ UserName: item.Name, ChatMessage: item.Text }));
                });
            },
            function (response) {
                console.log("Server error: " + response.status);
            });

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