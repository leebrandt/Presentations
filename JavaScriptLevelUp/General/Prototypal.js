(function(){

	'use strict';
	
	var MyObject = function(){};

	var newObject = new MyObject();

	//console.log(newObject.yak());

	myObject.prototype.yak = function(){
		return 'Ralph! Barf! Puke!';
	};

	console.log(newObject.yak());

})();