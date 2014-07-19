var newClosure = closure();

console.log(newClosure());
setTimeout(
	function(){
		console.log(newClosure())
	}, 500);


function nonClosure(){
	var date = new Date();
	return date.getMilliseconds();
}

// ########## Closure ############## //
function closure(){
	var date = new Date();
	return function(){
		return date.getMilliseconds();
	}
}

