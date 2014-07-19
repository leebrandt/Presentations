var Project = require('./Setup');

module.exports = Project.FirstObject = function(){
	'use strict';

	var name = 'First Object',
		firstFunc = function(){
			console.log('%s : First Function', name);
		};

	return{
		FirstFunc: firstFunc
	};
};