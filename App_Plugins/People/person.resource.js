angular.module("umbraco.resources")
	.factory("personResource", function($http){
	return{
		getById: function(id){
			return $http.get("People/PersonApi/GetById?id="+id);
		},

		getall: function(){
			return $http.get("People/PersonApi/GetAll");
		},

		save: function(person){
			return $http.post("People/PersonApi/PostSave", angular.toJson(person));
		},

		getDrunkById: function(id){
			return $http.get("People/PersonApi/GetDrunk?id="+id);
		},

		getSoberById: function(id){
			return $http.get("People/PersonApi/GetSober?id="+id);
		}
	};
});