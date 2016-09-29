function dnaHelix([n]) {
	let sequence = 'ATCGTTAGGG';
	let index = 0;

	let rows = [];
	rows[0] = "'**' + getSymbol() + getSymbol() + '**'";
	rows[1] = "'*' + getSymbol() + '--' + getSymbol() + '*'";
	rows[2] = "getSymbol() + '----' + getSymbol()";
	rows[3] = rows[1];

	for (let row = 0; row < n; row++) {
		console.log(eval(rows[row % 4]));
	}

	function getSymbol() {
		let symbol = sequence[index];
		index++;
		index = index % sequence.length;
		return symbol;
	}
}

dnaHelix([10])