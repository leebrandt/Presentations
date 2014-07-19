(function(){
	'use strict';

	var myObject = {
		WhoAreYou: function(){
			console.log('My name is ' + this.name);
		},
		name: 'Jim'
	};

	var newObject = {
		name: 'Jane'
	};

	myObject.WhoAreYou();
	myObject.WhoAreYou.call( newObject );

})();

