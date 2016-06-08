(function() {
  'use strict';

  angular
    .module('InfiniteGarden')
    .config(router)
    .run(run);

  router.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];

  function router($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider
      .state('login', {
        url: '/app',
        templateUrl: 'javascripts/login/login.html',
        controller: 'Login',
        controllerAs: 'user'
      })
      .state('home', {
        url: '/home',
        templateUrl: 'javascripts/home/home.html',
        controller: 'Home',
        controlerAs: 'home',
        data: { activeTab: 'home' }
      });

      $locationProvider.html5Mode(true);
  }

  function run($http, $rootScope, $window) {
    // add JWT token as default auth header
    $http.defaults.headers.common['Authorization'] = 'Bearer ' + $window.jwtToken;

    //update active tab on state change
    $rootScope.$on('$stateChangeSuccess', (event, toState, toParams, fromState, fromParams) => {
      $rootScope.activeTab = toState.data.activeTab;
    });
  }

  //manually bootstrap angular after the JWT token is retrieved from the stateProvider
  $(function() {
    //get JWT token from stateProvider
    $.get('/app/token', token => {
      window.jwtToken = token;

      angular.bootstrap(document, ['InfiniteGarden']);
    });
  });
})();
