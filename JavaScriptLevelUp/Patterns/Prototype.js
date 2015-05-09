var myModule = function(){
	this.CallingMessage = "Someone is calling me.";
	this.AnswerMessage = "I have answered the call!";
};

myModule.prototype.CallMe = function(){
	console.log(this.CallingMessage);
};

myModule.prototype.Answer = function() {
	console.log(this.AnswerMessage);
};

(function(){

	'use strict';

	var module = new myModule();

	module.CallMe();

	module.Answer();

})();