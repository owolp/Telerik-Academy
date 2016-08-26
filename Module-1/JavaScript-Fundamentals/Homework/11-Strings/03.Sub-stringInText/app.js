function solve(args) {
  var find = (args[0] + '').toLowerCase(),
    parse = (args[1] + '').toLowerCase(),
    counter = 0;

  var index = parse.indexOf(find);
  while (index >= 0) {
    counter += 1;
    index = parse.indexOf(find, index + 1);
  }

  console.log(counter);
}