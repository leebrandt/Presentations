function nonClosure() {
  'use strict';

  var date = new Date();
	return date.getMilliseconds();
}

// ########## Closure ############## //
function closure() {
  'use strict';

  var date = new Date();
  return function(){
    return date.getMilliseconds();
  };
}

(function(){
  'use strict';

  var newClosure = closure();

  console.log(newClosure());
  setTimeout(
  	function(){
  		console.log(newClosure());
  	},
    500);
})();
