var Project = require('./Setup'),
	FirstObject = require('./ObjectOne');

(function(){
	'use strict';

	Project.NewFunc = function(){
		console.log('I am here');
	};

	var obj1 = new Project.FirstObject();
	obj1.FirstFunc();

	var obj2 = require('./ObjectTwo')();
	obj2.SecondFunc();

	Project.FirstObject.prototype.yak = function()
	{
		console.log('Barf!');
	};

	Project.NewFunc();

	Project.FirstObject.yak();
	
})();