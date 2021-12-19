using HomeWork5C;


var numberOfRepetitions = 100000;

var test = new Test { V1 = 1, V2 = 2, V3 = 3, V4 = 4, V5 = 5 };

var csv = CSV.Serialize<Test>(test, numberOfRepetitions);
CSV.Deserialize<Test>(csv, numberOfRepetitions);


var json = JSON.Serialize(test, numberOfRepetitions);
JSON.Deserialize<Test>(json, numberOfRepetitions);