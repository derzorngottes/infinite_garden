(function() {
  'use strict';

  angular
    .module('InfiniteGarden')
    .config(router);

  router.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];

  function router($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider
      .state('landing', {
        url: '/',
        templateUrl: 'javascripts/login/login.html',
        controller: 'Login',
        controllerAs: 'user'
      });

      $locationProvider.html5Mode(true);
  }
})();
