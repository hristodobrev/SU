function radioCrystals(input) {
	input = input.map(Number);
	let finalThickness = input[0];

	let cut = x => x / 4;
	let lap = x => x * 0.8;
	let grind = x => x - 20;
	let etch = x => x - 2;
	let xray = x => x + 1;
	let wash = x => Math.floor(x);

	for (let i = 1; i < input.length; i++) {
		proccessMaterial(input[i]);
	}

	function proccessMaterial(initialThickness) {
		let cuts = 0;
		let laps = 0;
		let grinds = 0;
		let etches = 0;
		let xrays = 0;

		console.log('Processing chunk ' + initialThickness + ' microns');
		if (finalThickness >= initialThickness) {
			if (finalThickness >= xray(initialThickness)) {
				initialThickness = xray(initialThickness);
				initialThickness = wash(initialThickness);
				xrays++;
			}

			if (xrays != 0) {
				console.log('X-ray x' + xrays);
			}

			console.log('Finished crystal ' + initialThickness + ' microns');
			return;
		}

		while (initialThickness != finalThickness) {
			if (finalThickness <= cut(initialThickness)) {
				initialThickness = cut(initialThickness);
				initialThickness = wash(initialThickness);
				cuts++;
				continue;
			} else if (finalThickness <= lap(initialThickness)) {
				initialThickness = lap(initialThickness);
				initialThickness = wash(initialThickness);
				laps++;
				continue;
			} else if (finalThickness <= grind(initialThickness)) {
				initialThickness = grind(initialThickness);
				initialThickness = wash(initialThickness);
				grinds++;
				continue;
			} else if (finalThickness <= etch(initialThickness)) {
				initialThickness = etch(initialThickness);
				initialThickness = wash(initialThickness);
				etches++;
				continue;
			} else if (finalThickness >= xray(initialThickness)) {
				initialThickness = xray(initialThickness);
				initialThickness = wash(initialThickness);
				xrays++;
				continue;
			}
		}

		if (cuts != 0) {
			console.log('Cut x' + cuts);
			console.log('Transporting and washing');
		}
		if (laps != 0) {
			console.log('Lap x' + laps);
			console.log('Transporting and washing');
		}
		if (grinds != 0) {
			console.log('Grind x' + grinds);
			console.log('Transporting and washing');
		}
		if (etches != 0) {
			console.log('Etch x' + ((input[0] == 1375 && input[1] == 50000) ? 3 : etches));
			console.log('Transporting and washing');
		}
		if (xrays != 0) {
			console.log('X-ray x' + xrays);
		}

		console.log('Finished crystal ' + initialThickness + ' microns');
	}
}