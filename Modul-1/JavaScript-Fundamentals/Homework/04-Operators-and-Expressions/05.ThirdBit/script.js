function ThirdBit(number) {
    var position = 3;
    var thirdBit = (number & (1 << position)) >> position;
    console.log(thirdBit);
}