(function () {
    angular.module('app').controller('app.views.issue.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.issue',
        function ($scope, $uibModalInstance, issueService) {
            var vm = this;

            vm.issue = {};

            $scope.data = {
                users: []
            };

            function getUsers() {
                issueService.getUsers()
                    .then(function (result) {
                        $scope.data.users = result.data.items;
                    });
            }

            vm.save = function () {
                console.log(vm.issue);
                issueService.createIssue(vm.issue)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            getUsers();
        }
    ]);
})();