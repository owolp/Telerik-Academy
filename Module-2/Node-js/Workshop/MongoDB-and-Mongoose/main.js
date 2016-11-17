/* globals require */

"use strict";

const ModelsFactory = require("./models");
const Constants = require("./common/constants");
const Db = require("./common/mongoose")(Constants.connectionString);
const JsonReader = require("./parsers/json-reader");
const JsonWriter = require("./parsers/json-writer");
const EmployeeGenerator = require("./common/employee-generator");
const JsonToEmployee = require("./parsers/json-employee");
const Fs = require("fs");

const employees = EmployeeGenerator(10);
for (let i = 0; i < employees.length; i += 1) {
	JsonWriter(i + 1, employees[i]);
}

const employeesFromJson = [];
const directories = Fs.readdirSync("json");
for (const dir of directories) {
	const json = JsonReader(dir);
	const employee = JsonToEmployee(json);
	employeesFromJson.push(employee);
}

ModelsFactory.insertManyEmployees(employeesFromJson);