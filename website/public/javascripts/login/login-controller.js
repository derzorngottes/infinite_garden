(function() {
  'use strict';

  angular
    .module('InfiniteGarden')
    .controller('Login', Login);

  Login.$inject = ['$scope'];

  function Login($scope) {
    const vm = this;

    vm.createAccount = false;

    vm.toggleCreateAccount = function() {
      console.log('clicked');
      if (vm.createAccount === true) {
        vm.createAccount = false;
      }
      else {
        vm.createAccount = true;
      }
    }
  }
})();
