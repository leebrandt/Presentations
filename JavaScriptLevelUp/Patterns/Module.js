var MyModule = function(){

	'use strict';

	return {
		CallMe: function(){
			console.log('Someone is calling me.');
		},
		Answer: function(){
			console.log('I answered the call!');
		}
	};
};

(function(){

	'use strict';

	var module = new MyModule();

	module.CallMe();

	module.Answer();

})();