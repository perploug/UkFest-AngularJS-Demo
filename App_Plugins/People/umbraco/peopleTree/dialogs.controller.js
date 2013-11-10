angular.module("umbraco")
.controller("People.PersonDrinkController", 
	function($scope, personResource, navigationService){
		$scope.drink = function(id){
		    personResource.getDrunkById(id).then(function(){
				navigationService.reloadNode($scope.currentNode.parent);
				navigationService.hideNavigation();
			});
		};
	});

angular.module("umbraco")
.controller("People.PersonDetoxController", 
	function($scope, personResource, navigationService){
		$scope.detox = function(id){
		    personResource.getSoberById(id).then(function(){
				navigationService.reloadNode($scope.currentNode.parent);
				navigationService.hideNavigation();
			});
		};
	});