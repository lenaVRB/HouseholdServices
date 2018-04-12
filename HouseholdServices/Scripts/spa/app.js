(function () {
    'use strict';

    angular.module('householdSerivices', ['common.core', 'common.ui']).config(config);

    config.$inject = ['&routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/home/index.html",
                controller: "indexCtrl"
            })
            .when("/login", {
                templateUrl: "scripts/spa/account/login.html",
                controller: "loginCtrl"
            })
            .when("/register", {
                templateUrl: "scripts/spa/account/register.html",
                controller: "registerCtrl"
            })
            .when("/customers", {
                templateUrl: "scripts/spa/customers/customers.html",
                controller: "customersCtrl"
            })
            .when("/customers/register", {
                templateUrl: "scripts/spa/customers/register.html",
                controller: "customersRegCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/services", {
                templateUrl: "scripts/spa/services/services.html",
                controller: "servicesCtrl"
            })
            .when("/services/add", {
                templateUrl: "scripts/spa/services/add.html",
                controller: "serviceAddCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/services/:id", {
                templateUrl: "scripts/spa/services/details.html",
                controller: "serviceDetailsCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/services/edit/:id", {
                templateUrl: "scripts/spa/services/edit.html",
                controller: "serviceEditCtrl"
            })
            .when("/order", {
                templateUrl: "scripts/spa/order/order.html",
                controller: "orderStatsCtrl"
            }).otherwise({ redirectTo: "/" });
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
            $(".fancybox").fancybox({
                openEffect: 'none',
                closeEffect: 'none'
            });

            $('.fancybox-media').fancybox({
                openEffect: 'none',
                closeEffect: 'none',
                helpers: {
                    media: {}
                }
            });

            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('/login');
        }
    }

})();