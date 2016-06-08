(function() {
  'use strict';

  angular
    .module('InfiniteGarden')
    .controller('Home', Home);

  Home.$inject = ['$scope', 'UserService'];

  function Home($scope, UserService) {
    const vm = this;

    vm.user = null;

    initController();

    function initController() {
      UserService.getCurrent().then(user => {
          vm.user = user;
        });
    }
  }
})();
