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

## Code to check if inside matrix

### Joro the Naughty

    function inRange(position, range) {
        return 0 <= position && position < range;
    }

    ...

    if (!(inRange(row, rows)) || !(inRange(col, cols))) {
        console.log("escaped " + sum);
        return;
    }


## Examples

    ''.trimStart()
    String.prototype.trimStart= function() {
        return this.replace(/^\s+/,"");
    }

    ''.trimEnd()
    String.prototype.trimEnd= function() {
        return this.replace(/\s+$/,"");
    }


### Removes the first element found from left to right in the array

#### Second argument should be truthy to remove all elements

    [].remove(arg, all)

    Array.prototype.remove = function(arg, all){
        for(var i = 0; i < this.length; i++){
            if(this[i] === arg){
                this.splice(i,1);

                if(!all)
                    break;
                else
                    i--;
            }
        }
    };


### Removes the element at the position

    [].removeAt(pos)

    Array.prototype.removeAt = function(position){
        this.splice(position,1);
    };

### Removes all elements of the array

    [].clear()

    Array.prototype.clear = function(){
        this.length = 0;
    };

### Inserts an element at a given position

    [].insertAt(arg, pos)

    Array.prototype.insertAt = function(arg, position){
        this.splice(position, 0, arg);
    };

### Checks if the array contains the given element

    [].contains(arg)

    Array.prototype.contains = function(arg){
        for(var i = 0; i < this.length; i++)
            if(this[i] === arg)
                return true;
        return false;
    };

### Counts the occurrences of a given element in array

    [].occurs(arg)

    Array.prototype.occurs = function(arg){
        var counter = 0;

        for(var i = 0; i< this.length; i++){
            if(this[i] === arg)
                counter++;
        }

        return counter;
    };

### Sort integer elements

    array.sort(function(a, b) {return a - b})

### Проверка на числа

    function isNumber(n) {
        return !isNaN(parseFloat(n)) && Number.isFinite(n);
    }

### Пъленене на двумерен масив

    var matrix = [], rows = 5, cols = 5 ,row , col , count = 0 ;
    for(row = 0; row < rows; row += 1) {
        matrix.push( [] );
        for ( col = 0; col < cols; col += 1){
            matrix[row][col] = count;
            count += 1;
        }
    }

### Deep clone на масив

    var numbers = [5, 6, 7, 8, 9];
    var copy = numbers.slice();
    numbers[1] = 100;
    console.log(numbers); // [5,100,7,8,9];
    console.log(copy); // [5,6,7,8,9];

### JS еквивалент на string.IsNurrOrEmpty()

    function isEmpty(string) {
            return (string.length === 0 || !string.trim());
        };

### Проверка дали даден стринг е число

    function isNumeric(obj) {
            return obj - parseFloat(obj) >= 0;
    }

### Зачистване на празни стрингове в масив

    arr = arr.filter(function (item) { return item; });

    или

    array = array.filter(Boolean);

### JS еквивалент на Contains()

    function contains(arr, value, start, end) {
                var i,
                start = start || 0,
                end = end || arr.length;

                for (i = start; i < end; i++) {
                    if (arr[i] === value) {
                        return true;
                    }
                }
                return false;
            }

### Sum all the values of an array

    var total = [0, 1, 2, 3].reduce(function(a, b) {
    return a + b;
    }, 0);
    // total == 6