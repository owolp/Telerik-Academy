function solve(args) {
    var people = [],
        step = 3,
        input = args,
        length = input.length,
        i;

    for (i = 0; i < length; i += step) {
        people.push({
            firstName: input[i] + '',
            lastName: input[i + 1] + '',
            age: +input[i + 2]
        });
    }

    var youngest = people.reduce(
        function(a, b) {
            return a.age <= b.age ? a : b;
        });

    console.log(youngest.firstName + ' ' + youngest.lastName);
}