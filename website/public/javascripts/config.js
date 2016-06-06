(function() {
  'use strict';

  angular
    .module('InfiniteGarden')
    .config(router);

  router.$inject = ['$routeProvider', '$locationProvider'];

  function router($routeProvider, $locationProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'javascripts/login/login.html',
        controller: 'Login',
        controllerAs: 'user'
      })
      .when('/home', {
        templateUrl: 'javascripts/login/signedin.html',
        controller: 'Login',
        controllerAs: 'user'
      });


      $locationProvider.html5Mode(true);
  }
})();
