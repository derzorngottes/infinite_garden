(function() {
  'use strict';

  angular
    .module('journal', [])
    .directive('journal', journal);

  function journal() {
    return {
      restrict: 'E',
      scope: {
        user: '='
      },
      replace: true,
      templateUrl: 'app/javascripts/journal/journal.html',
      link: function(scope, element, attrs) {
        $("#flipbook").turn({
          width: '100%',
          height: 300,
          autoCenter: true
        });
        $('#flipbook').turn('peel', 'br');
      },
      controller: function($scope) {
        $scope.show_page = page => {
          console.log('page', page);
          $('#flipbook').turn('page', page);
        }
      },
      controllerAs: 'journal'
    }
  }
})();
