(function(){
	'use strict';

	function callback(){
		console.log('The asynchronous call finished');
	}


	function asyncFunc(ms, cb){
		console.log('Making some asynchronous call.');
		setTimeout(function(){
			cb();
		}, ms);
		console.log('Done running the method, but the async call hasn\'t finished yet...');
	}

	asyncFunc(3000, callback);

	asyncFunc(2000, function(){
		console.log('Doing some anonymous function when the async method is finished.');
	});

})();