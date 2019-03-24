(function () {
    angular.module('app').controller('app.views.issue.editModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.issue', 'id',
        function ($scope, $uibModalInstance, issueService, id) {
            var vm = this;

            vm.issue = {};

            $scope.users = [];
            
            var init = function () {
                issueService.getUsers()
                    .then(function (result) {
                        $scope.users = result.data.items;

                        issueService.get({ id: id })
                            .then(function (result) {
                                vm.issue = result.data;
                                vm.issue.deadline = new Date(result.data.deadline); 
                            });
                    });
            }

            vm.save = function () {
                issueService.updateIssue(vm.issue)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            init();
        }
    ]);
})();