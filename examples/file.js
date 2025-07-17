import { createRequire } from 'module';

class Rectangle {

    // Declare properties
    height;
    width;
    temporal;
    template;

    constructor(height, width) {
        this.height = height;
        this.width = width;
        this.temporal = new createRequire(import.meta.url)('./temporal.js');
        this.template = `The area of the rectangle is ${this.area}`;
    }
    // Getter
    get area() {
        return this.calcArea();
    }
    // Method
    calcArea() {
        return this.height * this.width;
    }
    *getSides() {
        yield this.height;
        yield this.width;
    }
}

const square = new Rectangle(10, 10);

// Example of a function that uses the Rectangle class
function createSquare(sideLength) {
    return new Rectangle(sideLength, sideLength);
}

// Get result using arrow function
var e = 10;
const squareArea = e => createSquare(e).area;
console.log(squareArea()); // 100
console.log([...square.getSides()]); // [10, 10, 10, 10]
