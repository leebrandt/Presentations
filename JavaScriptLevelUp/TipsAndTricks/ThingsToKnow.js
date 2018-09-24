(function(){

	'use strict';

	var value1 = '5',
		value2 = 5,
		noValue;

	console.log('With == %s', value1 == value2);

	console.log('With === %s', value1 === value2);

	if(noValue){
		console.log('Won\'t do this');
	}else{
		console.log('No value is falsy');
	}

	var obj = {value1:'something'};

	with(obj){
		value1 = 5;
	}
	
	console.log(obj.value1);

	eval('console.log(\'All your server are belong to me!\')');

})();