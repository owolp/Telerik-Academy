# Exam Prep Materials

## Code to find index

### Two Girls One Path

    function mollyPosition(currentMollyPosition, currentFlowersMolly, length) {
        return (currentMollyPosition + currentFlowersMolly) % length;
    }

    function dollyPosition(currentDollyPosition, currentFlowersDolly, length) {
        var position = (currentDollyPosition - currentFlowersDolly) % length;
        if (position < 0) {
            position += length;
        }

        return position;
    }

## Code to find if index is in range for matrix

### Labyrinth

    function inRange(value, border) {
        return 0 <= value && value < border;
    }

    ...

    if (!inRange(row, rows) || !inRange(col, cols)) {
        return 'out ' + sum;
    }

## Code for extracting rows and cols from params

### Horsy

    function getRowsAndCols(params) {
        return params[0].split(" ").map(Number);
    }

    rowsAndCols = getRowsAndCols(params);
    rows = rowsAndCols[0];
    cols = rowsAndCols[1];
    // console.log(rows + " " + cols);