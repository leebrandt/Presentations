(function(){

	'use strict';

	var myObject = {
		key: '1',
		newKey: ['1','2','3','4'],
		nutherKey: {
			key: 2
		},
		yak: function(){
			console.log('Ralph!');
		},
		barf: function(){
			return 'Puke!';
		}
	};

	console.log(myObject.key);
	console.log(myObject.newKey[3]);
	console.log(myObject.nutherKey.key);
	myObject.yak();
	console.log(myObject.barf());
})();

