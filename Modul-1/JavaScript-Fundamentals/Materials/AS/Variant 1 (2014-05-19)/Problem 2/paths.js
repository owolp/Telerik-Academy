function solve(args) {
	'use strict';
	var sizes = args[0].split(' ').map(Number),
		rows = sizes[0],
		cols = sizes[1],
		border = Math.max(rows, cols),
		lab = args.slice(1).map(function (line) {
			return line.split(' ');
		}),
		directions = {
			dr: {
				row: 1,
				col: 1
			},
			ur: {
				row: -1,
				col: 1
			},
			ul: {
				row: -1,
				col: -1
			},
			dl: {
				row: 1,
				col: -1
			}
		},
		visited = {},
		row, col, sum;

	function inRange(value, border) {
		return 0 <= value && value < border;
	}

	function getValueAt(row, col) {
		return (1 << row) + col;
	}

	row = 0;
	col = 0;
	sum = 0;
	while (true) {
		if (!inRange(row, rows) || !inRange(col, cols)) {
			return 'successed with ' + sum;
		}
		if (visited[row * border + col]) {
			return 'failed at (' + row + ', ' + col + ')';
		}

		visited[row * border + col] = true;
		sum += getValueAt(row, col);
		var dir = lab[row][col];
		row += directions[dir].row;
		col += directions[dir].col;
	}
}