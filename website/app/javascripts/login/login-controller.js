(function() {
  'use strict';

  angular
    .module('InfiniteGarden')
    .controller('Login', Login);

  Login.$inject = ['$scope', '$rootScope'];

  function Login($scope, $rootScope) {
    const vm = this;

    vm.createAccount = false;
    vm.credentials = {
      username: '',
      password: ''
    };

    vm.login = credentials => {
      authService.login(credentials).then(user => {
        $rootScope.$broadcast(AUTH_EVENTS.loginSuccess);
        vm.setCurrentUser(user);
      }, () => {
        $rootScope.$broadcast(AUTH_EVENTS.loginFailed);
      });
    }

    vm.toggleCreateAccount = function() {
      if (vm.createAccount === true) {
        vm.createAccount = false;
      }
      else {
        vm.createAccount = true;
      }
    }
  }
})();
