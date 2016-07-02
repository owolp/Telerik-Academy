# Codes to find index

## Two Girls One Path

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