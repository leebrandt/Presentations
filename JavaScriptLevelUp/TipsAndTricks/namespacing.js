var MyProjectName = MyProjectName || {};

MyProjectName.FirstObject = function () {
	'use strict';

	var name = 'First Object',
		firstFunc = function () {
			console.log('%s : First Function', name);
		};

	return {
		FirstFunc: firstFunc
	};
};

MyProjectName.SecondObject = function () {
	'use strict';

	var name = 'Second Object',
		secondFunc = function () {
			console.log('%s : Second Function', name);
		};

	return {
		SecondFunc: secondFunc
	};

};

(function (p) {
	'use strict';

	var firstObject = new p.FirstObject(),
		secondObject = new p.SecondObject();

	firstObject.FirstFunc();

	secondObject.SecondFunc();

})(MyProjectName);




