"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    var desc = Object.getOwnPropertyDescriptor(m, k);
    if (!desc || ("get" in desc ? !m.__esModule : desc.writable || desc.configurable)) {
      desc = { enumerable: true, get: function() { return m[k]; } };
    }
    Object.defineProperty(o, k2, desc);
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || (function () {
    var ownKeys = function(o) {
        ownKeys = Object.getOwnPropertyNames || function (o) {
            var ar = [];
            for (var k in o) if (Object.prototype.hasOwnProperty.call(o, k)) ar[ar.length] = k;
            return ar;
        };
        return ownKeys(o);
    };
    return function (mod) {
        if (mod && mod.__esModule) return mod;
        var result = {};
        if (mod != null) for (var k = ownKeys(mod), i = 0; i < k.length; i++) if (k[i] !== "default") __createBinding(result, mod, k[i]);
        __setModuleDefault(result, mod);
        return result;
    };
})();
var _a, _b, _c;
Object.defineProperty(exports, "__esModule", { value: true });
// This code demonstrates the use of a «tuple type» in TypeScript.
// A tuple is a fixed-length array where each element can have a different type.
const coord = [1, "2"];
console.log(coord[0]); // 1
console.log(coord[1]); // 2
// This code demonstrates the use of a «union type» in TypeScript.
let direction;
direction = "North"; // Valid => Error: direction = "Up" => Type '"Up"' is not assignable to type
if (direction === "North") {
    console.log("Heading North");
}
// This code demonstrates the use of a «literal type» in TypeScript.
var Size;
(function (Size) {
    Size[Size["Small"] = 100] = "Small";
    Size[Size["Medium"] = 101] = "Medium";
    Size[Size["Large"] = 102] = "Large";
    Size[Size["ExtraLarge"] = 103] = "ExtraLarge";
})(Size || (Size = {}));
var size = Size.ExtraLarge;
if (size === 103) {
    console.log("Size is ExtraLarge");
}
// This code demonstrates the use of a «type guard» in TypeScript.
let x = 1;
const y = x + 1; // Cast x to number
if (typeof x === "number") {
    console.log(x + 1); // 2
}
else if (typeof x === "string") {
    console.log(x.toUpperCase()); // Error: Object is of type 'unknown'
}
// This code demonstrates the use of a «type assertion» in TypeScript.
function processFeedback1(input) {
    console.log(`Processing feedback: ${input}`);
}
processFeedback1("Great job!"); // Valid
processFeedback1(42); // Valid
processFeedback1(new Blob()); // Valid
// This code demonstrates the use of a «type assertion» in TypeScript.
function processFeedback2(input) {
    if (typeof input === "string") {
        console.log(`Processing string feedback: ${input}`);
    }
    else if (typeof input === "number") {
        console.log(`Processing number feedback: ${input}`);
    }
    else if (input instanceof Blob) {
        console.log("Processing blob feedback");
    }
    else {
        console.log("Unknown feedback type");
    }
}
processFeedback2("Great job!"); // Valid
processFeedback2(42); // Valid
processFeedback2(new Blob()); // Valid
processFeedback2({}); // Valid, but will print "Unknown feedback type"
///////////// 01:17:55 | 2.5 - Optional Chaining and Bang Operator /////////////
const arr1 = [{ name: "Alice" }, { name: "Bob" }, { name: "Charlie" }];
const el1 = (_a = arr1.pop()) === null || _a === void 0 ? void 0 : _a.name;
const arr2 = [[{ name: "Alice" }]];
const el2 = (_c = (_b = arr2.pop()) === null || _b === void 0 ? void 0 : _b.pop()) === null || _c === void 0 ? void 0 : _c.name;
console.log(`el2: ${el2}`); // Alice
const arr3 = [[{ name: "Alice" }]];
const el3 = arr3.pop().pop().name;
console.log(`el3: ${el3}`); // Alice
///////////////////// 01:24:45 | 3.1 - Basic Function Types /////////////////////
console.log("Basic Function Types");
function addTwoNumbers(x, y) {
    if (x == 0) {
        return "Invalid number";
    }
    return x + y;
}
const res1 = addTwoNumbers(5, 10); // 15
console.log(`res1: ${res1}`); // 15
const res2 = addTwoNumbers(0, 10); // "Invalid number"
console.log(`res2: ${res2}`); // "Invalid number"
function makeName1(firstName, lastName, middleName) {
    if (middleName) {
        return `${firstName} ${middleName} ${lastName}`;
    }
    return `${firstName} ${lastName}`;
}
const fullName1 = makeName1("John", "Doe", "M."); // "John M. Doe"
console.log(`fullName1: ${fullName1}`); // "John M. Doe"
const fullName2 = makeName1("Jane", "Doe"); // "Jane  Doe"
console.log(`fullName2: ${fullName2}`); // "Jane  Doe"
function makeName2(firstName, lastName, middleName = "J.") {
    return `${firstName} ${middleName} ${lastName}`;
}
const fullName3 = makeName2("John", "Doe", "M."); // "John M. Doe"
console.log(`fullName3: ${fullName3}`); // "John M. Doe"
const fullName4 = makeName2("Homer", "Simpson"); // "Jane M. Doe"
console.log(`fullName4: ${fullName4}`); // "Jane M. Doe"
function callFunc(func, param1, param2) {
    return func(param1, param2);
}
callFunc(makeName1, "John", "Doe"); // "John Doe"
function callFunction(fn, a, b) {
    return fn(a, b);
}
const sumResult = (x, y) => x + y;
const result = callFunction(sumResult, 5, 10); // 15
/* ************************************************************************** */
function multiply(x, y) {
    return x * y;
}
function divide(x, y) {
    return x / y;
}
// Función que aplica un conjunto de funciones binarias (de dos argumentos) a un conjunto de pares de valores,
// devolviendo un arreglo con los resultados. Esta es la parte más representativa del enfoque funcional:
function applyFunc(funcs, // Un array de funciones que toman dos números y devuelven un número
values // Un array de pares de números (tuplas de dos elementos)
) {
    const results = []; // Aquí se irán guardando los resultados
    for (let i = 0; i < funcs.length; i++) // Se itera sobre las funciones
     {
        const args = values[i]; // Se toma el par de valores correspondiente
        const result = funcs[i](args[0], args[1]); // Se invoca la función con ese par
        results.push(result); // Se guarda el resultado
    }
    return results; // Se devuelve el array de resultados
}
console.log(applyFunc([multiply, divide], [
    [10, 8], // 80
    [6, 4] // 1.5
])); // [80, 1.5]
/////////////////// 01:40:22 | 3.2 - Advanced Function Types ///////////////////
// Rest parameters allow a function to accept an indefinite number of arguments as an array.
function sum(...values) {
    return values.reduce((accumulator, currentValue) => accumulator + currentValue, 0);
}
console.log(sum(1, 2, 3, 4, 5)); // 15
function getItemLength(itemOrItems) {
    if (typeof itemOrItems === "string") {
        return itemOrItems.length;
    }
    else if (Array.isArray(itemOrItems)) {
        //return itemOrItems.reduce((acc, item) => acc + item.length, 0);
        return "You passed an array of strings";
    }
    return 0; // Default case if neither string nor array
}
console.log(getItemLength("Hello")); // 5
console.log(getItemLength(["Hello", "World"])); // 10
const person = {
    name: "Alice",
    age: 30,
    hello: () => `Hello, my name is ${person.name} and I am ${person.age} years old.`,
};
console.log(person.hello()); // "Hello, my name is Alice and I am 30 years old."
const worker = {
    name: "Bob",
    age: 25,
    employeeId: 12345,
    hello: () => `Hello, my name is ${worker.name}, I am ${worker.age} years old, and my employee ID is ${worker.employeeId}.`,
};
console.log(worker.hello()); // "Hello, my name is Bob, I am 25 years old, and my employee ID is 12345."
const manager = {
    name: "Charlie",
    age: 40,
    employeeId: 67890,
    employees: [worker],
    hello: () => `Hello, my name is ${manager.name}, I am ${manager.age} years old, and I manage ${manager.employees.length} employees.`,
};
function getPerson(person) {
    return {
        name: "Tim",
        age: 23,
        hello: () => `Hello, my name is ${person.name} and I am ${person.age} years old.`,
    };
}
// Example of a class implementing an interface
class Person {
    constructor(x) {
        this.name = x;
        this.greet();
    }
    greet() {
        console.log(`Hello, my name is ${this.name}`);
    }
    getName() {
        if (this.name.length < 2)
            return "Name is too short";
        return this.name;
    }
    setName(newName) {
        this.name = newName;
    }
}
const p1 = new Person("Alice");
class Dog {
    constructor(name, color) {
        this.name = name;
        this.color = color; // Using "this" to refer to the instance property
        Dog.InstanceCount++; // Using the class name to access the static property
    }
    speak() {
        console.log(`I am ${this.name} and I am ${this.color}.`);
    }
    test() {
        console.log(`This is a test method for ${this.name}.`);
    }
    static decreaseInstanceCount() {
        if (this.InstanceCount > 0) {
            this.InstanceCount--;
        }
    }
}
Dog.InstanceCount = 0;
const dog = new Dog("Buddy", "brown");
dog.speak(); // "I am Buddy and I am brown."
//dog.test(); // "This is a test method for Buddy."
class Cat {
    speak() {
        console.log("Meow!");
    }
}
const cat = new Cat();
const animal = cat;
animal.speak(); // "Meow!"
const animals = [dog, cat];
animals.forEach(animal => animal.speak()); // "I am Buddy and I am brown." "Meow!"
function makeAnimalSpeak(animal) {
    animal.speak();
}
makeAnimalSpeak(dog); // "I am Buddy and I am brown."
makeAnimalSpeak(cat); // "Meow!"
///////////////// 02:21:15 | 4.3 - Static Attributes & Methods /////////////////
const dog1 = new Dog("Rex", "black");
const dog2 = new Dog("Max", "white");
console.log(`Total Dog instances: ${Dog.InstanceCount}`); // 3 (Rex, Max, Buddy)
Dog.decreaseInstanceCount();
console.log(`Total Dog instances after decrease: ${Dog.InstanceCount}`); // 2 (Rex, Max)
////////////////////////// 02:25:37 | 4.4 - Generics ////////////////////////////
class DataStore {
    constructor() {
        this.items = [];
    }
    addTwoNumbersItem(item) {
        this.items.push(item);
    }
    getItem(index) {
        return this.items[index];
    }
    removeItem(index) {
        this.items.splice(index, 1);
    }
    getAllItems() {
        return this.items;
    }
}
/* ***********************  */
function getValue(key, value1, value2) {
    if (key) {
        return value1;
    }
    return value2;
}
const n1 = 10;
const n2 = 20;
console.log(getValue(true, n1, n2)); // 10
//////////////////////// 02:32:26 | 5.1 - Type Aliases /////////////////////////
// Custom type for non object based types
function compareCoordinates1(coord1, coord2) {
    return [coord1[0] - coord2[0], coord1[1] - coord2[1]];
}
function compareCoordinates2(coord1, coord2) {
    return [coord1[0] - coord2[0], coord1[1] - coord2[1]];
}
const contact = {
    name: "John Doe",
    email: "john.doe@example.com",
    phone: "123-456-7890"
};
function addTwoNumbersContact(contact) {
    if ("birthdate" in contact) {
        console.log(`addTwoNumbersing individual contact: ${contact.name}, born on ${contact.birthdate}`);
    }
    else {
        console.log(`addTwoNumbersing organization contact: ${contact.companyName}, phone: ${contact.companyPhone}`);
    }
}
// Type guard to check if contact is an organization
function getName(contact) {
    if ("birthdate" in contact) {
        return contact.name;
    }
    else {
        //return `Contact is an organization: ${contact.companyName}`;
        return isOrganization(contact)
            ? contact.companyName
            : "Unknown Organization";
    }
}
function isOrganization(contact) {
    return contact.companyName !== undefined;
}
function logMessage(log) {
    switch (log.type) {
        case "warning":
            console.log(`Warning: ${log.msg}`);
            break;
        case "info":
            console.log(`Info: ${log.text}`);
            break;
        case "success":
            console.log(`Success: ${log.message}`);
            break;
        default:
            const _exhaustiveCheck = log; // Ensures all cases are handled
            throw new Error(`Unhandled log type: ${_exhaustiveCheck}`);
    }
}
/*** Partial makes all properties optional, allowing you to update only specific fields. ***/
const updateTodo = (todo) => {
    todo.title = todo.title || "Default Title"; // Optional chaining
};
/*** Readonly: makes all properties read-only. ***/
const onlyReadTodo = {
    title: "Read Only Todo",
    description: "This todo cannot be modified",
    id: 1,
    completed: false
};
const pages = {
    home: { title: "Home Page" },
    about: { title: "About Page" },
    contact: { title: "Contact Page" }
};
const pageNumbers = {
    0: { title: "Home Page" },
    1: { title: "About Page" },
    2: { title: "Contact Page" }
};
const todoPreview = {
    title: "Learn TypeScript",
    completed: false
};
const todoWithoutId = {
    title: "Learn TypeScript",
    description: "Understand utility types",
    completed: false
};
// ////////////////////////////////////////////////////////////////////////// //
const util_js_1 = __importStar(require("./util.js"));
console.log(`add(5, 10): ${(0, util_js_1.add)(5, 10)}`); // 15
console.log(`Anything: ${(0, util_js_1.default)()}`); // "This is a default export function"
// ////////////////////////////////////////////////////////////////////////// //
var Utils;
(function (Utils) {
    class MathUtils {
    }
    Utils.MathUtils = MathUtils;
    function add(x, y) {
        return x + y;
    }
    Utils.add = add;
    Utils.PI = 3.14;
})(Utils || (Utils = {}));
const calculated = Utils.add(5, 10);
console.log(`Utils.add(5, 10): ${calculated}`); // 15
