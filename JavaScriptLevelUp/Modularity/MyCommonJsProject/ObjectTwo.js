var Project = require('./Setup');

module.exports = Project.SecondObject = function(){
	'use strict';

	var name = 'Second Object',
		secondFunc = function(){
			console.log('%s : Second Function', name);
		};

	return{
		SecondFunc: secondFunc
	};

};
