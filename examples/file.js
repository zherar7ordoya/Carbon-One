class Rectangle {

    // Declare properties
    height;
    width;

    constructor(height, width) {
        this.height = height;
        this.width = width;
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
        yield this.height;
        yield this.width;
    }
}

const square = new Rectangle(10, 10);

// Example of a function that uses the Rectangle class
function createSquare(sideLength) {
    return new Rectangle(sideLength, sideLength);
}

console.log(square.area); // 100
console.log([...square.getSides()]); // [10, 10, 10, 10]
