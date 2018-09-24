var Killer = function (weapon) {
	var stabEm = function () {
		main.log('Stab. Stab. Stab.');
	},
	shootEm = function () {
		main.log('Pew. Pew. Pew.');
	},
	killEm = function () {
		if (weapon === 'knife') {
			return stabEm();
		}
		if (weapon === 'gun') {
			return shootEm();
		}
		main.log('Sorry, I can\'t kill ya today.');
	};

	return {
		KillEm: killEm
	};
};

var Psycho = new Killer('knife');
Psycho.KillEm();

var Sniper = new Killer('gun');
Sniper.KillEm();

var NormalPerson = new Killer();
NormalPerson.KillEm();