angular.module("umbraco").controller("People.PersonPickerController", 
	function($scope, dialogService){
		$scope.openPicker = function(){
			dialogService.open({
				template: "../app_plugins/people/propertyeditors/personpickerdialog.html",
				scope: $scope,
				callback: populate
			});
		};

		function populate(data){
			$scope.model.value = data;
		};
});


angular.module("umbraco").controller("People.PersonPickerDialogController", 
	function($scope, dialogService){

		$scope.dialogEventHandler = $({});

		$scope.dialogEventHandler.bind("treeNodeSelect", function(ev, args){
			args.event.preventDefault();
			args.event.stopPropagation();
			$scope.submit(args.node.id);
		});
	});