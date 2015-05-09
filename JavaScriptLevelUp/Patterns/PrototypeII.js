	var Vehicle = function(make, model, numDoors){
		this.make = make;
		this.model = model;
		this.numberOfDoors = numDoors;		
		this.drive = function(){
			main.log(this.make +' is driving');
		};
		this.stop = function(){
			main.log('I\'m stopped');
		};
	};

	function Truck(){
		this.bedLength = 0;
	}

	function Car(){
		this.axleType = 'single';
	}

	Truck.prototype = new Vehicle();
	Car.prototype = new Vehicle();

	var FordTruck = new Truck('Ford', 'F150', 2);

	var DodgeTruck = new Truck('Dodge', 'Ram1500', 4);
	var Taurus = new Car('Ford', 'Taurus');
	Taurus.axleType = 'Transaxle';

	myTruck.drive(); // I'm driving
	myTruck.stop(); // I'm stopped
	main.log(FordTruck.make); // Dodge
	main.log(Taurus.model); // Taurus