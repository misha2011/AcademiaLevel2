(function () {
    'use strict';
    function postEditor($scope, $uibModal, $log) {
        {
            alert("okkkk");
            $scope.modalPopup = function () {
                modal = $uibModal.open({
                    templateUrl: 'blocks/modal/dialog.html',
                    scope: $scope
                });

                $scope.modalInstance = modal;

                return modal.result
            };


            $scope.modalPopupTrigger = function () {
                $scope.modalPopup()
                  .then(function (data) {
                      $scope.handleSuccess(data);
                  })
                  .then(null, function (reason) {
                      $scope.handleDismiss(reason);
                  });
            };

            $scope.yes = function () {
                $scope.modalInstance.close('Yes Button Clicked')
            };

            $scope.no = function () {
                $scope.modalInstance.dismiss('No Button Clicked')
            };

            $scope.handleSuccess = function (data) {
                $log.info('Modal closed: ' + data);
            };

            $scope.handleDismiss = function (reason) {
                $log.info('Modal dismissed: ' + reason);
            }

        }
    }
    postEditor.$inject = ['$scope', '$uibModal', '$log'];
    angular.module('post.directive', [])
    .directive('postEditor', postEditor);
})();