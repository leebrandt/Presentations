var MyModule = function(){

	'use strict';

	var callingMessage = 'Someone is calling me.',

		answerMessage = 'I have answered the call.',

		callMe = function(){
			console.log(callingMessage);
		},

		answer = function(){
			console.log(answerMessage);
		};

	return{
		CallMe: callMe,
		Answer: answer
	};
};

(function(){

	'use strict';

	var module = MyModule();

	module.CallMe();

	module.Answer();
	

})()