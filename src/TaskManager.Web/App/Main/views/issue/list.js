(function () {
    var app = angular.module('app');
    
    app.controller('app.views.issue.list', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.issue',
        function ($scope, $timeout, $uibModal, issueService) {
            var vm = this;

            vm.issues = [];

            function getIssues() {
                issueService.getIssues({}).then(function (result) {
                    vm.issues = result.data;
                });
            }

            vm.openIssueCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/issue/createModal.cshtml',
                    controller: 'app.views.issue.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getIssues();
                });
            };
            
            vm.openIssueEditModal = function (issue) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/issue/editModal.cshtml',
                    controller: 'app.views.issue.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return issue.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $timeout(function () {
                        $.AdminBSB.input.activate();
                    }, 0);
                });

                modalInstance.result.then(function () {
                    getIssues();
                });
            };

            vm.delete = function (issue) {
                abp.message.confirm(
                    "Delete Issue '" + issue.description + "'?",
                    function (result) {
                        if (result) {
                            issueService.delete({ id: issue.id })
                                .then(function () {
                                    abp.notify.info("Deleted Issue: " + issue.description);
                                    getIssues();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                getIssues();
            };

            getIssues();
        }
    ]);
})();