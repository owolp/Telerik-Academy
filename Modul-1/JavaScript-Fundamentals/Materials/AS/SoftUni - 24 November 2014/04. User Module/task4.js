function task4(input) {
    'use strict';

    Array.prototype.average = function() {
        var sum = 0;
        var j = 0;
        for (var i=0;i<this.length;i++){
            if(isFinite(this[i])){
                sum=sum+parseFloat(this[i]);
                j++;
            }
        }
        if(j===0){
            return 0;
        }else{
            return (sum/j).toFixed(2);
        }

    }

    var i,
        students = [],
        trainers = [],
        studentsNew = [],
        trainersNew = [],
        data,
        result = {};

    for (i = 1; i < input.length; i += 1) {
        data = JSON.parse(input[i]);
        if (data.role === 'student') {
            students.push(data);
        } else {
            trainers.push(data);
        }
    }

    if (input[0].split('^')[0] === 'name') {
        students.sort(function (s1, s2) {
            if (s1.firstname < s2.firstname) {
                return 1;
            } else if (s1.firstname > s2.firstname) {
                return -1;
            } else {
                if (s1.lastname > s2.lastname) {
                    return 1;
                } else if (s1.lastname < s2.lastname) {
                    return -1;
                } else {
                    return 0;
                }
            }
        });
    }

    if (input[0].split('^')[0] === 'level') {
        students.sort(function (s1, s2) {
            if (s2.level - s1.level < 0) {
                return 1;
            } else if (s2.level - s1.level > 0) {
                return -1;
            } else {
                if (s2.id - s1.id < 0) {
                    return 1;
                } else if (s2.id - s1.id > 0) {
                    return -1;
                } else {
                    return 0;
                }
            }
        });
    }

    trainers.sort(function (t1, t2) {
        if (t2.courses.length - t1.courses.length < 0) {
            return 1;
        } else if (t2.courses.length - t1.courses.length > 0) {
            return -1;
        } else {
            if (t2.lecturesPerDay - t1.lecturesPerDay < 0) {
                return 1;
            } else if (t2.lecturesPerDay - t1.lecturesPerDay > 0) {
                return -1;
            } else {
                return 0;
            }
        }
    });

    for (i = 0; i < students.length; i += 1) {
        var obj =
        {
            'id': students[i].id,
            'firstname': students[i].firstname,
            'lastname': students[i].lastname,
            'averageGrade': students[i].grades.average().toString(),
            'certificate': students[i].certificate
        }
        studentsNew.push(obj);
    }

    for (i = 0; i < trainers.length; i += 1) {
        var obj =
        {
            'id': trainers[i].id,
            'firstname': trainers[i].firstname,
            'lastname': trainers[i].lastname,
            'courses': trainers[i].courses,
            'lecturesPerDay': trainers[i].lecturesPerDay
        }
        trainersNew.push(obj);
    }

    result =  {
        'students': studentsNew,
        'trainers': trainersNew
    };

    console.log(JSON.stringify(result));
}

(function test() {
    'use strict';

    var input = [
        'level^courses',
        '{"id":0,"firstname":"Angel","lastname":"Ivanov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
        '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
        '{"id":2,"firstname":"Bobi","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
        '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
        '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps","Java"],"lecturesPerDay":2}'

    ];

    task4(input);

})()
