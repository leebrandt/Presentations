(function($){

	function asyncFunc(){

		var d = new $.Deferred();

		setTimeout(function(){
			d.resolve('finished');
		}, 2000);

		setTimeout(function working() {
		    if ( d.state() === 'pending' ) {
		      d.notify('working');
		      setTimeout( working, 500 );
		    }
		  }, 1 );

		return d.promise();
	};

	$.when(asyncFunc())
		.progress(function(status){
			console.log(status);
		})
		.then(function(status){
			console.log(status);
		});	

})($)