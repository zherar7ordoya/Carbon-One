interface Shape {
    createdAt: Date;
    area(): number;
}

abstract class AbstractShape implements Shape {
    createdAt: Date;

    constructor() {
        this.createdAt = new Date();
    }

    abstract area(): number;
}

class Rectangle extends AbstractShape {
    constructor(private width: number, private height: number) {
        super();
    }

    area(): number {
        return this.width * this.height;
    }
}

function printShapeInfo(shape: Shape): void {
    const className = shape.constructor.name;
    console.log(`${className} area: ${shape.area().toFixed(2)}`);
}

const rect: Shape = new Rectangle(5, 3);
printShapeInfo(rect);
