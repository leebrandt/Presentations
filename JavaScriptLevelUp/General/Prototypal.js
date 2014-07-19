(function(){

	'use strict';
	
	var myObject = function(){};

	var newObject = new myObject();

	//console.log(newObject.yak());

	myObject.prototype.yak = function(){
		return 'Ralph! Barf! Puke!';
	}

	console.log(newObject.yak());

})();