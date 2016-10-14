(function() {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.room', function($scope, roomService) {
            var vm = this;
            //Home logic...
            vm.rooms = [];

            function getRooms() {
                roomService.getRooms({}).success(function (result) {
                    vm.rooms = result.items;
                });
            }

            var createRoomInput = {
                name: '',
                numberOfPeople: 0
            };

            vm.uiRoomName = "";
            vm.uiNumberOfPeople = 0;

            vm.registerClick = function () {
                abp.ui.setBusy();
                createRoomInput.name = vm.uiRoomName;
                createRoomInput.numberOfPeople = vm.uiNumberOfPeople;
                roomService.createRoom(createRoomInput)
                    .success(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        getRooms();
                    }).finally(function () {
                        abp.ui.clearBusy();
                    });
            };

            var deleteRoomInput = {
                id: -1
            };
            vm.deleteRoom = function (id) {
                abp.ui.setBusy();
                deleteRoomInput.id = id;
                roomService.deleteRoom(deleteRoomInput)
                    .success(function () {
                        abp.notify.info(App.localize('DeleteSuccessfully'));
                        getRooms();
                    }).finally(function () {
                        abp.ui.clearBusy();
                    });;
            };

            getRooms();
        }
    ]);
})();