(function (app) {
    'use strict';

    app.controller('servicesCtrl', servicesCtrl);

    moviesCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function moviesCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-movies';
        $scope.loadingServices = true;
        $scope.page = 0;
        $scope.pagesCount = 0;

        $scope.Services = [];

        $scope.search = search;
        $scope.clearSearch = clearSearch;

        function search(page) {
            page = page || 0;

            $scope.loadingServices = true;

            var config = {
                params: {
                    page: page,
                    pageSize: 6,
                    filter: $scope.filterServices
                }
            };

            apiService.get('/api/services/', config,
                servicesLoadCompleted,
                servicesLoadFailed);
        }

        function servicesLoadCompleted(result) {
            $scope.Services = result.data.Items;
            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPages;
            $scope.totalCount = result.data.TotalCount;
            $scope.loadingServices= false;

            if ($scope.filterServices && $scope.filterServices.length) {
                notificationService.displayInfo(result.data.Items.length + ' services found');
            }

        }

        function servicesLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function clearSearch() {
            $scope.filterServices = '';
            search();
        }

        $scope.search();
    }

})(angular.module('householdServices'));